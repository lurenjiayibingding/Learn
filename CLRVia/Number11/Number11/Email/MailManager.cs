using System;
using System.Threading;

namespace Email
{
    internal class MailManager
    {
        private string m_Name;

        public MailManager(string name)
        {
            m_Name = name;
        }

        public event EventHandler<NewMailEventArgs> NewMail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            //if (NewMail != null)
            //{
            //    NewMail(this, e);
            //}

            //EventHandler<MailManagerEventArgs> temp = NewMail;
            //if (temp != null)
            //{
            //    temp(this, e);
            //}

            //EventHandler<MailManagerEventArgs> temp2 =Thread.VolatileRead(ref NewMail);

            EventHandler<NewMailEventArgs> temp3 = Interlocked.CompareExchange<EventHandler<NewMailEventArgs>>(ref NewMail, null, null);
            if (temp3 != null)
            {
                temp3(this, e);
            }
        }

        internal void SimulateEmail(string from, string to, string subject)
        {
            NewMailEventArgs args = new NewMailEventArgs(from, to, subject);
            OnNewMail(args);
        }

        public override string ToString()
        {
            return m_Name;
        }
    }
}
