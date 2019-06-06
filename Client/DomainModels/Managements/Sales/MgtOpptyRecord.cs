using Client.DomainModels.Managements.Base.Abstracts;
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
    /// 商机跟进记录管理器
    /// </summary>
    public class MgtOpptyRecord : MgtEFCategory<CtxRuntime, OpptyRecord, Oppty>
    {
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(OpptyRecord entity, string value)
        {
            return false;
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(OpptyRecord entity, string value)
        {
            return false;
        }
        /// <summary>
        /// 设置匹配生效数据规则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override bool SetUnobsoletedRule(OpptyRecord entity)
        {
            return false;
        }
    }
}
