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
    /// 商机阶段
    /// </summary>
    public class OpptyStage : ListData
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 比例
        /// </summary>
        public int Rate { get; set; }
    }
}
