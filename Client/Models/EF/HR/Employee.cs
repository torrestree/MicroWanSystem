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
    /// 员工
    /// </summary>
    public class Employee : CategoryData<Department>
    {
        /// <summary>
        /// 籍贯
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("NativeID")]
        public virtual Area Native { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 籍贯ID
        /// <para>外键</para>
        /// </summary>
        public int NativeID { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDay { get; set; }
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
        /// 正式员工
        /// </summary>
        public bool IsFullTime { get; set; }
        /// <summary>
        /// 登录ID
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LoginID { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
