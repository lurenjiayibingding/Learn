using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLRAndAppDomain
{
    public sealed class MarshalByRefType : MarshalByRefObject
    {
        public MarshalByRefType()
        {
            Console.WriteLine("{0}的构造函数再AppDomain{1}中执行", this.GetType().ToString(), Thread.GetDomain().FriendlyName);
        }

        public void SomeMethod()
        {
            Console.WriteLine("方法 MarshalByRefType.SomeMethod 在AppDomain {0} 中执行", Thread.GetDomain().FriendlyName);
        }

        public MarshalByValue MethodWithReturn()
        {
            Console.WriteLine("方法 MethodWithReturn 在AppDomain {0} 中执行", Thread.GetDomain().FriendlyName);
            MarshalByValue t = new MarshalByValue();
            return t;
        }

        public NotMarshalableType MethodArgAndReturn(string callingDomainName)
        {
            Console.Write("调用线程从 {0} 到 {1}", callingDomainName, Thread.GetDomain().FriendlyName);
            NotMarshalableType t = new NotMarshalableType();
            return t;
        }
    }

    [Serializable]
    public sealed class MarshalByValue
    {
        private DateTime createTime = DateTime.Now;

        public MarshalByValue()
        {
            Console.WriteLine("{0}的构造方法在AppDomain{1}中执行", this.GetType().ToString(), Thread.GetDomain().FriendlyName);
        }

        public void SomeMethod()
        {
            Console.WriteLine("方法 MarshalByValue.SomeMethod 在AppDomain {0} 中执行", Thread.GetDomain().FriendlyName);
        }

        public override string ToString()
        {
            return createTime.ToLongTimeString();
        }
    }

    public sealed class NotMarshalableType
    {
        public NotMarshalableType()
        {
            Console.WriteLine("{0}的构造方法在AppDomain{1}中执行", this.GetType().ToString(), Thread.GetDomain().FriendlyName);
        }

        public void SomeMethod()
        {
            Console.WriteLine("方法 NotMarshalableType.SomeMethod 在AppDomain {0} 中执行", Thread.GetDomain().FriendlyName);
        }
    }
}
