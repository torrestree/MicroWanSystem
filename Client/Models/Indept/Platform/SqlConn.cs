using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Indept.Platform
{
    /// <summary>
    /// SqlConn
    /// </summary>
    [Serializable]
    public class SqlConn
    {
        /// <summary>
        /// 连接名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Server
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Database
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// UserID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Schema
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 连接信息字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"server={Server};database={Database};uid={UserID};pwd={Password};MultipleActiveResultSets=true";
        }
    }
}
