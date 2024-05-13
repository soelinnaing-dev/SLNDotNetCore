// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System;
using System.Data;
using SLNDotNetCore.ConsoleApp;
using SLNDotNetCore.ConsoleApp.EFCore;
Console.WriteLine("Hello, World!\n My name is Soe Lin Naing.\r\n");
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.RunAdoDotNetExample();
//Console.WriteLine("AdoDotNetExample Finished\r\n");
//DapperExample dapperExample = new DapperExample();
//dapperExample.run();
//Console.WriteLine("Dapper Example Finished\r\n");

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.run();



