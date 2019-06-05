using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Base.Interfaces
{
    /// <summary>
    /// ICategoryData
    /// </summary>
    public interface ICategoryData<TCat> : IListData
    {
        /// <summary>
        /// 类别实例
        /// </summary>
        TCat Category { get; set; }

        /// <summary>
        /// 类别ID
        /// <para>外键</para>
        /// </summary>
        int CategoryID { get; set; }
    }
}
