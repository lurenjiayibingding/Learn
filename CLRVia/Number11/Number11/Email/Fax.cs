using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    internal class Fax
    {
        /// <summary>
        /// 在构造函数中订阅事件
        /// </summary>
        /// <param name="mm"></param>
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        /// <summary>
        /// 事件发生时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FaxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail message:");
            Console.WriteLine($" From={e.From},To={e.To},Subject={e.Subject}");
        }

        /// <summary>
        /// 注销对事件的订阅
        /// </summary>
        /// <param name="mm"></param>
        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }

    internal class DisplayFax
    {
        /// <summary>
        /// 在构造函数中订阅事件
        /// </summary>
        /// <param name="mm"></param>
        public DisplayFax(DisplayEvent mm)
        {
            mm.newMail += FaxMsg;
        }

        /// <summary>
        /// 事件发生时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FaxMsg(object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail message:");
            Console.WriteLine($" From={e.From},To={e.To},Subject={e.Subject}");
        }

        /// <summary>
        /// 注销对事件的订阅
        /// </summary>
        /// <param name="mm"></param>
        public void Unregister(DisplayEvent mm)
        {
            mm.newMail -= FaxMsg;
        }
    }
}