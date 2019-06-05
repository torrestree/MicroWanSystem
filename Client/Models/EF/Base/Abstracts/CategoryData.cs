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
    /// CategoryData
    /// </summary>
    /// <typeparam name="TCat"></typeparam>
    public abstract class CategoryData<TCat> : ListData, ICategoryData<TCat>
    {
        /// <summary>
        /// 类别实例
        /// </summary>
        [ForeignKey("CategoryID")]
        public virtual TCat Category { get; set; }

        /// <summary>
        /// 类别ID
        /// <para>外键</para>
        /// </summary>
        public int CategoryID { get; set; }
    }
}
