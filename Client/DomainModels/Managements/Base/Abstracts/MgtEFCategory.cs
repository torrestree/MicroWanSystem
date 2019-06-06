using Client.DomainModels.Managements.Base.Interfaces;
using Client.Models.EF.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFCategory
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCat"></typeparam>
    public abstract class MgtEFCategory<Ctx, T, TCat> : MgtEFList<Ctx, T>, IMgtEFCategory<T, TCat>
        where Ctx : CtxRuntime, new()
        where T : class, ICategoryData<TCat>, new()
        where TCat : IListData
    {
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public virtual bool ReadContents(TCat category)
        {
            if (category == null) return false;
            return ReadContentsFrame(t => t.AsNoTracking().Where(s => s.CategoryID == category.ID));
        }
        /// <summary>
        /// 异步读取实例集合
        /// </summary>
        /// <param name="category"></param>
        public virtual void BeginReadContents(TCat category)
        {
            if (category == null) return;
            BeginReadContentsFrame(t => t.AsNoTracking().Where(s => s.CategoryID == category.ID));
        }
    }
}
