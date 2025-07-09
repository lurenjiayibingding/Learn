using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SyncAndAsync
{
    /// <summary>
    /// APM中的异常处理
    /// </summary>
    internal class APMExceptionHandling
    {
        /// <summary>
        /// 
        /// </summary>
        public void CallWebRequest()
        {
            var webRequest = WebRequest.Create("http://0.0.0.0/");
            webRequest.BeginGetResponse(ProcessWebResponse, webRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public void ProcessWebResponse(IAsyncResult result)
        {
            var webRequest = (WebRequest)result.AsyncState;
            WebResponse response = null;
            try
            {
                response = webRequest.EndGetResponse(result);
                Console.WriteLine($"Web请求响应数据长度为{response.ContentLength}");
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Web请求发生异常{JsonSerializer.Serialize(ex)}");
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }
    }
}
