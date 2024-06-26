﻿using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using GameFrameX.Log;

namespace GameFrameX.Utility
{
    public static class AppExitHandler
    {
        private static Action<string> _existCallBack;

        private static PosixSignalRegistration exitSignalRegistration;
        private static bool _isKill = false;

        public static void Init(Action<string> existCallBack)
        {
            _isKill = false;
            _existCallBack = existCallBack;
            exitSignalRegistration = PosixSignalRegistration.Create(PosixSignal.SIGTERM, c =>
            {
                LogHelper.Info("PosixSignalRegistration SIGTERM....");
                _existCallBack?.Invoke("SIGTERM exit");
            });
            //退出监听
            AppDomain.CurrentDomain.ProcessExit += (s, e) => { _existCallBack?.Invoke("process exit"); };
            //卸载监听
            AssemblyLoadContext.Default.Unloading += DefaultOnUnloading;
            //Fetal异常监听
            AppDomain.CurrentDomain.UnhandledException += (s, e) => { HandleFetalException("AppDomain.CurrentDomain.UnhandledException", e.ExceptionObject); };
            //Task异常监听
            TaskScheduler.UnobservedTaskException += (s, e) => { HandleFetalException("TaskScheduler.UnobservedTaskException", e.Exception); };
            //ctrl+c
            Console.CancelKeyPress += (s, e) => { _existCallBack?.Invoke("ctrl+c exit"); };
        }

        private static void DefaultOnUnloading(AssemblyLoadContext obj)
        {
            HandleFetalException("AssemblyLoadContext.Default.Unloading", obj.ToString());
        }

        public static void Kill()
        {
            _isKill = true;
        }

        /// <summary>
        /// 程序发生内部异常导致程序终止
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="e"></param>
        private static void HandleFetalException(string tag, object e)
        {
            if (_isKill)
                return;
            //这里可以发送短信或者钉钉消息通知到运维
            LogHelper.Error("get unhandled exception");
            if (e is IEnumerable arr)
            {
                var sb = new StringBuilder();
                int line = 0;
                foreach (var ex in arr)
                {
                    sb.AppendLine($"Unhandled Exception:{line++}:{ex}");
                    LogHelper.Error($"Unhandled Exception:{ex}");
                }

                _existCallBack?.Invoke("all Unhandled Exception:" + sb);
            }
            else
            {
                LogHelper.Error($"Unhandled Exception:{e}");
                _existCallBack?.Invoke($"Unhandled Exception:{e}");
            }
        }
    }
}