using Client.DomainModels.Managements.Base.Interfaces;
using Client.Helpers;
using Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtBase
    /// </summary>
    public abstract class MgtBase : IMgtBase
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MgtBase()
        {
            IsShowMsg = true;
            IsShowConfirm = true;
            IsShowAsyncDlg = true;
        }

        /// <summary>
        /// 方法未实现
        /// <para>提示</para>
        /// </summary>
        protected const string MsgNullMethod = "方法未实现";

        /// <summary>
        /// 是否弹窗显示提示信息
        /// </summary>
        public bool IsShowMsg { get; set; }
        /// <summary>
        /// 提示信息缓存
        /// <para>字段</para>
        /// </summary>
        private string FieldMsg;
        /// <summary>
        /// 提示信息缓存
        /// </summary>
        public string Msg
        {
            get { return FieldMsg; }
            set
            {
                FieldMsg = value;
                ShowMsg(value);
            }
        }
        /// <summary>
        /// 错误信息缓存
        /// <para>字段</para>
        /// </summary>
        private Exception FieldEx;
        /// <summary>
        /// 错误信息缓存
        /// </summary>
        public Exception Ex
        {
            get { return FieldEx; }
            set
            {
                FieldEx = value;
                ShowEx(value);
            }
        }
        /// <summary>
        /// 弹窗显示提示信息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        protected void ShowMsg(string msg, string title)
        {
            if (IsShowMsg)
                Task.Factory.StartNew(() => DHelper.ShowMsg(msg, title)).Wait();
        }
        /// <summary>
        /// 弹窗显示提示信息
        /// </summary>
        /// <param name="msg"></param>
        protected void ShowMsg(string msg)
        {
            ShowMsg(msg, "");
        }
        /// <summary>
        /// 弹窗显示错误信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="title"></param>
        protected void ShowEx(Exception ex, string title)
        {
            if (IsShowMsg)
                Task.Factory.StartNew(() => DHelper.ShowEx(ex, title)).Wait();
        }
        /// <summary>
        /// 弹窗显示错误信息
        /// </summary>
        /// <param name="ex"></param>
        protected void ShowEx(Exception ex)
        {
            ShowEx(ex, "");
        }

        /// <summary>
        /// 是否弹窗显示确认信息
        /// </summary>
        public bool IsShowConfirm { get; set; }
        /// <summary>
        /// 弹窗显示确认信息（是、否）
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        protected bool ShowOKCancel(string msg, string title)
        {
            if (IsShowConfirm)
            {
                Task<bool> t = Task.Factory.StartNew(() => DHelper.ShowOKCancel(msg, title));
                t.Wait();
                return t.Result;
            }
            else
                return true;
        }
        /// <summary>
        /// 弹窗显示确认信息（是、否）
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected bool ShowOKCancel(string msg)
        {
            return ShowOKCancel(msg, "");
        }

        /// <summary>
        /// 模块进程取消标记
        /// </summary>
        public CancellationTokenSource TokenMgt { get; set; }
        /// <summary>
        /// 模块主线程
        /// </summary>
        public Task TaskMgt { get; set; }
        /// <summary>
        /// 取消模块主任务
        /// </summary>
        protected void TryCancelTask()
        {
            if (TaskMgt.Status == TaskStatus.Running)
            {
                TokenMgt.Cancel();
                TaskMgt.Wait();
            }
        }

        /// <summary>
        /// 是否显示异步窗口
        /// </summary>
        public bool IsShowAsyncDlg { get; set; }
        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <returns></returns>
        protected Window ShowDlgWait()
        {
            if (!IsShowAsyncDlg) return null;
            Window dlg = default;
            TokenMgt = new CancellationTokenSource();
            DispatcherOperation operation = DHelper.InvokeOnMain(() =>
            {
                Application.Current.MainWindow.IsEnabled = false;
                dlg = DHelper.CreateInstance<Window>(ViewService.DlgWait);
                dlg.Owner = Application.Current.MainWindow;
                dlg.Show();
            });
            operation.Wait();
            return dlg;
        }
        /// <summary>
        /// 显示进程窗口
        /// </summary>
        /// <returns></returns>
        protected Window ShowDlgProgress()
        {
            if (IsShowAsyncDlg) return null;
            Window dlg = default;
            TokenMgt = new CancellationTokenSource();
            DispatcherOperation operation = DHelper.InvokeOnMain(() =>
            {
                Application.Current.MainWindow.IsEnabled = false;
                dlg = DHelper.CreateInstance<Window>(ViewService.DlgProgress);
                dlg.Owner = Application.Current.MainWindow;
                dlg.Show();
            });
            operation.Wait();
            return dlg;
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="dlg"></param>
        protected void TryCloseDlg(Window dlg)
        {
            if (dlg == null) return;
            DispatcherOperation operation = DHelper.InvokeOnMain(() =>
            {
                if (dlg.IsVisible)
                    dlg.Close();
            });
            operation.Wait();
        }
    }
}
