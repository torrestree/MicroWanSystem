using Client.Models.EF.Base.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Sales
{
    /// <summary>
    /// 商机跟进记录
    /// </summary>
    public class OpptyRecord : CategoryData<Oppty>
    {
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}
