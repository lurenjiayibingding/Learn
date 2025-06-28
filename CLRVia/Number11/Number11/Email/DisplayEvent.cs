using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public class DisplayEvent
    {
        private readonly EventSet eventSet;
        private readonly EventKey newMailKey;

        public DisplayEvent()
        {
            eventSet = new EventSet();
            newMailKey = new EventKey();
        }

        internal event EventHandler<NewMailEventArgs> newMail
        {
            add
            {
                eventSet.Add(newMailKey, value);
            }
            remove
            {
                eventSet.Add(newMailKey, value);
            }
        }

        internal void OnNewMail(NewMailEventArgs e)
        {
            eventSet.Raise(newMailKey, this, e);
        }
    }
}