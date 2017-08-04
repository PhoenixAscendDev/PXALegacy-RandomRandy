using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JB2.Common
{
    public class RNG
    {

        private static ushort _randy = 0;

        public static int ThreadSafe(int min, int max)
        {
            return new Random().Next(min, max);
        }
        public static int ThreadSafe(int max)
        {
            return new Random().Next(max);
        }

        public static ushort LastUsedRandy
        {
            get
            {
                return _randy;
            }
        }


        public static ushort Randy
        {
            get
            {
                int newRandy = _randy;

                if (newRandy == 0x560A)
                    newRandy = 0;

                ushort s0 = (ushort)((char)newRandy << 8);
                s0 = (ushort)(s0 ^ newRandy);

                newRandy = (((s0 & 0xff) << 8) | ((s0 & 0xff00) >> 8));

                s0 = (ushort)((((ushort)(s0 << 8) >> 8) << 1) ^ newRandy);

                ushort s1 = (ushort)((s0 >> 1) ^ 0xff80);

                if ((s0 & 1) == 0)
                {
                    if (s1 == 0xAA55)
                        newRandy = 0;
                    else
                        newRandy = s1 ^ 0x1ff4;
                }
                else newRandy = s1 ^ 0x8180;

                _randy = (ushort)newRandy;

                return _randy;

            }
        }


        public static ushort Plumber(ushort seed)
        {

            //https://www.youtube.com/watch?v=MiuLeTE2MeQ
            //https://drive.google.com/file/d/0B3JCRPC09lDtcHRjdU9pSjJCX1U/view?pageId=106671446203708014633
            //https://drive.google.com/file/d/0B3JCRPC09lDtOExmOW1hclhiNHc/view?pageId=106671446203708014633
            int newRandy = seed;

            if (newRandy == 0x560A)
                newRandy = 0;

            ushort s0 = (ushort)((char)newRandy << 8);
            s0 = (ushort)(s0 ^ newRandy);

            newRandy = (((s0 & 0xff) << 8) | ((s0 & 0xff00) >> 8));

            s0 = (ushort)((((ushort)(s0 << 8) >> 8) << 1) ^ newRandy);

            ushort s1 = (ushort)((s0 >> 1) ^ 0xff80);

            if ((s0 & 1) == 0)
            {
                if (s1 == 0xAA55)
                    newRandy = 0;
                else
                    newRandy = s1 ^ 0x1ff4;
            }
            else newRandy = s1 ^ 0x8180;


            return (ushort)newRandy;
        }

        public static List<ushort> Plumber(ushort seed, ushort count)
        {
            List<ushort> values = new List<ushort>();

            ushort value = seed;
            for(ushort i=0;i < count;i++)
            {
                value = Plumber(value);
                values.Add(value);
            }

            return values;
        }

        #region Dice
        public static byte Dice(byte numoOfFaces, ushort randyloop = 0)
        {

            ushort rnd = 0;
            for (int i = -1; i < randyloop; i++)
                rnd = JB2.Common.RNG.Randy;

            ushort div = (ushort)(65536 / numoOfFaces);


            var result = (rnd / div);
            return (byte)(result == 0 ? numoOfFaces : result);
        }

        public static byte D6
        {
            get
            {
                return Dice(6);
            }

        }

        public static byte D4
        {
            get
            {
                return Dice(4);
            }

        }

        public static byte D8
        {
            get
            {
                return Dice(8);
            }

        }

        public static byte D10
        {
            get
            {
                return Dice(10);
            }

        }

        public static byte D12
        {
            get
            {
                return Dice(12);
            }

        }

        public static byte D20
        {
            get
            {
                return Dice(20);
            }
        }

        public static byte D100
        {
            get
            {
                return Dice(100);
            }
        }

        #endregion Dice


    }
}
