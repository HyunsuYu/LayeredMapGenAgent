using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LayeredMapGenAgent.Internal.Data;
using LayeredMapGenAgent.Internal.Manager.BasicMap;


namespace LayeredMapGenAgent.Internal.Manager
{
    #region
    //internal sealed class RegionLayerSelector : IDisposable
    //{
    //    public sealed class RegionLayerSelectorInput
    //    {
    //        public required Vector3Int MapSize;
    //        public required Vector3Int SingleChunkSize;
    //        public required Color BaseColor;

    //        public required List<LayerSingleRegionData> SingleRegionDatas;
    //    }
    //    public sealed class RegionLayerSelectorOutput : IDisposable
    //    {
    //        public int[,] RegionSelectCube;


    //        ~RegionLayerSelectorOutput()
    //        {
    //            Dispose(false);
    //        }

    //        public void Dispose()
    //        {
    //            Dispose(true);
    //        }

    //        private void Dispose(in bool bisDispose)
    //        {
    //            if(bisDispose)
    //            {
    //                RegionSelectCube = null;
    //            }
    //        }
    //    }

    //    public sealed class LayerSingleRegionData
    //    {
    //        public required Vector2Int IdealSpawnPos;
    //        public required float ReductionRate;
    //    }


    //    private Vector3Int m_mapSize, m_singleChunkSize;
    //    private Color m_baseColor;

    //    private List<LayerSingleRegionData> m_singleRegionDatas;

    //    private RegionLayerSelectorOutput m_regionLayerSelectorOutput;


    //    public RegionLayerSelector(in RegionLayerSelectorInput regionLayerSelectorInput)
    //    {
    //        m_mapSize = regionLayerSelectorInput.MapSize;
    //        m_singleChunkSize = regionLayerSelectorInput.SingleChunkSize;

    //        m_baseColor = regionLayerSelectorInput.BaseColor;

    //        m_singleRegionDatas = regionLayerSelectorInput.SingleRegionDatas;
    //    }
    //    ~RegionLayerSelector()
    //    {
    //        Dispose(false);
    //    }

    //    public RegionLayerSelectorOutput RegionOutput
    //    {
    //        get
    //        {
    //            return m_regionLayerSelectorOutput;
    //        }
    //    }

    //    public void CalculateRegion()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //    }

    //    private void Dispose(in bool bisDispose)
    //    {
    //        if(bisDispose)
    //        {
    //            m_singleRegionDatas.Clear();
    //            m_singleRegionDatas = null;

    //            m_regionLayerSelectorOutput.Dispose();
    //            m_regionLayerSelectorOutput = null;
    //        }
    //    }
    //}

    //public static class RegionSelector
    //{
    //    public sealed class MapGenInputData
    //    {
    //        public required Vector3Int MapSize;
    //        public required Vector3Int SingleChunkSize;
    //        public required Vector2Int SingleRoomSize;

    //        public required Vector3 BaseColor;

    //        public required List<RegionSelectionInputDataSpec.SingleRegionData> SingleRegionDatas;

    //        public required List<MapActiveType[,]> MapActiveCube;
    //    }
    //    public sealed class RegionSelectionOutput
    //    {
    //        public int[,,] RegionCube;
    //    }

    //    internal sealed class SimpleRegionData
    //    {
    //        public Vector3Int SpawnPos;
    //        public float ReductionRate;

    //        public int SingleRegionID;
    //    }


    //    //private static List<RegionLayerSelector> m_regionLayerSelectors = new List<RegionLayerSelector>();


    //    public static RegionSelectionOutput CalculateRegion(in MapGenInputData mapGenInputData)
    //    {
    //        int layerCount = mapGenInputData.MapSize.y * mapGenInputData.SingleChunkSize.y;

