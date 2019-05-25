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
            Test<TwosumLession>();

        }
        private static void Test<T>() where T : ILession
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var _lession = Activator.CreateInstance<T>();
            int runcount = 1_000;
            for (int i = 0; i < runcount; i++)           
                _lession.Execute(); 
            watch.Stop();
            Console.WriteLine($"Total {watch.ElapsedMilliseconds.ToString()}ms One {(watch.ElapsedMilliseconds / runcount).ToString()}ms");
            Console.Read();
        }


    }
}
