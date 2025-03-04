using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Data
{
    public sealed class MetaballicRegionSelectionInputDataSpec
    {
        public sealed class InfluenceDotData
        {
            public Vector3 Pos;
            public float Influence;
        }


        public Dictionary<Guid, InfluenceDotData> InfluenceDotDatas;
        public int RecursionCount;
        public float InfluenceCutValue;
    }
}