    //        Random random = new Random();
    //        Vector2Int realMapSize = new Vector2Int()
    //        {
    //            x = mapGenInputData.MapSize.x * mapGenInputData.SingleChunkSize.x * mapGenInputData.SingleRoomSize.x,
    //            y = mapGenInputData.MapSize.z * mapGenInputData.SingleChunkSize.z * mapGenInputData.SingleRoomSize.y
    //        };
    //        Dictionary<int, List<Tuple<Vector2Int, RegionSelectionInputDataSpec.SingleRegionData>>> settledSingleRegionDataTable = new Dictionary<int, List<Tuple<Vector2Int, RegionSelectionInputDataSpec.SingleRegionData>>>();
    //        foreach (RegionSelectionInputDataSpec.SingleRegionData singleRegionData in mapGenInputData.SingleRegionDatas)
    //        {
    //            Vector3Int idsalSpawnPos = new Vector3Int()
    //            {
    //                x = (int)(realMapSize.x * (singleRegionData.IdealSpawnPos.x + (float)(random.NextDouble() - 0.5f) / 0.05f)),
    //                y = (int)(layerCount * (singleRegionData.IdealSpawnPos.y + (float)(random.NextDouble() - 0.5f) / 0.05f)),
    //                z = (int)(realMapSize.y * (singleRegionData.IdealSpawnPos.z + (float)(random.NextDouble() - 0.5f) / 0.05f))
    //            };

    //            float minDistance = float.MaxValue;
    //            int minDistanceLayerIndex = 0;
    //            Vector2Int minDistancePos = Vector2Int.zero;

    //            for (int layerIndex = 0; layerIndex < layerCount; layerIndex++)
    //            {
    //                for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
    //                {
    //                    for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
    //                    {
    //                        if (mapGenInputData.MapActiveCube[layerIndex][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeActive))
    //                        {
    //                            float curDistance = Vector3Int.Distance(idsalSpawnPos, new Vector3Int(coord_x, layerIndex, coord_z));

    //                            if (curDistance < minDistance)
    //                            {
    //                                minDistance = curDistance;
    //                                minDistanceLayerIndex = layerIndex;
    //                                minDistancePos = new Vector2Int(coord_x, coord_z);
    //                            }
    //                        }
    //                    }
    //                }
    //            }

    //            if (!settledSingleRegionDataTable.ContainsKey(minDistanceLayerIndex))
    //            {
    //                settledSingleRegionDataTable.Add(minDistanceLayerIndex, new List<Tuple<Vector2Int, RegionSelectionInputDataSpec.SingleRegionData>>());
    //            }
    //            settledSingleRegionDataTable[minDistanceLayerIndex].Add(new Tuple<Vector2Int, RegionSelectionInputDataSpec.SingleRegionData>(minDistancePos, singleRegionData));
    //        }

    //        List<SimpleRegionData> simpleRegionDatas = new List<SimpleRegionData>();
    //        foreach (int layerIndex in settledSingleRegionDataTable.Keys)
    //        {
    //            foreach (var item in settledSingleRegionDataTable[layerIndex])
    //            {
    //                simpleRegionDatas.Add(new SimpleRegionData()
    //                {
    //                    SpawnPos = new Vector3Int()
    //                    {
    //                        x = item.Item1.x,
    //                        y = layerIndex,
    //                        z = item.Item1.y
    //                    },
    //                    ReductionRate = item.Item2.ReductionRate,
    //                    SingleRegionID = item.Item2.RegionName.GetHashCode()
    //                });
    //            }
    //        }

    //        #region
    //        //List<ManualResetEvent> manualResetEvents = new List<ManualResetEvent>();
    //        //int nextStartIndex = 0;
    //        //while (true)
    //        //{
    //        //    bool bisEnd = false;
    //        //    for (int index = nextStartIndex; index < layerCount; index++)
    //        //    {
    //        //        ManualResetEvent manualResetEvent = new ManualResetEvent(false);
    //        //        manualResetEvents.Add(manualResetEvent);

    //        //        List<RegionLayerSelector.LayerSingleRegionData> layerSingleRegionDatas = new List<RegionLayerSelector.LayerSingleRegionData>();


    //        //        RegionLayerSelector.RegionLayerSelectorInput inputData = new RegionLayerSelector.RegionLayerSelectorInput()
    //        //        {
    //        //            MapSize = mapGenInputData.MapSize,
    //        //            SingleChunkSize = mapGenInputData.SingleChunkSize,

    //        //            BaseColor = mapGenInputData.BaseColor,
    //        //            SingleRegionDatas = layerSingleRegionDatas
    //        //        };

    //        //        RegionLayerSelector regionLayerSelector = new RegionLayerSelector(inputData);
    //        //        m_regionLayerSelectors.Add(regionLayerSelector);

    //        //        ThreadPool.QueueUserWorkItem(CalculateLayer, regionLayerSelector);

    //        //        if (manualResetEvents.Count == 64)
    //        //        {
    //        //            nextStartIndex = index + 1;
    //        //            break;
    //        //        }
    //        //        if (index == layerCount - 1)
    //        //        {
    //        //            bisEnd = true;
    //        //        }
    //        //    }

