using Client.Models.EF.HR;
using Client.Models.Indept.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Statics.Platform
{
    /// <summary>
    /// LoginInfo
    /// </summary>
    public static class LoginInfo
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public static SqlConn SqlConn { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public static Employee Employee { get; set; }
    }
}
