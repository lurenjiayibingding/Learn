using System;
using System.Threading;

namespace Number11.Class
{
    public class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        public virtual void OnNewMail(NewMailEventArgs e)
        {
            #region
            //if (NewMail != null)
            //{
            //    NewMail(this, e);
            //}

            //EventHandler<NewMailEventArgs> temp = NewMail;
            //if (temp != null)
            //{
            //    temp(this, e);
            //}
            #endregion

            #region
            //EventHandler<NewMailEventArgs> temp = Interlocked.CompareExchange(ref NewMail, null, null);

            //if (temp != null)
            //{
            //    temp(this, e);
            //}
            #endregion

            #region
            //EventHandler<NewMailEventArgs> temp = Thread.VolatileRead(ref NewMail);
            //if (temp != null) temp(this, e);
            #endregion

            #region
            e.Raise(this, ref NewMail);
            #endregion
        }

        protected void SimulateNewMail(string from, string to, string subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
            OnNewMail(e);
        }
    }

    public static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, object sender, ref EventHandler<TEventArgs> eventDelegete) where TEventArgs : EventArgs
        {
            EventHandler<TEventArgs> temp = Interlocked.CompareExchange(ref eventDelegete, null, null);
            if (temp != null)
                temp(sender, e);
        }
    }
}
