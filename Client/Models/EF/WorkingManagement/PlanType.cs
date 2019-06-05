using Client.Models.EF.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.WorkingManagement
{
    /// <summary>
    /// 计划类型
    /// </summary>
    public class PlanType : ListData
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
