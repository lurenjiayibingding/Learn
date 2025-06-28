using System;

namespace Number11.Class
{
    internal sealed class Fax
    {
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Fax Mail Message ");
            Console.WriteLine("From={0} To={1} Subject={2}", e.From, e.To, e.Subject);
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }
}
