// See https://aka.ms/new-console-template for more information

using FileStreamPractice.DefineClass;
using System.IO;

FileHelper.SliverCopy(@"D:\娱乐\电影\[BD影视分享bd-film.cc]1500的年轻人们.2018.HD720P.中字.mp4",
    @"C:\Users\ljigu\Desktop\123\[BD影视分享bd-film.cc]1500的年轻人们.2018.HD720P.中字.mp4");

//FileHelper.WholeCopy(@"D:\娱乐\电影\[BD影视分享bd-film.cc]1500的年轻人们.2018.HD720P.中字.mp4",
//    @"C:\Users\ljigu\Desktop\123\[BD影视分享bd-film.cc]1500的年轻人们.2018.HD720P.中字.mp4");

Console.WriteLine(FileHelper.GetFileMD5(@"D:\娱乐\电影\[BD影视分享bd-film.cc]1500的年轻人们.2018.HD720P.中字.mp4"));
Console.WriteLine(FileHelper.GetFileMD5(@"C:\Users\ljigu\Desktop\123\[BD影视分享bd-film.cc]1500的年轻人们.2018.HD720P.中字.mp4"));

Console.WriteLine("Hello, World!");
