using Client.Models.EF.Base.Abstracts;
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
    /// 商机
    /// </summary>
    public class Oppty : CategoryData<Customer>
    {
        /// <summary>
        /// 商机阶段
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("StageID")]
        public virtual OpptyStage Stage { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 预测金额
        /// </summary>
        public double PreAmount { get; set; }
        /// <summary>
        /// 成单金额
        /// </summary>
        public double DealAmount { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public double Payment { get; set; }
        /// <summary>
        /// 阶段ID
        /// <para>外键</para>
        /// </summary>
        public int StageID { get; set; }
        /// <summary>
        /// 商机状态
        /// <para>0：跟进；1：成单；2：暂停；3：废弃</para>
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 成单日期
        /// </summary>
        public DateTime? DealDate { get; set; }
    }
}
