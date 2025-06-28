using System;

namespace Number11
{
    public class FooEventArgs : EventArgs
    {

    }

    public class ThirdEventArgs : EventArgs
    {

    }

    public class TypeWithLotsOfEvents
    {
        private readonly EventSet m_eventSet = new EventSet();

        public EventSet eventSet
        {
            get
            {
                return m_eventSet;
            }
        }

        protected static readonly EventKey s_footEventKey = new EventKey();

        public event EventHandler<FooEventArgs> Foo
        {
            add
            {
                m_eventSet.Add(s_footEventKey, value);
            }
            remove
            {
                m_eventSet.Remove(s_footEventKey, value);
            }
        }

        protected virtual void OnFoo(FooEventArgs e)
        {
            m_eventSet.Raise(s_footEventKey, this, e);
        }

        protected static readonly EventKey f_footEventKey = new EventKey();

        public event EventHandler<ThirdEventArgs> Third
        {
            add
            {
                m_eventSet.Add(f_footEventKey, value);
            }
            remove
            {
                m_eventSet.Remove(f_footEventKey, value);
            }
        }

        public void SimulateFoo()
        {
            OnFoo(new FooEventArgs());
        }
    }
}
