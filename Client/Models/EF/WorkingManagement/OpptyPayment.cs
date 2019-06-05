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
    /// 商机回款单
    /// </summary>
    public class OpptyPayment : CategoryData<Oppty>
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int DeptID { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public double Payment { get; set; }
        /// <summary>
        /// 回款日期
        /// </summary>
        public double PayDate { get; set; }
    }
}
