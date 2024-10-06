using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LayeredMapGenAgent.Internal.Data;
using LayeredMapGenAgent.Internal.Manager.BasicMap;


namespace LayeredMapGenAgent.Internal.Manager
{
    public enum TileEdgyType : short
    {
        // 일반적인 타일
        Nor_TBLR = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,

        Nor_BLR = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Nor_TLR = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Nor_TBR = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsRightEdge,
        Nor_TBL = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge,

        Nor_LR = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Nor_TB = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge,
        Nor_BL = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge,
        Nor_BR = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsRightEdge,
        Nor_TL = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsLeftEdge,
        Nor_TR = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsRightEdge,

        Nor_T = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsTopEdge,
        Nor_B = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsBottomEdge,
        Nor_L = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsLeftEdge,
        Nor_R = MapActiveType.BIsNodeActive | MapActiveType.BIsNodeIsRightEdge,

        Nor = MapActiveType.BIsNodeActive,

        // 뒤로 넘어가는 타일
        Back_TBLR = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge | MapActiveType.BIsNodeIsGateToBack,

        Back_BLR = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Back_TLR = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Back_TBR = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsRightEdge,
        Back_TBL = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge,

        Back_LR = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Back_TB = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge,
        Back_BL = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge,
        Back_BR = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsRightEdge,
        Back_TL = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsLeftEdge,
        Back_TR = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsRightEdge,

        Back_T = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsTopEdge,
        Back_B = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsBottomEdge,
        Back_L = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsLeftEdge,
        Back_R = MapActiveType.BIsNodeIsGateToBack | MapActiveType.BIsNodeIsRightEdge,

        Back = MapActiveType.BIsNodeIsGateToBack,

        // 뒤로 넘어가는 타일 바닥(일반적인 타일로 해결이 안되고 공중에 떠있는 얇은 바닥)
        StairToGoBackLayer = MapActiveType.BIsNodeIsGateBottomEdge,

        // 앞에서 넘어오는 타일
        Front_TBLR = Front | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge | MapActiveType.BIsNodeIsGateToBack,

        Front_BLR = Front | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Front_TLR = Front | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Front_TBR = Front | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsRightEdge,
        Front_TBL = Front | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge,

        Front_LR = Front | MapActiveType.BIsNodeIsLeftEdge | MapActiveType.BIsNodeIsRightEdge,
        Front_TB = Front | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsBottomEdge,
        Front_BL = Front | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsLeftEdge,
        Front_BR = Front | MapActiveType.BIsNodeIsBottomEdge | MapActiveType.BIsNodeIsRightEdge,
        Front_TL = Front | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsLeftEdge,
        Front_TR = Front | MapActiveType.BIsNodeIsTopEdge | MapActiveType.BIsNodeIsRightEdge,

        Front_T = Front | MapActiveType.BIsNodeIsTopEdge,
        Front_B = Front | MapActiveType.BIsNodeIsBottomEdge,
        Front_L = Front | MapActiveType.BIsNodeIsLeftEdge,
        Front_R = Front | MapActiveType.BIsNodeIsRightEdge,

        Front = 0b00000001_00000000,

        // 앞에서 넘어오는 타일 바닥(일반적인 타일로 해결이 안되고 공중에 떠있는 얇은 바닥)
        StairToGoFrontLayer = 0b00000010_00000000
    }


    internal sealed class TileEdgyLayerDetector : IDisposable
    {
        public sealed class TileEdgyDetectionInput
        {
            public required Vector3Int MapSize { get; set; }
            public required Vector3Int SingleChunkSize { get; set; }
            public required Vector2Int SingleRoomSize { get; set; }

            public required MapActiveType[,] FrontMapActivePlane { get; set; }
            public required MapActiveType[,] MapActivePlane { get; set; }

            public required int LayerIndex { get; set; }

            public required ManualResetEvent ManualResetEvent { get; set; }
        }
        public sealed class TileEdgyDetectionOutput
        {
            public TileEdgyType[,] TileEdgyTypePlane;
        }


        private Vector3Int m_mapSize, m_singleChunkSize;
        private Vector2Int m_singleRoomSize;

        private MapActiveType[,] m_frontMapActivePlane;
        private MapActiveType[,] m_mapActivePlane;

        private int m_layerIndex;

        private ManualResetEvent m_manualResetEvent;
        private TileEdgyDetectionOutput m_tileEdgyDetectionOutput;


        public TileEdgyLayerDetector(in TileEdgyDetectionInput tileEdgyDetectionInput)
        {
            m_mapSize = tileEdgyDetectionInput.MapSize;
            m_singleChunkSize = tileEdgyDetectionInput.SingleChunkSize;
            m_singleRoomSize = tileEdgyDetectionInput.SingleRoomSize;

            m_frontMapActivePlane = tileEdgyDetectionInput.FrontMapActivePlane;
            m_mapActivePlane = tileEdgyDetectionInput.MapActivePlane;

            m_layerIndex = tileEdgyDetectionInput.LayerIndex;

            m_manualResetEvent = tileEdgyDetectionInput.ManualResetEvent;
        }
        ~TileEdgyLayerDetector()
        {
            Dispose(false);
        }

