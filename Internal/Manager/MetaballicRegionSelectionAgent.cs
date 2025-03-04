using LayeredMapGenAgent.Internal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Manager
{
    public static class MetaballicRegionSelectionAgent
    {
        public sealed class MapGenInputData
        {
            public required Vector3Int MapSize { get; set; }
            public required Vector3Int SingleChunkSize { get; set; }
            public required Vector2Int SingleRoomSize { get; set; }

            public required MetaballicRegionSelectionInputDataSpec InputDataSpec { get; set; }
        }
        public sealed class MetaballicRegionSelectionOutput
        {

        }


        public static MetaballicRegionSelectionOutput GenerateMap(in MapGenInputData mapGenInputData)
        {


            throw new NotImplementedException();
        }

        private static void CalculateSingleLayer(object inputData)
        {

        }
    }
}