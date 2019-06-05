using Client.Models.EF.Base.Abstracts;
using Client.Models.EF.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.WorkingManagement
{
    /// <summary>
    /// 商机完成单
    /// </summary>
    public class OpptyFinished : CategoryData<Oppty>
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int DeptID { get; set; }
        /// <summary>
        /// 成单金额
        /// </summary>
        public double DealAmount { get; set; }
        /// <summary>
        /// 成单日期
        /// </summary>
        public double DealDate { get; set; }
    }
}
