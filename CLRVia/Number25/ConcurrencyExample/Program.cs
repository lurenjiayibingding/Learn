// See https://aka.ms/new-console-template for more information
using ConcurrencyExample.PractiseClass;

Console.WriteLine("Hello, World!");
//await ProgressPractise.CallMyMethod();
//await TaskOverPractise.ProcressTaskAsync();
DataFlowPractise dataFlow = new DataFlowPractise();
dataFlow.DataFlowMeth1(10);