        public TileEdgyDetectionOutput TileEdgyOutput
        {
            get
            {
                return m_tileEdgyDetectionOutput;
            }
        }

        public void DetectEdgy()
        {
            Vector2Int fullMapSize = new Vector2Int()
            {
                x = m_mapSize.x * m_singleChunkSize.x * m_singleRoomSize.x,
                y = m_mapSize.z * m_singleChunkSize.z * m_singleRoomSize.y
            };

            TileEdgyType[,] tileEdgyTypePlane = new TileEdgyType[fullMapSize.y, fullMapSize.x];
            for (int coord_y = 0; coord_y < fullMapSize.y; coord_y++)
            {
                for(int coord_x = 0; coord_x < fullMapSize.x; coord_x++)
                {
                    // 일반적인 타일
                    if (m_mapActivePlane[coord_y, coord_x].HasFlag(MapActiveType.BIsNodeActive))
                    {
                        //tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)(m_mapActivePlane[coord_y, coord_x] & (MapActiveType)0b0011_1100);
                        tileEdgyTypePlane[coord_y, coord_x] &= 0b00000000_00000000;
                        tileEdgyTypePlane[coord_y, coord_x] = (TileEdgyType)MapActiveType.BIsNodeActive;

                        if (coord_y - 1 >= 0 && !m_mapActivePlane[coord_y - 1, coord_x].HasFlag(MapActiveType.BIsNodeActive))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsTopEdge;
                        }
                        if (coord_y + 1 < fullMapSize.y && !m_mapActivePlane[coord_y + 1, coord_x].HasFlag(MapActiveType.BIsNodeActive))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsBottomEdge;
                        }
                        if (coord_x - 1 >= 0 && !m_mapActivePlane[coord_y, coord_x - 1].HasFlag(MapActiveType.BIsNodeActive))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsLeftEdge;
                        }
                        if (coord_x + 1 < fullMapSize.x && !m_mapActivePlane[coord_y, coord_x + 1].HasFlag(MapActiveType.BIsNodeActive))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsRightEdge;
                        }
                    }

