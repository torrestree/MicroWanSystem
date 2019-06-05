using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Base.Interfaces
{
    /// <summary>
    /// IListData
    /// </summary>
    public interface IListData
    {
        /// <summary>
        /// ID
        /// <para>主键</para>
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 已废弃
        /// </summary>
        bool Obsoleted { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        string CreatedBy { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        DateTime CreatedDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        string RevisedBy { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        DateTime? RevisedDate { get; set; }
    }
}
