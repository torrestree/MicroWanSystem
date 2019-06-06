using Client.Models.EF.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Platform
{
    /// <summary>
    /// 系统模块
    /// </summary>
    public class SystemFn : TreeData<SystemFn>
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// UI地址
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
    }
}
