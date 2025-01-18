using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Data
{
    internal sealed class MiddleLayersInputDataSpec
    {
        public int CurLayerMiddleLayerDepth;
        public int GateToBackMiddleLayerDepth;

        public Vector4 ColorStepForCurLayer;
        public Vector4 ColorStepForGateToBack;
    }
}