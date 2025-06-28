// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Class;
using ConsoleApp1.Interface;

//Class1 class1 = new Class1();
//Console.WriteLine(class1.Console());
//Class2 class2 = new Class2();
//Console.WriteLine(class2.Console());

//Interface1 i1 = class1;
//Console.WriteLine(i1.Console());
//i1 = class2;
//Console.WriteLine(i1.Console());

//SimpleType s1 = new SimpleType();
//IDisposable d1 = (IDisposable)s1;

//s1.Dispose();
//d1.Dispose();

//SomeValueType v=new SomeValueType(100);
//object o=new object();

//Int32 n = v.CompareTo(v);//CompareTo方法中的参数v进行了非预期的装箱
//n = v.CompareTo(o);//编译时没错，但是运行时会抛出InvalidCastException异常

//IComparable v = new SomeValueType(100);//将值类型转为接口类型时会发生装箱
//object o = new object();
//Int32 n = v.CompareTo(v);//调用的是显示接口实现的方法，会发生装箱
//n = v.CompareTo(o);//编译时没错，但是运行时会抛出InvalidCastException异常

Derived d = new Derived();
d.CompareTo(null);


Console.WriteLine("Hello, World!");
