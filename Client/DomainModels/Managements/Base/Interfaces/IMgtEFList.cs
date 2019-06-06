using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Base.Interfaces
{
    /// <summary>
    /// IMgtEFList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMgtEFList<T> : IMgtData<T>
    {
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <returns></returns>
        bool ReadContents();
        /// <summary>
        /// 异步读取实例集合
        /// </summary>
        void BeginReadContents();
        /// <summary>
        /// 读取实例集合
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ReadContents(string value);
        /// <summary>
        /// 异步读取实例集合
        /// </summary>
        /// <param name="value"></param>
        void BeginReadContents(string value);
        /// <summary>
        /// 刷新实例集合
        /// </summary>
        /// <returns></returns>
        bool RefreshContents();
        /// <summary>
        /// 异步刷新实例集合
        /// </summary>
        void BeginRefreshContents();

        /// <summary>
        /// 读取单个实例
        /// </summary>
        /// <returns></returns>
        bool ReadEntity();
        /// <summary>
        /// 异步读取单个实例
        /// </summary>
        void BeginReadEntity();
        /// <summary>
        /// 刷新单个实例
        /// </summary>
        /// <returns></returns>
        bool RefreshEntity();
        /// <summary>
        /// 异步刷新单个实例
        /// </summary>
        void BeginRefreshEntity();

        /// <summary>
        /// 新建单个实例
        /// </summary>
        /// <returns></returns>
        bool AddEntity();

        /// <summary>
        /// 废弃单个实例
        /// </summary>
        /// <returns></returns>
        bool ObsoleteEntity();
        /// <summary>
        /// 异步废弃单个实例
        /// </summary>
        void BeginObsoleteEntity();

        /// <summary>
        /// 删除单个实例
        /// </summary>
        /// <returns></returns>
        bool DeleteEntity();
        /// <summary>
        /// 异步删除单个实例
        /// </summary>
        void BeginDeleteEntity();

        /// <summary>
        /// 保存单个实例
        /// </summary>
        /// <returns></returns>
        bool SaveEntity();
        /// <summary>
        /// 异步保存单个实例
        /// </summary>
        void BeginSaveEntity();
    }
}
