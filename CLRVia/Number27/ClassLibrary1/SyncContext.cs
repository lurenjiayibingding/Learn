namespace ClassLibrary1
{
    public class SyncContext
    {
        /// <summary>
        /// 保证在桌面程序的UI线程中调用异步IO的回调方法
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static AsyncCallback SyncContextAsyncCallback(AsyncCallback callback)
        {
            SynchronizationContext sc = SynchronizationContext.Current;
            if (sc == null)
            {
                return callback;
            }

            var result = new AsyncCallback(asyncResult => sc.Post(result => callback((IAsyncResult)result), asyncResult));
            return result;
        }
    }
}
