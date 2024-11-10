using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Data
{
    public sealed class RegionSelectionInputDataSpec
    {
        public sealed class SingleRegionData : IDisposable
        {
            public string RegionName;
            public Guid RegionID;

            public Vector3 RegionBlendColor;

            public Vector3 IdealSpawnPos;
            public Vector3 WeightVector;


            ~SingleRegionData()
            {
                Dispose(false);
            }
            
            public void Dispose()
            {
                Dispose(true);
            }

            private void Dispose(in bool bisDispose)
            {
                if(bisDispose)
                {
                    RegionName = string.Empty;
                    RegionName = null;

                    RegionID = Guid.Empty;
                }
            }
        }


        public Vector3 BaseColor;

        public List<SingleRegionData> SingleRegionDatas;


        public static Dictionary<int, string> GetSingleRegionDataRainbowTable(in List<SingleRegionData> singleRegionDatas)
        {
            Dictionary<int, string> singleRegionDataRainbowTable = new Dictionary<int, string>();
            foreach(var item in singleRegionDatas)
            {
                singleRegionDataRainbowTable.Add(item.RegionName.GetHashCode(), item.RegionName);
            }

            return singleRegionDataRainbowTable;
        }
    }
}