using Leetcode.Lession;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncQueueDebug.Start();
            Console.Read();
        }
        private static void Test<T>(int runcount = 1000) where T : ILession
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var _lession = Activator.CreateInstance<T>();
            for (int i = 0; i < runcount; i++)
                _lession.Execute();
            watch.Stop();
            Console.WriteLine($"Total {watch.ElapsedMilliseconds.ToString()}ms One {(watch.ElapsedMilliseconds / runcount).ToString()}ms");
            Console.Read();
        }


    }
}
