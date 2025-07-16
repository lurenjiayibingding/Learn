using System.Net;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SynchronizationContext sc = SynchronizationContext.Current;
            this.button1.Text = "button1";

            Task.Run(() =>
            {
                SynchronizationContext sc2 = SynchronizationContext.Current;
                Thread.Sleep(2000);
                if (sc != null)
                {
                    sc.Post(obj =>
                    {
                        label1.Text = "³ÔÆÏÌÑ²»ÍÂÆÏÌÑÆ¤";
                    }, null);
                }
            });
        }

        private static AsyncCallback SyncContextCallback(AsyncCallback callback)
        {
            SynchronizationContext sc = SynchronizationContext.Current;
            if (sc == null)
            {
                return callback;
            }
            return asyncResult => sc.Post(result =>
            {
                callback((IAsyncResult)result);
            }, asyncResult);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var webRequest = WebRequest.Create("https://cn.bing.com/?mkt=zh-CN");

            var webResponse = webRequest.BeginGetResponse(SyncContextCallback(ProcessWebResponse), webRequest);
        }

        private void ProcessWebResponse(IAsyncResult result)
        {
            var request = (WebRequest)result.AsyncState;
            using var response = request.EndGetResponse(result);
            label1.Text = Environment.CurrentManagedThreadId.ToString() + " " + response.ContentLength;
        }
    }
}
