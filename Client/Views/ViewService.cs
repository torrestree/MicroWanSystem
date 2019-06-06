using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views
{
    /// <summary>
    /// ViewService
    /// </summary>
    public static class ViewService
    {
        /// <summary>
        /// 等待窗口
        /// </summary>
        public static Type DlgWait { get; set; }
        /// <summary>
        /// 进度窗口
        /// </summary>
        public static Type DlgProgress { get; set; }
    }
}
