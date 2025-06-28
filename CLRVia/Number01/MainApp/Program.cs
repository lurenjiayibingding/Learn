using Newtonsoft.Json;

try
{
    // See https://aka.ms/new-console-template for more information

    CoreLib.FrameworkPrint frameworkPrint = new CoreLib.FrameworkPrint();
    frameworkPrint.Print();

    FrameworkLib.FrameworkPrint frameworkPrint1 = new FrameworkLib.FrameworkPrint();
    frameworkPrint1.Print();

    Console.WriteLine("Read Key");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(JsonConvert.SerializeObject(ex));
}