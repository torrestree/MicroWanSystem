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
    /// 周计划
    /// </summary>
    public class WeekPlan : ListData
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 周次
        /// </summary>
        public int Week { get; set; }
        /// <summary>
        /// 部门ID
        /// <para>外键</para>
        /// </summary>
        public int DeptID { get; set; }
        /// <summary>
        /// 商机ID
        /// <para>外键</para>
        /// </summary>
        public int? OpptyID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 周一
        /// </summary>
        public bool Mon { get; set; }
        /// <summary>
        /// 周二
        /// </summary>
        public bool Tues { get; set; }
        /// <summary>
        /// 周三
        /// </summary>
        public bool Wed { get; set; }
        /// <summary>
        /// 周四
        /// </summary>
        public bool Thur { get; set; }
        /// <summary>
        /// 周五
        /// </summary>
        public bool Fri { get; set; }
        /// <summary>
        /// 周六
        /// </summary>
        public bool Sat { get; set; }
        /// <summary>
        /// 周日
        /// </summary>
        public bool Sun { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 交付物ID
        /// <para>外键</para>
        /// </summary>
        public int DelID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsFinished { get; set; }
        /// <summary>
        /// 任务反馈
        /// </summary>
        public string Feedback { get; set; }
    }
}
