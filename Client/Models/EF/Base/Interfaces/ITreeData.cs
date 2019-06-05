using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Base.Interfaces
{
    /// <summary>
    /// ITreeData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITreeData<T> : IListData
    {
        /// <summary>
        /// 父项实例
        /// </summary>
        T Parent { get; set; }

        /// <summary>
        /// 父项ID
        /// <para>外键</para>
        /// </summary>
        int? ParentID { get; set; }
    }
}
