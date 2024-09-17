using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Functor
{
    internal static class RandUtil
    {
        public static bool GetChance(in float chance)
        {
            Random random = new Random();
            if ((float)random.NextDouble() <= chance)
            {
                random = null;
                return true;
            }
            else
            {
                random = null;
                return false;
            }
        }
        public static bool GetHalfChance()
        {
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {
                random = null;
                return true;
            }
            else
            {
                random = null;
                return false;
            }
        }

        public static int SelectOne(in float[] chances)
        {
            Random random = new Random();

            float chanceSum = 0;
            for (int i = 0; i < chances.Length; i++)
            {
                chanceSum += chances[i];
            }

            float randomValue = (float)random.NextDouble() * chanceSum;
            float sumBuffer = 0;
            for (int index = 0; index < chances.Length; index++)
            {
                sumBuffer += chances[index];
                if (randomValue <= sumBuffer)
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
