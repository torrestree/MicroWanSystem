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
        /// ����
        /// </summary>
        public CtxRuntime() : base(LoginInfo.SqlConn.ToString())
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CtxRuntime, Configuration>());
        }

        /// <summary>
        /// ϵͳģ��
        /// </summary>
        public virtual DbSet<SystemFn> SystemFns { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual DbSet<Area> Areas { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual DbSet<Department> Departments { get; set; }
        /// <summary>
        /// Ա��
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }
        
        /// <summary>
        /// ��ϵ��ʽ
        /// </summary>
        public virtual DbSet<Contact> Contacts { get; set; }
        /// <summary>
        /// �ͻ�
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// ��ҵ
        /// </summary>
        public virtual DbSet<Industry> Industries { get; set; }
        /// <summary>
        /// �̻�
        /// </summary>
        public virtual DbSet<Oppty> Oppties { get; set; }
        /// <summary>
        /// �̻�������¼
        /// </summary>
        public virtual DbSet<OpptyRecord> OpptyRecords { get; set; }
        /// <summary>
        /// �̻��׶�
        /// </summary>
        public virtual DbSet<OpptyStage> OpptyStages { get; set; }
        /// <summary>
        /// �̻�������
        /// </summary>
        public virtual DbSet<OpptyTracker> OpptyTrackers { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public virtual DbSet<Deliverable> Deliverables { get; set; }
        /// <summary>
        /// ��Ӫ�ƻ�
        /// </summary>
        public virtual DbSet<OperationPlan> OperationPlans { get; set; }
        /// <summary>
        /// �̻���ɵ�
        /// </summary>
        public virtual DbSet<OpptyFinished> OpptyFinisheds { get; set; }
        /// <summary>
        /// �̻��ؿ
        /// </summary>
        public virtual DbSet<OpptyPayment> OpptyPayments { get; set; }
        /// <summary>
        /// �ƻ�����
        /// </summary>
        public virtual DbSet<PlanType> PlanTypes { get; set; }
        /// <summary>
        /// �ܼƻ�
        /// </summary>
        public virtual DbSet<WeekPlan> WeekPlans { get; set; }
        /// <summary>
        /// ִ����
        /// </summary>
        public virtual DbSet<WeekPlanOperator> WeekPlanOperators { get; set; }
    }
}