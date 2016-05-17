using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JB2.Common
{
    public class RNG
    {

        private static int _randy = 0;

        public static int ThreadSafe(int min, int max)
        {
            return ThreadSafeRandom.ThisThreadsRandom.Next(min, max);
        }
        public static int ThreadSafe(int max)
        {
            return ThreadSafeRandom.ThisThreadsRandom.Next(max);
        }


        public static int Randy
        {
            get
            {
                int newRandy = ThreadSafe(1, 65535);

                _randy = newRandy;

                return _randy;

            }
        }




    }
}
