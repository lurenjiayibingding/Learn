using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Formatter
{
    class Program
    {
        static void Main(string[] args)
        {
            var objList = new List<string> { "回", "龙", "观" };

            Stream stream = Serialize(objList);
            stream.Position = 0;
            var newObjList = DeSerialize(stream);

            Type t = newObjList.GetType();
            Console.WriteLine(t.FullName);

            List<Customer> customers = new List<Customer> {
                new Customer{
                    Name="张三",
                    Age=20,
                    Address="河北"
                },
                new Customer{
                    Name="李四",
                    Age=21,
                    Address="河南"
                },
            };

            List<Order> orderList1 = new List<Order>
            {
                new Order{
                    OrderId="1000",
                    Amount=1000,
                },
                new Order{
                    OrderId="2000",
                    Amount=2000,
                },
            };

            List<Order> orderList2 = new List<Order>
            {
                new Order{
                    OrderId="3000",
                    Amount=3000,
                },
                new Order{
                    OrderId="4000",
                    Amount=4000,
                },
            };

            MemoryStream ms = new MemoryStream();
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(ms, customers);
            binary.Serialize(ms, orderList1);
            binary.Serialize(ms, orderList2);

            ms.Position = 0;
            List<Customer> dcustomers = (List<Customer>)binary.Deserialize(ms);
            List<Order> dorder1 = (List<Order>)binary.Deserialize(ms);
            List<Order> dorder2 = (List<Order>)binary.Deserialize(ms);

            ms.Seek(0, SeekOrigin.Begin);
            Object o = binary.Deserialize(ms);
            if (o != null)
            {

            }



            Console.ReadKey();
        }

        /// <summary>
        /// 将对象序列化为流
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static MemoryStream Serialize(object obj)
        {
            MemoryStream ms = new MemoryStream();

            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(ms, obj);
            return ms;
        }

        /// <summary>
        /// 将流反序列化为对象
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        static object DeSerialize(Stream stream)
        {
            BinaryFormatter binary = new BinaryFormatter();
            return binary.Deserialize(stream);
        }


    }
}
