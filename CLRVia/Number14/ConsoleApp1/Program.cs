// See https://aka.ms/new-console-template for more information
using StringLibrary;
using System.Text;

var bytes = System.Text.Encoding.UTF8.GetBytes("abcdefg");
System.Text.Encoding.UTF8.GetString(bytes);

Console.WriteLine(MyUTF8.Decode(bytes));

UTF8Encoding u8 = new UTF8Encoding();
u8.GetString(bytes);

Console.WriteLine("over");
Console.ReadKey();