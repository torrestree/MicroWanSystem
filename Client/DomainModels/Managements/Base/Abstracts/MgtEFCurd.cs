using Client.Helpers;
using Client.Models.EF.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFList
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract partial class MgtEFList<Ctx, T> : MgtEFBase<Ctx, T>
        where Ctx : CtxRuntime, new()
        where T : class, IListData, new()
    {
        /// <summary>
        /// 系统模块未指定
        /// <para>提示</para>
        /// </summary>
        protected const string MsgNullSystemFn = "系统模块未指定，无法写修改日志！";//think 日志的写法还是单独做一个静态方法比较好，通过异步调用该静态方法，不会影响主业务的进程
        /// <summary>
        /// 有其他生效数据
        /// <para>提示</para>
        /// </summary>
        protected const string MsgHasOtherUnobsoleted = "该数据已存在，并处于生效状态，无法重复新建！";

        /// <summary>
        /// 读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <param name="query_condition"></param>
        /// <returns></returns>
        protected bool ReadContentsFrame(Func<DbSet<T>, IQueryable<T>> query_condition)
        {
            try
            {
                CtxContents = new Ctx();
                CondContents = query_condition(CtxContents.Set<T>());
                Contents = CondContents.ToList();
                BuildContentsView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 异步读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <param name="query_condition"></param>
        protected void BeginReadContentsFrame(Func<DbSet<T>, IQueryable<T>> query_condition)
        {
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    CtxContents = new Ctx();
                    CondContents = query_condition(CtxContents.Set<T>());
                    Task<List<T>> t = CondContents.ToListAsync(TokenMgt.Token);
                    t.Wait();
                    if (TaskMgt.Status == TaskStatus.Canceled) return;
                    Contents = t.Result;
                    BuildContentsView();
                }
                catch (Exception ex) { ReadFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }
        /// <summary>
        /// 读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <param name="set_query_condition"></param>
        /// <returns></returns>
        protected bool ReadContentsFrame(Action set_query_condition)
        {
            try
            {
                CtxContents = new Ctx();
                set_query_condition();
                Contents = CondContents.ToList();
                BuildContentsView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 异步读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <param name="set_query_condition"></param>
        protected void BeginReadContentsFrame(Action set_query_condition)
        {
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    CtxContents = new Ctx();
                    set_query_condition();
                    Task<List<T>> t = CondContents.ToListAsync(TokenMgt.Token);
                    t.Wait();
                    if (TaskMgt.Status == TaskStatus.Canceled) return;
                    Contents = t.Result;
                    BuildContentsView();
                }
                catch (Exception ex) { ReadFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }
        /// <summary>
        /// 读取实例集合
        /// <para>框架</para>
        /// </summary>
        /// <returns></returns>
        protected bool ReadContentsFrame()
        {
            if (CondContents == null) return false;
            try
            {
                CtxContents = new Ctx();
                Contents = CondContents.ToList();
                BuildContentsView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 异步读取实例集合
        /// <para>框架</para>
        /// </summary>
        protected void BeginReadContentsFrame()
        {
            if (CondContents == null) return;
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    CtxContents = new Ctx();
                    Task<List<T>> t = CondContents.ToListAsync(TokenMgt.Token);
                    t.Wait();
                    if (TaskMgt.Status == TaskStatus.Canceled) return;
                    Contents = t.Result;
                    BuildContentsView();
                }
                catch (Exception ex) { ReadFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }

        /// <summary>
        /// 读取单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="query_condition"></param>
        /// <returns></returns>
        protected bool ReadEntityFrame(Func<DbSet<T>, IQueryable<T>> query_condition)
        {
            if (BlockedByUnsaved()) return false;
            try
            {
                CtxEntity = new Ctx();
                CondEntity = query_condition(CtxEntity.Set<T>());
                Entity = CondEntity.SingleOrDefault();
                IsNew = false;
                IsEditing = false;
                BuildEntityView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 异步读取单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="query_condition"></param>
        protected void BeginReadEntityFrame(Func<DbSet<T>, IQueryable<T>> query_condition)
        {
            if (BlockedByUnsaved()) return;
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    CtxEntity = new Ctx();
                    CondEntity = query_condition(CtxEntity.Set<T>());
                    Task<T> t = CondEntity.SingleOrDefaultAsync(TokenMgt.Token);
                    t.Wait();
                    if (TaskMgt.Status == TaskStatus.Canceled) return;
                    Entity = t.Result;
                    IsNew = false;
                    IsEditing = false;
                    BuildEntityView();
                }
                catch (Exception ex) { ReadFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }
        /// <summary>
        /// 读取单个实例
        /// <para>框架</para>
        /// </summary>
        /// <returns></returns>
        protected bool ReadEntityFrame()
        {
            if (BlockedByUnsaved()) return false;
            if (CondEntity == null) return false;
            try
            {
                CtxEntity = new Ctx();
                Entity = CondEntity.SingleOrDefault();
                IsNew = false;
                IsEditing = false;
                BuildEntityView();
                return true;
            }
            catch (Exception ex) { return ReadFailed(ex); }
        }
        /// <summary>
        /// 异步读取单个实例
        /// <para>框架</para>
        /// </summary>
        protected void BeginReadEntityFrame()
        {
            if (BlockedByUnsaved()) return;
            if (CondEntity == null) return;
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    CtxEntity = new Ctx();
                    Task<T> t = CondEntity.SingleOrDefaultAsync(TokenMgt.Token);
                    t.Wait();
                    if (TaskMgt.Status == TaskStatus.Canceled) return;
                    Entity = t.Result;
                    IsNew = false;
                    IsEditing = false;
                    BuildEntityView();
                }
                catch (Exception ex) { ReadFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }

        /// <summary>
        /// 新建单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="ini_entity"></param>
        protected bool AddEntityFrame(Action ini_entity = null)
        {
            if (BlockedByUnsaved()) return false;
            try
            {
                CtxEntity = new Ctx();
                Entity = new T();
                ini_entity?.Invoke();
                Entity.DataObsoleted = false;
                CtxEntity.Set<T>().Add(Entity);
                IsNew = true;
                IsEditing = true;
                BuildEntityView();
                return true;
            }
            catch (Exception ex) { return AddFailed(ex); }
        }

        /// <summary>
        /// 废弃单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        /// <returns></returns>
        protected bool ObsoleteEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return false;
            if (!ShowOKCancel(MsgObsoleteConfirm)) return false;
            try
            {
                Entity.DataObsoleted = true;
                addtional_execution?.Invoke();
                CtxEntity.SaveChanges();
                IsNew = false;
                IsEditing = false;
                Msg = MsgObsoleteOK;
                ClearEntityView();
                RaiseContentsNeedRefresh();
                return true;
            }
            catch (Exception ex) { return ObsoleteFailed(ex); }
        }
        /// <summary>
        /// 异步废弃单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        protected void BeginObsoleteEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return;
            if (!ShowOKCancel(MsgObsoleteConfirm)) return;
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    Entity.DataObsoleted = true;
                    addtional_execution?.Invoke();
                    Task t = CtxEntity.SaveChangesAsync(TokenMgt.Token);
                    t.Wait();
                    if (TaskMgt.Status == TaskStatus.Canceled) return;
                    IsNew = false;
                    IsEditing = false;
                    Msg = MsgObsoleteOK;
                    ClearEntityView();
                    RaiseContentsNeedRefresh();
                }
                catch (Exception ex) { ObsoleteFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }

        /// <summary>
        /// 删除单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        /// <returns></returns>
        protected bool DeleteEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return false;
            if (!ShowOKCancel(MsgDeleteConfirm)) return false;
            try
            {
                CtxEntity.Set<T>().Remove(Entity);
                addtional_execution?.Invoke();
                CtxEntity.SaveChanges();
                IsNew = false;
                IsEditing = false;
                Msg = MsgDeleteOK;
                ClearEntityView();
                RaiseContentsNeedRefresh();
                return true;
            }
            catch (Exception ex) { return DeleteFailed(ex); }
        }
        /// <summary>
        /// 异步删除单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        protected void BeginDeleteEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return;
            if (!ShowOKCancel(MsgDeleteConfirm)) return;
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    CtxEntity.Set<T>().Remove(Entity);
                    addtional_execution?.Invoke();
                    Task t = CtxEntity.SaveChangesAsync(TokenMgt.Token);
                    t.Wait();
                    if (TaskMgt.Status == TaskStatus.Canceled) return;
                    IsNew = false;
                    IsEditing = false;
                    Msg = MsgDeleteOK;
                    ClearEntityView();
                    RaiseContentsNeedRefresh();
                }
                catch (Exception ex) { DeleteFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }

        /// <summary>
        /// 保存单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        /// <returns></returns>
        protected bool SaveEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return false;
            try
            {
                if (SaveValidation())
                {
                    addtional_execution?.Invoke();
                    CtxEntity.SaveChanges();
                    IsNew = false;
                    IsEditing = false;
                    Msg = MsgSaveOK;
                    RaiseEntityChanged();
                    RaiseContentsNeedRefresh();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex) { return SaveFailed(ex); }
        }
        /// <summary>
        /// 异步保存单个实例
        /// <para>框架</para>
        /// </summary>
        /// <param name="addtional_execution"></param>
        protected void BeginSaveEntityFrame(Action addtional_execution = null)
        {
            if (Entity == null) return;
            TryCancelTask();
            TaskMgt = DHelper.StartTask(() =>
            {
                Window dlg = default;
                try
                {
                    dlg = ShowDlgWait();
                    if (SaveValidation())
                    {
                        addtional_execution?.Invoke();
                        Task t = CtxEntity.SaveChangesAsync(TokenMgt.Token);
                        t.Wait();
                        if (TaskMgt.Status == TaskStatus.Canceled) return;
                        IsNew = false;
                        IsEditing = false;
                        Msg = MsgSaveOK;
                        RaiseEntityChanged();
                        RaiseContentsNeedRefresh();
                    }
                }
                catch (Exception ex) { SaveFailed(ex); }
                finally { TryCloseDlg(dlg); }
            });
        }
        /// <summary>
        /// 保存验证单个实例
        /// </summary>
        /// <returns></returns>
        protected virtual bool SaveValidation() { return HasOtherUnobsoleted(); }
        /// <summary>
        /// 当前是否有其他生效数据
        /// </summary>
        /// <returns></returns>
        protected bool HasOtherUnobsoleted()
        {
            using (Ctx ctx = new Ctx())
            {
                Expression<Func<T, bool>> exp = T => SetUnobsoletedRule(T);
                if (ctx.Set<T>().Where(exp.Compile()).Where(t => t.DataObsoleted).Count() > 0)
                {
                    Msg = MsgHasOtherUnobsoleted;
                    return true;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 设置匹配生效数据规则
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract bool SetUnobsoletedRule(T entity);
    }
}
