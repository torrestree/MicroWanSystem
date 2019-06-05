using Client.Models.EF.Base.Abstracts;
using Client.Models.EF.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Sales
{
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer : ListData
    {
        /// <summary>
        /// 行业
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("IndustryID")]
        public virtual Industry Industry { get; set; }
        /// <summary>
        /// 地区
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("AreaID")]
        public virtual Area Area { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 行业ID
        /// <para>外键</para>
        /// </summary>
        public int IndustryID { get; set; }
        /// <summary>
        /// 地区ID
        /// <para>外键</para>
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(200)]
        public string Address { get; set; }
        /// <summary>
        /// 官网
        /// </summary>
        [StringLength(100)]
        public string WebSite { get; set; }
        /// <summary>
        /// 年产值
        /// </summary>
        public double OutputValue { get; set; }
        /// <summary>
        /// 企业性质
        /// <para>0：国企；1：民营；2：外企；3：政府机构；4：民间团体</para>
        /// </summary>
        public int Nature { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 开票资料
        /// </summary>
        public string InvoiceInfo { get; set; }
    }
}
