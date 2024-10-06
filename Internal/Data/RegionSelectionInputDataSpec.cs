using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredMapGenAgent.Internal.Data
{
    internal class RegionSelectionInputDataSpec
    {
        public sealed class SingleRegionData
        {
            public string RegionName;
            public Color RegionBlendColor;

            public Vector3 IdealSpawnPos;
            public float ReductionRate;

            public Guid AttachedTileGroupID;
        }


        public Color BaseColor;

        public List<SingleRegionData> SingleRegionDatas;
    }
}