using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Migrations
{
    /// <summary>
    /// 不生成外键
    /// <para>迁移配置</para>
    /// </summary>
    public class NoForeignKey : SqlServerMigrationSqlGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        protected override void Generate(DropForeignKeyOperation operation)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        protected override void Generate(AddForeignKeyOperation operation)
        { }
    }
}
