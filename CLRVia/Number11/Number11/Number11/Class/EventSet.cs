using System;
using System.Collections.Generic;
using System.Threading;

namespace Number11
{
    public sealed class EventKey : Object { }

    public sealed class EventSet
    {
        private static readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

        //public Dictionary<EventKey, Delegate> Events
        //{
        //    get
        //    {
        //        return m_events;
        //    }
        //}

        public void Add(EventKey eventkey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventkey, out d);
            m_events[eventkey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);
        }

        public void Remove(EventKey eventkey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            if (m_events.TryGetValue(eventkey, out d))
            {
                d = Delegate.Remove(d, handler);
                if (d != null)
                    m_events[eventkey] = d;
                else
                    m_events.Remove(eventkey);
            }
            Monitor.Exit(m_events);
        }

        public void Raise(EventKey eventkey, object sender, EventArgs e)
        {
            Delegate d;
            Monitor.Enter(m_events);
            m_events.TryGetValue(eventkey, out d);
            Monitor.Exit(m_events);
            if (d != null)
            {
                d.DynamicInvoke(new object[] { sender, e });
            }
        }
    }
}
