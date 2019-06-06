using Client.DomainModels.Managements.Base.Interfaces;
using Client.Models.EF.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    public abstract partial class MgtEFList<Ctx, T> : MgtEFBase<Ctx, T>, IMgtEFList<T>
        where Ctx : CtxRuntime, new()
        where T : class, IListData, new()
    {
        /// <summary>
        /// 选择的实例有变更
        /// <para>触发</para>
        /// </summary>
        /// <param name="selected_item"></param>
        protected override void RaiseSelectedItemChanged(T selected_item)
        {
            base.RaiseSelectedItemChanged(selected_item);
            BeginReadEntity();
        }

        /// <summary>
        /// 读取实例集合
        /// </summary>
        public virtual bool ReadContents()
        {
            return ReadContentsFrame(t => t.AsNoTracking());
        }
        /// <summary>
        /// 异步读取实例集合
        /// </summary>
        public virtual void BeginReadContents()
        {
            BeginReadContentsFrame(t => t.AsNoTracking());
        }
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <param name="value"></param>
        public virtual bool ReadContents(string value)
        {
            Expression<Func<T, bool>> exp = t => SetReadContentsRule(t, value);
            return ReadContentsFrame(t => t.AsNoTracking().Where(exp.Compile()).AsQueryable());
        }
        /// <summary>
        /// 异步读取实例集合
        /// </summary>
        /// <param name="value"></param>
        public virtual void BeginReadContents(string value)
        {
            Expression<Func<T, bool>> exp = t => SetReadContentsRule(t, value);
            BeginReadContentsFrame(t => t.AsNoTracking().Where(exp.Compile()).AsQueryable());
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected abstract bool SetReadContentsRule(T entity, string value);
        /// <summary>
        /// 刷新实例集合
        /// </summary>
        /// <returns></returns>
        public virtual bool RefreshContents()
        {
            return ReadContentsFrame();
        }
        /// <summary>
        /// 异步刷新实例集合
        /// </summary>
        public virtual void BeginRefreshContents()
        {
            BeginReadContentsFrame();
        }

        /// <summary>
        /// 读取单个实例
        /// </summary>
        public virtual bool ReadEntity()
        {
            if (SelectedItem == null) return false;
            return ReadEntityFrame(t => t.Where(s => s.ID == SelectedItem.ID));
        }
        /// <summary>
        /// 异步读取单个实例
        /// </summary>
        public virtual void BeginReadEntity()
        {
            if (SelectedItem == null) return;
            BeginReadEntityFrame(t => t.Where(s => s.ID == SelectedItem.ID));
        }
        /// <summary>
        /// 刷新单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool RefreshEntity()
        {
            return ReadEntityFrame();
        }
        /// <summary>
        /// 异步刷新单个实例
        /// </summary>
        public virtual void BeginRefreshEntity()
        {
            BeginReadEntityFrame();
        }

        /// <summary>
        /// 新建单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool AddEntity()
        {
            return AddEntityFrame();
        }

        /// <summary>
        /// 废弃单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool ObsoleteEntity()
        {
            return ObsoleteEntityFrame();
        }
        /// <summary>
        /// 异步废弃单个实例
        /// </summary>
        public virtual void BeginObsoleteEntity()
        {
            BeginObsoleteEntityFrame();
        }

        /// <summary>
        /// 删除单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool DeleteEntity()
        {
            return DeleteEntityFrame();
        }
        /// <summary>
        /// 异步删除单个实例
        /// </summary>
        public virtual void BeginDeleteEntity()
        {
            BeginDeleteEntityFrame();
        }

        /// <summary>
        /// 保存单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool SaveEntity()
        {
            return SaveEntityFrame();
        }
        /// <summary>
        /// 异步保存单个实例
        /// </summary>
        public virtual void BeginSaveEntity()
        {
            BeginSaveEntityFrame();
        }
    }
}
