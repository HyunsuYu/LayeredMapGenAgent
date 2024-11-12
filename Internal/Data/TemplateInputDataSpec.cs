using LayeredMapGenAgent.Internal.Manager.BasicMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Data
{
    internal sealed class TemplateInputDataSpec
    {
        /// <summary>
        /// Describe room's positions
        /// </summary>
        public sealed class SingleTemplateData
        {
            /// <summary>
            /// Describe single room
            /// </summary>
            public sealed class SingleTemplateNodeData
            {
                /// <summary>
                /// 각 candidate는 왼쪽 상단부터 시작하여 위에서 아랫줄로, 왼편에서 오른편으로 읽어가며 차례대로 indexing을 하여 각 Pos를 구분한다
                /// </summary>
                public enum TemplateNodeTileType : byte
                {
                    None                        = 0b0000_0000,
                    RegularTile                 = 0b0000_0001,
                    NPCSpawnPosCandidate        = 0b0000_0010,
                    PropSpawnPosCandidate       = 0b0000_0100,
                    DecorationSpawnPosCandidate = 0b0000_1000,
                }


                public Guid SingleTemplateNodeDataID;
                public TemplateNodeTileType[,] TemplateNodeTileCube;
            }


            public string TemplateName;
            public Guid TemplateID;

            public Guid AttachedRegionID;
            public Vector3 IdealSpawnPos;

            public Vector3Int EnterancePos;
            public List<SingleTemplateNodeData> SingleTemplateNodeDatas;
            public Guid[,,] TemplateCube;
        }


        public List<SingleTemplateData> SingleTemplateDatas;
    }
}