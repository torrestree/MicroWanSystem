using Client.Models.EF.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Sales
{
    /// <summary>
    /// 行业
    /// </summary>
    public class Industry : TreeData<Industry>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
    }
}
