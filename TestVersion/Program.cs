using System;
using TestVersion.ActionFile.CsAction;
using TestVersion.Indices_Ranges;
using TestVersion.IsOperator;
using TestVersion.LocalFunction;
using TestVersion.NullC;
using TestVersion.YieldKeyword;

namespace TestVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Demo1().Process();
            //Demo1NullC.NullCMain();
            //new DemoYield().DemoYield_Main();
            //DemoLocalFunction.DemoMain();


            //DemoLocalFunction.StaticLocalFunction();
            //new TextFileAction().ReadFile(@"D:\C#\.NET Core\ProgrammingASP.NETCore\TestVersion\ActionFile\FileDemo.txt");
            //new TextFileAction().WriteFile(@"D:\C#\.NET Core\ProgrammingASP.NETCore\TestVersion\ActionFile\FileDemoWrite.txt", "lengoctu");

            NTUDemo.MainDemo();
            Console.WriteLine("Hello World!");
        }
    }
}
