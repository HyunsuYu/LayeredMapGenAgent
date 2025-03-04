using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LayeredMapGenAgent.Internal.Manager.BasicMap;


namespace LayeredMapGenAgent.Internal.Data
{
    internal sealed class TemplateInputDataSpec
    {
        /// <summary>
        /// Describe room's positions
        /// </summary>
        public sealed class SingleTemplateData
        {
            #region Old
            ///// <summary>
            ///// Describe single room
            ///// </summary>
            //public sealed class SingleTemplateNodeData
            //{
            //    /// <summary>
            //    /// 각 candidate는 왼쪽 상단부터 시작하여 위에서 아랫줄로, 왼편에서 오른편으로 읽어가며 차례대로 indexing을 하여 각 Pos를 구분한다
            //    /// </summary>
            //    public enum TemplateNodeTileType : byte
            //    {
            //        None = 0b0000_0000,
            //        RegularTile = 0b0000_0001,
            //        NPCSpawnPosCandidate = 0b0000_0010,
            //        PropSpawnPosCandidate = 0b0000_0100,
            //        DecorationSpawnPosCandidate = 0b0000_1000,
            //    }


            //    public Guid SingleTemplateNodeDataID;
            //    public TemplateNodeTileType[,] TemplateNodeTileCube;
            //}


            //public string TemplateName;
            //public Guid TemplateID;

            //public Guid AttachedRegionID;
            //public Vector3 IdealSpawnPos;

            //public Vector3Int EnterancePos;
            //public List<SingleTemplateNodeData> SingleTemplateNodeDatas;
            //public Guid[,,] TemplateCube;
            #endregion

            #region New
            public enum TemplateTileType
            {
                Platform,
                MayBePath,
                Path
            }
            #endregion
        }
        public sealed class TemplateGroup
        {
            public Dictionary<Vector2Int, Guid> SingleTemplateNodeTable;
        }


        //public List<SingleTemplateData> SingleTemplateDatas;

        public Dictionary<Guid, SingleTemplateData> SingleTemplateDataTable;
        public Dictionary<Guid, TemplateGroup> TemplateGroupsTable;
    }
}