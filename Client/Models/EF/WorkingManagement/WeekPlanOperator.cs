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
    /// 执行人
    /// </summary>
    public class WeekPlanOperator : CategoryData<WeekPlan>
    {
        /// <summary>
        /// 员工
        /// <para>外键实例</para>
        /// </summary>
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 员工ID
        /// <para>外键</para>
        /// </summary>
        public int EmployeeID { get; set; }
    }
}
