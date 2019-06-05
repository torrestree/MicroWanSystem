using Client.Models.EF.Base.Abstracts;
using Client.Models.EF.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.WorkingManagement
{
    /// <summary>
    /// 经营计划
    /// </summary>
    public class OperationPlan : ListData
    {
        /// <summary>
        /// 部门
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }
        /// <summary>
        /// 计划类型
        /// <para>外键实例</para>
        /// </summary>
        public virtual PlanType PlanType { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 部门ID
        /// <para>外键</para>
        /// </summary>
        public int DeptID { get; set; }
        /// <summary>
        /// 计划类型ID
        /// <para>外键</para>
        /// </summary>
        public int TypeID { get; set; }

        /// <summary>
        /// 年计划金额
        /// </summary>
        public double YearAmount { get; set; }
        /// <summary>
        /// 月计划金额
        /// </summary>
        public double MonthAmount { get; set; }

        /// <summary>
        /// 年累计完成金额
        /// </summary>
        public double YearFinished { get; set; }
        /// <summary>
        /// 年累计完成比例
        /// </summary>
        public double YearRate { get; set; }
        /// <summary>
        /// 年累计差额
        /// </summary>
        public double YearDiff { get; set; }

        /// <summary>
        /// 月累计计划金额
        /// </summary>
        public double MtDesired { get; set; }
        /// <summary>
        /// 月累计完成比例
        /// </summary>
        public double MtRate { get; set; }
        /// <summary>
        /// 月累计差额
        /// </summary>
        public double MtDiff { get; set; }

        /// <summary>
        /// 本月完成金额
        /// </summary>
        public double MonthFinished { get; set; }
        /// <summary>
        /// 本月完成比例
        /// </summary>
        public double MonthRate { get; set; }
        /// <summary>
        /// 本月差额
        /// </summary>
        public double MonthDiff { get; set; }
    }
}
