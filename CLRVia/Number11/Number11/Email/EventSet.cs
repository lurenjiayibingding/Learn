using System;
using System.Collections.Generic;
using System.Threading;

namespace Email
{
    //事件与委托的关联字典
    //向字典中添加事件的方法
    //从字典中移除事件的方法

    /// <summary>
    /// 事件Key
    /// </summary>
    public sealed class EventKey : Object { }

    /// <summary>
    /// 事件集合类
    /// </summary>
    public sealed class EventSet
    {
        /// <summary>
        /// 存储事件和对应注册方法的字典
        /// </summary>
        private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(EventKey key, Delegate value)
        {
            Monitor.Enter(m_events);
            Delegate d = null;
            m_events.TryGetValue(key, out d);
            m_events[key] = Delegate.Combine(d, value);
            Monitor.Exit(m_events);
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Remove(EventKey key, Delegate value)
        {
            Monitor.Enter(m_events);
            Delegate d;
            if (m_events.TryGetValue(key, out d))
            {
                d = Delegate.Remove(d, value);
                if (d != null)
                {
                    m_events[key] = d;
                }
                else
                {
                    m_events.Remove(key);
                }
            }
            Monitor.Exit(m_events);
        }

        /// <summary>
        /// 执行事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Raise(EventKey key, Object sender, EventArgs e)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(key, out d);
            Monitor.Exit(m_events);
            if (d != null)
            {
                d.DynamicInvoke(new object[] { sender, e });
            }
        }
    }
}