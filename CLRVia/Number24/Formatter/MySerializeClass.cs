using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatter
{
    /// <summary>
    /// 顾客
    /// </summary>
    [Serializable]
    public class Customer
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name;

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age;

        /// <summary>
        /// 地址
        /// </summary>
        [NonSerialized]
        public string Address;
    }

    /// <summary>
    /// 订单
    /// </summary>
    [Serializable]
    public class Order
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId;

        /// <summary>
        /// 金额
        /// </summary>
        public int Amount;
    }
}