    //        //    if (manualResetEvents.Count == 0)
    //        //    {
    //        //        break;
    //        //    }

    //        //    WaitHandle.WaitAll(manualResetEvents.ToArray());
    //        //    manualResetEvents.Clear();

    //        //    if (bisEnd)
    //        //    {
    //        //        break;
    //        //    }
    //        //}
    //        #endregion

    //        Dictionary<int, string> singleRegionDataRainbowTable = RegionSelectionInputDataSpec.GetSingleRegionDataRainbowTable(mapGenInputData.SingleRegionDatas);
    //        return new RegionSelectionOutput()
    //        {
    //            RegionCube = CalculateRegion(mapGenInputData.MapActiveCube, simpleRegionDatas, layerCount, realMapSize, singleRegionDataRainbowTable)
    //        };
    //    }

    //    //private static void CalculateLayer(object selectorobject)
    //    //{
    //    //    RegionLayerSelector regionLayerSelector = selectorobject as RegionLayerSelector;

    //    //    regionLayerSelector.CalculateRegion();
    //    //}

    //    private static int[,,] CalculateRegion(in List<MapActiveType[,]> mapActiveCube, in List<SimpleRegionData> simpleRegionDatas, in int layerCount, in Vector2Int realMapSize, in Dictionary<int, string> singleRegionDataRainbowTable)
    //    {
    //        Dictionary<int, bool> regionCalculateionStateTable = new Dictionary<int, bool>();
    //        foreach (int id in singleRegionDataRainbowTable.Keys)
    //        {
    //            regionCalculateionStateTable.Add(id, false);
    //        }

    //        int[,,] regionCube = new int[realMapSize.y, layerCount, realMapSize.x];
    //        float[,,] regionInfluenceDCube = new float[realMapSize.y, layerCount, realMapSize.x];
    //        Dictionary<int, Queue<Vector3Int>> regionSearchTable = new Dictionary<int, Queue<Vector3Int>>();
    //        foreach (SimpleRegionData simpleRegionData in simpleRegionDatas)
    //        {
    //            //regionCube[simpleRegionData.SpawnPos.z, simpleRegionData.SpawnPos.y, simpleRegionData.SpawnPos.x] = simpleRegionData.SingleRegionID;

    //            if (!regionSearchTable.ContainsKey(simpleRegionData.SingleRegionID))
    //            {
    //                regionSearchTable.Add(simpleRegionData.SingleRegionID, new Queue<Vector3Int>());
    //                regionSearchTable[simpleRegionData.SingleRegionID].Enqueue(simpleRegionData.SpawnPos);
    //            }
    //        }

    //        while (true)
    //        {
    //            foreach (SimpleRegionData simpleRegionData in simpleRegionDatas)
    //            {
    //                if (regionSearchTable[simpleRegionData.SingleRegionID].Count == 0)
    //                {
    //                    regionCalculateionStateTable[simpleRegionData.SingleRegionID] = true;
    //                    continue;
    //                }

    //                if (!regionCalculateionStateTable[simpleRegionData.SingleRegionID])
    //                {
    //                    PaintRegion(mapActiveCube,
    //                                ref regionCube, ref regionInfluenceDCube, regionSearchTable,
    //                                simpleRegionData.ReductionRate, simpleRegionData.SingleRegionID,
    //                                layerCount, realMapSize);
    //                }
    //            }

    //            if (!regionCalculateionStateTable.Values.Contains(false))
    //            {
    //                break;
    //            }
    //        }

    //        return regionCube;
    //    }
    //    private static void PaintRegion(in List<MapActiveType[,]> mapActiveCube,
    //                                    ref int[,,] regionCube, ref float[,,] regionInfluenceCube, in Dictionary<int, Queue<Vector3Int>> regionSearchTable,
    //                                    in float reductionRate, in int singleRegionID,
    //                                    in int layerCount, in Vector2Int realMapSize)
    //    {
    //        Vector3Int pos = regionSearchTable[singleRegionID].Dequeue();
    //        if (regionCube[pos.z, pos.y, pos.x] == singleRegionID)
    //        {
    //            return;
    //        }

    //        Random random = new Random();
    //        int radius = (int)(1.0f / reductionRate) + (1.0f % reductionRate > 0.0f ? 1 : 0);

