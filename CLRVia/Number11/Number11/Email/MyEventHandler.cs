using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    /// <summary>
    /// 自定义的事件处理委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args"></param>
    public delegate void MyEventHandler<T>(EventArgs args);
}
