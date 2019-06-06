using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.EF.Context;
using Client.Models.EF.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.HR
{
    /// <summary>
    /// 员工管理器
    /// </summary>
    public class MgtEmployee : MgtEFCategory<CtxRuntime, Employee, Department>
    {
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(Employee entity, string value)
        {
            return entity.Name.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(Employee entity, string value)
        {
            return entity.Name.NoCaseContains(value) || entity.Category.Manager.Name.NoCaseContains(value);
        }
        /// <summary>
        /// 设置匹配生效数据规则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override bool SetUnobsoletedRule(Employee entity)
        {
            return false;
        }
    }
}
