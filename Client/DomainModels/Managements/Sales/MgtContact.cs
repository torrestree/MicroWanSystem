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
    /// 联系方式管理器
    /// </summary>
    public class MgtContact : MgtEFCategory<CtxRuntime, Contact, Customer>
    {
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(Contact entity, string value)
        {
            return entity.Name.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(Contact entity, string value)
        {
            return SetReadContentsRule(entity, value);
        }
        /// <summary>
        /// 设置匹配生效数据规则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override bool SetUnobsoletedRule(Contact entity)
        {
            return false;
        }
    }
}
