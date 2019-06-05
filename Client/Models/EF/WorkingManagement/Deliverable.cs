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
    /// 交付物
    /// </summary>
    public class Deliverable : ListData
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 计入销售期望
        /// </summary>
        public bool InSales { get; set; }
        /// <summary>
        /// 计入回款期望
        /// </summary>
        public bool InPayment { get; set; }
    }
}
