using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Functor
{
#if FOR_EDITOR
    public
#else
    internal
#endif
    static class DataMutiBitSaveFactors
    {
        public static int MultiBitSaveFactor = 3;

        public static int TwoChannelMultiBitSaveFactorMaxRepresentation = 1000;


        public static Tuple<float, float> GetTwoChannelMultiBit(in float targetValue)
        {
            float tempBuffer = (float)((int)(targetValue * MathF.Pow(10, MultiBitSaveFactor * 2)) / MathF.Pow(10, MultiBitSaveFactor));

            Tuple<float, float> values = new Tuple<float, float>((float)((int)(targetValue * MathF.Pow(10, MultiBitSaveFactor)) / MathF.Pow(10, MultiBitSaveFactor)),
                                                                 (tempBuffer - (int)tempBuffer));

            return values;
        }

        public static float GetTwoChannelRestoredValue(in Tuple<float, float> values)
        {
            float reValue = reValue = values.Item1 + (values.Item2 / MathF.Pow(10, MultiBitSaveFactor));

            return reValue;
        }
    }
}