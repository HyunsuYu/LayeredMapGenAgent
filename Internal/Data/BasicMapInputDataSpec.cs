using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Data
{
    internal sealed class BasicMapInputDataSpec
    {
        public float MaxTryCountRatio;

        public Tuple<int, int> BrushSize;

        public float MainWayFillPercent;
        public float SubWayFillPercent;

        public float PenetratingWayCountRate;
        public float PenetratingWayFillPercent;
    }
}
