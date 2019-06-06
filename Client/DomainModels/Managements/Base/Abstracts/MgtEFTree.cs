using Client.DomainModels.Managements.Base.Interfaces;
using Client.Helpers;
using Client.Models.EF.Base.Interfaces;
using Client.Models.EF.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Abstracts
{
    /// <summary>
    /// MgtEFTree
    /// </summary>
    /// <typeparam name="Ctx"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class MgtEFTree<Ctx, T> : MgtEFList<Ctx, T>, IMgtEFTree<T>
        where Ctx : CtxRuntime, new()
        where T : class, ITreeData<T>, new()
    {
        /// <summary>
        /// 实例集合的默认树形视图
        /// </summary>
        public ICollectionView TreeView { get; set; }
        /// <summary>
        /// 创建实例集合视图
        /// </summary>
        protected override void BuildContentsView()
        {
            base.BuildContentsView();
            TreeView = Contents.Where(t => t.ParentID == null).AsICV();
        }

        /// <summary>
        /// 新建同级单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool AddCurrent()
        {
            return AddEntityFrame(() =>
            {
                if (SelectedItem != null)
                    Entity.ParentID = SelectedItem.ParentID;
            });
        }
        /// <summary>
        /// 新建下级单个实例
        /// </summary>
        /// <returns></returns>
        public virtual bool AddSub()
        {
            if (SelectedItem == null) return false;
            return AddEntityFrame(() => Entity.ParentID = SelectedItem.ID);
        }
    }
}
