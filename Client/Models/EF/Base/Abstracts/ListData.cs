using Client.Models.EF.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Base.Abstracts
{
    /// <summary>
    /// ListData
    /// </summary>
    public abstract class ListData : IListData
    {
        /// <summary>
        /// ID
        /// <para>主键</para>
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// 已废弃
        /// </summary>
        public bool Obsoleted { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(50)]
        public string RevisedBy { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? RevisedDate { get; set; }
    }
}
