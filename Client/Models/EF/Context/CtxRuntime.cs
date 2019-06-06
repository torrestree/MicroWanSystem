namespace Client.Models.EF.Context
{
    using Client.Migrations;
    using Client.Models.EF.HR;
    using Client.Models.EF.Platform;
    using Client.Models.EF.Sales;
    using Client.Models.EF.WorkingManagement;
    using Client.Models.Statics.Platform;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// CtxRuntime
    /// </summary>
    public class CtxRuntime : DbContext
    {
        /// <summary>
        /// 构造
        /// </summary>
        public CtxRuntime() : base(LoginInfo.SqlConn.ToString())
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CtxRuntime, Configuration>());
        }

        /// <summary>
        /// 系统模块
        /// </summary>
        public virtual DbSet<SystemFn> SystemFns { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public virtual DbSet<Area> Areas { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public virtual DbSet<Department> Departments { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }
        
        /// <summary>
        /// 联系方式
        /// </summary>
        public virtual DbSet<Contact> Contacts { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// 行业
        /// </summary>
        public virtual DbSet<Industry> Industries { get; set; }
        /// <summary>
        /// 商机
        /// </summary>
        public virtual DbSet<Oppty> Oppties { get; set; }
        /// <summary>
        /// 商机跟进记录
        /// </summary>
        public virtual DbSet<OpptyRecord> OpptyRecords { get; set; }
        /// <summary>
        /// 商机阶段
        /// </summary>
        public virtual DbSet<OpptyStage> OpptyStages { get; set; }
        /// <summary>
        /// 商机跟进人
        /// </summary>
        public virtual DbSet<OpptyTracker> OpptyTrackers { get; set; }

        /// <summary>
        /// 交付物
        /// </summary>
        public virtual DbSet<Deliverable> Deliverables { get; set; }
        /// <summary>
        /// 经营计划
        /// </summary>
        public virtual DbSet<OperationPlan> OperationPlans { get; set; }
        /// <summary>
        /// 商机完成单
        /// </summary>
        public virtual DbSet<OpptyFinished> OpptyFinisheds { get; set; }
        /// <summary>
        /// 商机回款单
        /// </summary>
        public virtual DbSet<OpptyPayment> OpptyPayments { get; set; }
        /// <summary>
        /// 计划类型
        /// </summary>
        public virtual DbSet<PlanType> PlanTypes { get; set; }
        /// <summary>
        /// 周计划
        /// </summary>
        public virtual DbSet<WeekPlan> WeekPlans { get; set; }
        /// <summary>
        /// 执行人
        /// </summary>
        public virtual DbSet<WeekPlanOperator> WeekPlanOperators { get; set; }
    }
}