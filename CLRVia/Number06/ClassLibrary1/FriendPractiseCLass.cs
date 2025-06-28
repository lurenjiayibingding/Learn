using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ClassLibrary2,PublicKeyToken=null")]

namespace ClassLibrary1
{
    internal class FriendPractiseCLass
    {

        internal void Month1()
        {
            Console.WriteLine(this.GetType().Assembly.FullName);
        }
    }
}