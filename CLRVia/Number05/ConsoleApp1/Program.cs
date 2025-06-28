// See https://aka.ms/new-console-template for more information

using ConsoleApp1.PracticeClass;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

//DynamicPractice demo = new DynamicPractice();
//demo.DynamicDemo();
try
{
    byte a = 100;
    a = unchecked((byte)(a + 200));
    Console.WriteLine(a);
}
catch (Exception ex)
{
    Console.WriteLine(JsonConvert.SerializeObject(ex));
}

Console.WriteLine("Hello, World!");
