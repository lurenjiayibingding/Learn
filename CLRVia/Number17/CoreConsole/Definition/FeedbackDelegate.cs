using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.Definition
{
    internal delegate void Feedback(int value);
    public class FeedbackDelegate
    {
        Feedback f1 = new Feedback();

        public void InvoickFeedback()
        {

        }
    }
}