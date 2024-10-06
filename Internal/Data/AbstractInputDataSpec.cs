using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Data
{
    internal sealed class AbstractInputDataSpec
    {
        public Vector3Int SingleChunkSize;
        public Vector3Int MapSize;
        public Vector2Int SingleRoomSize;

        public Dictionary<Guid, string> AreaNameTable;
    }
}
