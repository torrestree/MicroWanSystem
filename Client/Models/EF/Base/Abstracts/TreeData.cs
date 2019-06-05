using Client.Models.EF.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Base.Abstracts
{
    /// <summary>
    /// TreeData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TreeData<T> : ListData, ITreeData<T>
    {
        /// <summary>
        /// 父项实例
        /// </summary>
        [ForeignKey("ParentID")]
        public virtual T Parent { get; set; }

        /// <summary>
        /// 父项ID
        /// <para>外键</para>
        /// </summary>
        public int? ParentID { get; set; }
    }
}
