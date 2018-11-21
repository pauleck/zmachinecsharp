using FileLoaders;
using System;
using System.IO;    

namespace zfileAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var v5File = new V5Loader(@"C:\mydev\zmachinecsharp\zMachine\Resources\Datfiles\zork1.z5");
            v5File.LoadFile();

            //var loopy = 0;
            //foreach (var bv in theFile)
            //{
            //    Console.WriteLine($"{loopy} - {bv}");

            //    if (loopy++ > 10)
            //    {
            //        break;
            //    }
            //}

            Console.WriteLine("DONE WAITING FOR ENTER");
            Console.ReadLine();
        }
    }
}
