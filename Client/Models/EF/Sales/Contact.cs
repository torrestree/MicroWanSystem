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
    /// 联系方式
    /// </summary>
    public class Contact : CategoryData<Customer>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 任职部门
        /// </summary>
        [StringLength(100)]
        public string Department { get; set; }
        /// <summary>
        /// 电话1
        /// </summary>
        [StringLength(50)]
        public string Phone1 { get; set; }
        /// <summary>
        /// 电话2
        /// </summary>
        [StringLength(50)]
        public string Phone2 { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        [StringLength(50)]
        public string QQ { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        [StringLength(50)]
        public string WeChat { get; set; }
        /// <summary>
        /// E-mail
        /// </summary>
        [StringLength(100)]
        public string Email { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}