                    //뒤로 넘어가는 타일
                    if (m_mapActivePlane[coord_y, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                    {
                        //tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)(m_mapActivePlane[coord_y, coord_x] & (MapActiveType)0b0011_1100);
                        tileEdgyTypePlane[coord_y, coord_x] &= 0b00000000_00000000;
                        tileEdgyTypePlane[coord_y, coord_x] = (TileEdgyType)MapActiveType.BIsNodeIsGateToBack;

                        if (coord_y - 1 >= 0 && !m_mapActivePlane[coord_y - 1, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsTopEdge;
                        }
                        if (coord_y + 1 < fullMapSize.y && !m_mapActivePlane[coord_y + 1, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsBottomEdge;
                        }
                        if (coord_x - 1 >= 0 && !m_mapActivePlane[coord_y, coord_x - 1].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsLeftEdge;
                        }
                        if (coord_x + 1 < fullMapSize.x && !m_mapActivePlane[coord_y, coord_x + 1].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsRightEdge;
                        }
                    }

                    // 뒤로 넘어가는 타일 바닥
                    //if (m_mapActivePlane[coord_y, coord_x].HasFlag(MapActiveType.BIsNodeIsGateBottomEdge))
                    //{
                    //    tileEdgyTypePlane[coord_y, coord_x] &= 0b00000000_00000000;
                    //    tileEdgyTypePlane[coord_y, coord_x] = TileEdgyType.StairToGoBackLayer;
                    //}

                    // 앞에서 넘어오는 타일
                    if (m_frontMapActivePlane != null && m_frontMapActivePlane[coord_y, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                    {
                        //tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)(m_frontMapActivePlane[coord_y, coord_x] & (MapActiveType)0b0011_1100);
                        tileEdgyTypePlane[coord_y, coord_x] &= 0b00000000_00000000;
                        tileEdgyTypePlane[coord_y, coord_x] = TileEdgyType.Front;

                        if (coord_y - 1 >= 0 && !m_frontMapActivePlane[coord_y - 1, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsTopEdge;
                        }
                        if (coord_y + 1 < fullMapSize.y && !m_frontMapActivePlane[coord_y + 1, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsBottomEdge;
                        }
                        if (coord_x - 1 >= 0 && !m_frontMapActivePlane[coord_y, coord_x - 1].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsLeftEdge;
                        }
                        if (coord_x + 1 < fullMapSize.x && !m_frontMapActivePlane[coord_y, coord_x + 1].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                        {
                            tileEdgyTypePlane[coord_y, coord_x] |= (TileEdgyType)MapActiveType.BIsNodeIsRightEdge;
                        }
                    }

                    // 앞에서 넘어오는 타일 바닥
                    //if (m_layerIndex - 1 >= 0 && m_frontMapActivePlane[coord_y, coord_x].HasFlag(MapActiveType.BIsNodeIsGateBottomEdge))
                    //{
                    //    tileEdgyTypePlane[coord_y, coord_x] &= 0b00000000_00000000;
                    //    tileEdgyTypePlane[coord_y, coord_x] = TileEdgyType.StairToGoFrontLayer;
                    //}
                }
            }

            m_tileEdgyDetectionOutput = new TileEdgyDetectionOutput()
            {
                TileEdgyTypePlane = tileEdgyTypePlane
            };

            m_manualResetEvent.Set();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(in bool bisDispose)
        {
            if (bisDispose)
            {
                m_manualResetEvent = null;
                m_tileEdgyDetectionOutput = null;
            }
        }
    }

    public static class TileEdgyDetector
    {
        public sealed class TileEdgyDetectionInput
        {
            public required Vector3Int MapSize { get; set; }
            public required Vector3Int SingleChunkSize { get; set; }
            public required Vector2Int SingleRoomSize { get; set; }

            public required List<MapActiveType[,]> MapActiveCube { get; set; }
        }
        public sealed class TileEdgyDetectionOutput
        {
            private List<TileEdgyType[,]> m_tileEdgyTypeCube;


            public TileEdgyDetectionOutput()
            {
                m_tileEdgyTypeCube = new List<TileEdgyType[,]>();
            }

            public List<TileEdgyType[,]> TileEdgyTypeCube
            {
                get
                {
                    return m_tileEdgyTypeCube;
                }
            }
        }


        private static List<TileEdgyLayerDetector> m_tileEdgyLayerDetectors = new List<TileEdgyLayerDetector>();


        public static TileEdgyDetectionOutput DetectTileEdgy(in TileEdgyDetectionInput tileEdgyDetectionInput)
        {
            int layerCount = tileEdgyDetectionInput.MapSize.y * tileEdgyDetectionInput.SingleChunkSize.y;

            List<ManualResetEvent> manualResetEvents = new List<ManualResetEvent>();
            int nextStartIndex = 0;
            while(true)
            {
                bool bisEnd = false;
                for (int index = nextStartIndex; index < layerCount; index++)
                {
                    ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                    manualResetEvents.Add(manualResetEvent);

                    TileEdgyLayerDetector.TileEdgyDetectionInput inputData = new TileEdgyLayerDetector.TileEdgyDetectionInput()
                    {
                        MapSize = tileEdgyDetectionInput.MapSize,
                        SingleChunkSize = tileEdgyDetectionInput.SingleChunkSize,
                        SingleRoomSize = tileEdgyDetectionInput.SingleRoomSize,

                        FrontMapActivePlane = (index - 1 >= 0) ? tileEdgyDetectionInput.MapActiveCube[index - 1] : null,
                        MapActivePlane = tileEdgyDetectionInput.MapActiveCube[index],

                        LayerIndex = index,

                        ManualResetEvent = manualResetEvent
                    };

                    TileEdgyLayerDetector tileEdgyLayerDetector = new TileEdgyLayerDetector(inputData);
                    m_tileEdgyLayerDetectors.Add(tileEdgyLayerDetector);

                    ThreadPool.QueueUserWorkItem(DetectLater, tileEdgyLayerDetector);

                    if (manualResetEvents.Count == 64)
                    {
                        nextStartIndex = index + 1;
                        break;
                    }
                    if (index == layerCount - 1)
                    {
                        bisEnd = true;
                    }
                }

                if (manualResetEvents.Count == 0)
                {
                    break;
                }

                WaitHandle.WaitAll(manualResetEvents.ToArray());
                manualResetEvents.Clear();

                if (bisEnd)
                {
                    break;
                }
            }

            TileEdgyDetectionOutput tileEdgyDetectionOutput = new TileEdgyDetectionOutput();
            for(int layerIndex = 0; layerIndex < layerCount; layerIndex++)
            {
                tileEdgyDetectionOutput.TileEdgyTypeCube.Add(m_tileEdgyLayerDetectors[layerIndex].TileEdgyOutput.TileEdgyTypePlane);
            }

            Console.WriteLine("Tile Edgy Detection Done");

            return tileEdgyDetectionOutput;
        }

        private static void DetectLater(object detectorObject)
        {
            TileEdgyLayerDetector tileEdgyLayerDetector = detectorObject as TileEdgyLayerDetector;

            tileEdgyLayerDetector.DetectEdgy();
        }

        public static void Dispose()
        {
            foreach(TileEdgyLayerDetector tileEdgyLayerDetector in m_tileEdgyLayerDetectors)
            {
                tileEdgyLayerDetector.Dispose();
            }
            m_tileEdgyLayerDetectors.Clear();
            m_tileEdgyLayerDetectors = null;
        }
    }
}