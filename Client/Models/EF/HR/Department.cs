using Client.Models.EF.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.HR
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department : TreeData<Department>
    {
        /// <summary>
        /// 部门经理
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("ManagerID")]
        public virtual Employee Manager { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 部门经理ID
        /// </summary>
        public int ManagerID { get; set; }
    }
}
