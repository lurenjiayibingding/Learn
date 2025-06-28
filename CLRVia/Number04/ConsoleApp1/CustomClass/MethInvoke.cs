using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CustomClass
{
    internal class MethInvoke
    {
        internal void M1()
        {
            string name = "Jone";
            M2(name);
            //进行一些操作
            return;
        }

        internal void M2(string s)
        {
            int length = s.Length;
            int tally;
            //进行一些操作
            return;
        }

        internal void M3()
        {
            Employee e;
            int year;
            e = new Manager();
            e = Employee.Lookup("Joe");
            year = e.GetYearsEmployee();
            e.GenProgressReport();

        }
    }

    internal class EmployeeBase
    {
        public int GetYearsEmployee()
        {
            //进行一些操作
            Console.WriteLine("EmployeeBase GetYearsEmployee");
            return 1;
        }

        public static string GetName()
        {
            return "GetName EmployeeBase";
        }
    }


    internal class Employee : EmployeeBase
    {
        //public int GetYearsEmployee()
        //{
        //    //进行一些操作
        //    Console.WriteLine("Employee GetYearsEmployee");
        //    return 1;
        //}

        public virtual string GenProgressReport()
        {
            //进行一些操作
            return "Employee";
        }

        public static Employee Lookup(string name)
        {
            //进行一些操作
            return null;
        }
    }

    internal sealed class Manager : Employee
    {
        public int GetYearsEmployee()
        {
            Console.WriteLine("Manager GetYearsEmployee");
            return 1;
        }

        //public override string GenProgressReport()
        //{
        //    return "Manager";
        //}

        public new string GenProgressReport()
        {
            return "Manager";
        }
    }
}
