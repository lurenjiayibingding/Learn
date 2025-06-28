using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLRAndAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            ////获取当前的AppDomain，通过AppDomain的静态属性也可以得到同样的结果
            //AppDomain currentAppDomain = Thread.GetDomain();
            ////AppDomain currentAppDomain = AppDomain.CurrentDomain;
            ////每个AppDomain都有一个友好名称，默认的AppDomian的友好名称就是程序集或者可执行文件的名称
            //string friendlyName = currentAppDomain.FriendlyName;
            ////获取包含入口方法的程序集的名称
            //string assemblyName = Assembly.GetEntryAssembly().FullName;

            //#region 按引用封送
            //var appDomain2 = AppDomain.CreateDomain("#AD2", null, null);
            ////通过CreateInstanceAndUnwrap方法实例化一个类型时传递的类型名必须带命名空间
            //MarshalByRefType mar = (MarshalByRefType)appDomain2.CreateInstanceAndUnwrap(assemblyName, "CLRAndAppDomain.MarshalByRefType");
            ////mar其实是个代理类型，在这里CLR对mar的类型撒谎了
            //Console.WriteLine("mar的类型为{0}", mar.GetType().ToString());
            //Console.WriteLine("mar是否为代理类型:{0}", RemotingServices.IsTransparentProxy(mar).ToString());
            ////按引用封送的类型实际执行的时候是在源AppDomain中执行的
            //mar.SomeMethod();
            //try
            //{
            //    //将源AppDomain卸载之后在目标AppDomain中调用代理类型的方法会抛出异常
            //    AppDomain.Unload(appDomain2);
            //    mar.SomeMethod();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //#endregion

            //#region 按值封送
            //AppDomain appDomain3 = AppDomain.CreateDomain("#AD3", null, null);
            //MarshalByValue mar2 = (MarshalByValue)appDomain3.CreateInstanceAndUnwrap(assemblyName, "CLRAndAppDomain.MarshalByValue");
            //Console.WriteLine("mar2是否为代理类型:{0}", RemotingServices.IsTransparentProxy(mar2).ToString());
            ////按值封送的对象在目标AppDomain中执行
            //mar2.SomeMethod();
            //try
            //{
            //    AppDomain.Unload(appDomain3);
            //    mar2.SomeMethod();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //#endregion

            VisitMarashObjProperty property = new VisitMarashObjProperty();
            property.VisitObjProperty();

            Console.ReadKey();
        }
    }
}