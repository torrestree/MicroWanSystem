using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.EF.Context;
using Client.Models.EF.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Sales
{
    /// <summary>
    /// 客户管理器
    /// </summary>
    public class MgtCustomer : MgtEFList<CtxRuntime, Customer>
    {
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(Customer entity, string value)
        {
            return entity.Name.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(Customer entity, string value)
        {
            return SetReadContentsRule(entity, value);
        }
        /// <summary>
        /// 设置匹配生效数据规则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override bool SetUnobsoletedRule(Customer entity)
        {
            return entity.Name == Entity.Name;
        }
    }
}
