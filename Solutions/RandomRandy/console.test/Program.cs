using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using JB2.Common;

namespace console.test
{
    class Program
    {
        static void Main(string[] args)
        {

            ushort rng = 0;
            var count = (ushort)RNG.ThreadSafe(1, 100);
            Console.WriteLine(count);
            rng = RNG.Plumber(0,RNG.Dice(100,count )).LastOrDefault();


            for(int i =0; i < 100;i++)
            {
                count = (ushort)RNG.ThreadSafe(1, 100);
                rng = RNG.Plumber(RNG.Randy,RNG.D100).LastOrDefault();
                Console.WriteLine(rng);
            }
            
            //for(int i = 0; i < 10; i++)
            //{
            //    rng = JB2.Common.RNG.Plumber(rng);
            //    Console.WriteLine(rng);
            //}

            //Stopwatch sw = Stopwatch.StartNew();
            //List<int> values = new List<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    var rng = JB2.Common.RNG.D20;
            //    values.Add(rng);
            //}
            //sw.Stop();

            ////values.Sort();
            //Dictionary<int, int> counts = new Dictionary<int, int>();
            //foreach (var i in values)
            //{
            //    if (counts.ContainsKey(i))
            //        counts[i] = counts[i] + 1;
            //    else
            //        counts.Add(i, 1);

            //    Console.WriteLine(i);
            //}

            //Console.ReadLine();

            //List<int> keys = counts.Keys.ToList();
            //keys.Sort();

            //Console.WriteLine("time: " + sw.Elapsed.ToString());
            //foreach (var key in keys)
            //{
            //    Console.WriteLine("[" + key.ToString() + "] = " + counts[key].ToString());
            //}
            //Console.ReadLine();


            //values = new List<int>();
            //counts = new Dictionary<int, int>();

            //sw = Stopwatch.StartNew();
            //for (int i = 0; i < 10; i++)
            //{
            //    var rng = JB2.Common.RNG.ThreadSafe(1, 20);
            //    values.Add(rng);
            //}
            //sw.Stop();


            //foreach (var i in values)
            //{
            //    if (counts.ContainsKey(i))
            //        counts[i] = counts[i] + 1;
            //    else
            //        counts.Add(i, 1);

            //   // Console.WriteLine(i);
            //}


            //keys = counts.Keys.ToList();
            //keys.Sort();

            //Console.WriteLine("time: " + sw.Elapsed.ToString());
            //foreach (var key in keys)
            //{
            //    Console.WriteLine("[" + key.ToString() + "] = " + counts[key].ToString());
            //}

            Console.ReadLine();


        }
    }
}
