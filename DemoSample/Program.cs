using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = GetNameAsync1();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // other logic
            Task.Delay(1000).Wait();
            Console.WriteLine(task.Result);
            //Console.WriteLine(GetName());
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed.TotalMilliseconds}m seconds");

            Console.Read();
        }

        #region method

        private static string GetName()
        {
            Task.Delay(1000).Wait();

            return "Tim";
        }

        private static Task<string> GetNameAsync1()
        {
            return Task.Run(() =>
            {
                Task.Delay(1000).Wait();

                return "Tim";
            });
        }

        private static async Task<string> GetNameAsync2()
        {
            return await Task.Run(() =>
            {
                Task.Delay(2000).Wait();

                return "Tim";
            });
        }

        #endregion
    }
}
