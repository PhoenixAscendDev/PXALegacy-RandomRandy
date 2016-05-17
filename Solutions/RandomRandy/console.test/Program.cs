using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.test
{
    class Program
    {
        static void Main(string[] args)
        {


            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(JB2.Common.RNG.Randy);
            }

            Console.ReadLine();
        }
    }
}