    //        for (int coord_z = (pos.z - radius >= 0 ? pos.z - radius : 0); coord_z <= (pos.z + radius < realMapSize.y - 1 ? pos.z + radius : realMapSize.y - 1); coord_z++)
    //        {
    //            for (int coord_y = (pos.y - radius >= 0 ? pos.y - radius : 0); coord_y <= (pos.y + radius < layerCount - 1 ? pos.y + radius : layerCount - 1); coord_y++)
    //            {
    //                for (int coord_x = (pos.x - radius >= 0 ? pos.x - radius : 0); coord_x <= (pos.x + radius < realMapSize.x - 1 ? pos.x + radius : realMapSize.x - 1); coord_x++)
    //                {
    //                    float curPosInfluence = 1.0f - Vector3Int.Distance(pos, new Vector3Int(coord_x, coord_y, coord_z)) * reductionRate + (float)(random.NextDouble() * 0.1f);

    //                    if (regionInfluenceCube[coord_z, coord_y, coord_x] < 1.0f && regionInfluenceCube[coord_z, coord_y, coord_x] < curPosInfluence)
    //                    {
    //                        regionCube[coord_z, coord_y, coord_x] = singleRegionID;
    //                        regionInfluenceCube[coord_z, coord_y, coord_x] = curPosInfluence;

    //                        // Edgy
    //                        if (curPosInfluence - reductionRate <= 0.0f && mapActiveCube[coord_y][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeActive))
    //                        {
    //                            regionSearchTable[singleRegionID].Enqueue(new Vector3Int(coord_x, coord_y, coord_z));
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    #endregion

    public static class RegionSelector
    {
        public sealed class MapGenInputData
        {
            public required Vector3Int MapSize;
            public required Vector3Int SingleChunkSize;
            public required Vector2Int SingleRoomSize;

            public required RegionSelectionInputDataSpec RegionSelectionInputDataSpec;

            public required List<MapActiveType[,]> MapActiveCube;
        }
        public sealed class RegionSelectionOutput
        {
            public List<byte[,]> RegionCube;
        }


        public static RegionSelectionOutput CalculateRegion(in MapGenInputData mapGenInputData)
        {
            Vector2Int realMapSize = new Vector2Int()
            {
                x = mapGenInputData.MapSize.x * mapGenInputData.SingleChunkSize.x * mapGenInputData.SingleRoomSize.x,
                y = mapGenInputData.MapSize.z * mapGenInputData.SingleChunkSize.z * mapGenInputData.SingleRoomSize.y
            };
            int layerCount = mapGenInputData.MapSize.y * mapGenInputData.SingleChunkSize.y;

            List<byte[,]> resultCube = new List<byte[,]>();
            for (int coord_y = 0; coord_y < layerCount; coord_y++)
            {
                resultCube.Add(new byte[realMapSize.y, realMapSize.x]);
                for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                {
                    for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                    {
                        if(mapGenInputData.MapActiveCube[coord_y][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeActive))
                        {
                            int singleRegionIndex = -1;
                            float minDistance = float.MaxValue;
                            foreach (var item in mapGenInputData.RegionSelectionInputDataSpec.SingleRegionDatas)
                            {
                                float curDistance = GetWeightedDistance(new Vector3()
                                                                        {
                                                                            x = item.IdealSpawnPos.x * realMapSize.x,
                                                                            y = item.IdealSpawnPos.y * layerCount,
                                                                            z = item.IdealSpawnPos.z * realMapSize.y
                                                                        },
                                                                        new Vector3Int(coord_x, coord_y, coord_z),
                                                                        item.WeightVector);

                                if (curDistance < minDistance)
                                {
                                    minDistance = curDistance;
                                    singleRegionIndex = mapGenInputData.RegionSelectionInputDataSpec.SingleRegionDatas.IndexOf(item);
                                }
                            }

                            resultCube[coord_y][coord_z, coord_x] = (byte)(singleRegionIndex + 1);
                        }
                    }
                }
            }

            return new RegionSelectionOutput()
            {
                RegionCube = resultCube
            };
        }

        private static float GetWeightedDistance(in Vector3 pos_0, in Vector3Int pos_1, in Vector3 weightVector)
        {
            Vector3 vec = new Vector3()
            {
                x = Math.Abs(pos_0.x - pos_1.x) * weightVector.x,
                y = Math.Abs(pos_0.y - pos_1.y) * weightVector.y,
                z = Math.Abs(pos_0.z - pos_1.z) * weightVector.z
            };

            return vec.magnitude;
        }
    }
}