using LayeredMapGenAgent.Internal.Data;
using LayeredMapGenAgent.Internal.Manager.BasicMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Manager
{
    internal static class MiddleLayersGenAgent
    {
        public sealed class MapGenInputData
        {
            public required Vector3Int MapSize;
            public required Vector3Int SingleChunkSize;
            public required Vector2Int SingleRoomSize;

            public required MiddleLayersInputDataSpec MiddleLayersInputDataSpec;

            public required List<MapActiveType[,]> MapActiveCube;
        }
        public sealed class MiddleLayersOutput
        {
            public required List<byte[,]> MiddleLayersResultPlanes;
        }


        public static MiddleLayersOutput CalculateMiddleLayers(in MapGenInputData mapGenInputData)
        {
            Vector2Int realMapSize = new Vector2Int()
            {
                x = mapGenInputData.MapSize.x * mapGenInputData.SingleChunkSize.x * mapGenInputData.SingleRoomSize.x,
                y = mapGenInputData.MapSize.z * mapGenInputData.SingleChunkSize.z * mapGenInputData.SingleRoomSize.y
            };
            int layerCount = mapGenInputData.MapSize.y * mapGenInputData.SingleChunkSize.y;

            List<byte[,]> middleLayersResultPlanes = new List<byte[,]>();
            for (int coord_y = 0; coord_y < layerCount; coord_y++)
            {
                middleLayersResultPlanes.Add(new byte[realMapSize.y, realMapSize.x]);

                for (int middleLayerIndex = 0; middleLayerIndex < mapGenInputData.MiddleLayersInputDataSpec.CurLayerMiddleLayerDepth; middleLayerIndex++)
                {
                    for (int coord_z = 0; coord_z < realMapSize.y; coord_z++)
                    {
                        for (int coord_x = 0; coord_x < realMapSize.x; coord_x++)
                        {
                            // First Middle Layer
                            if (middleLayerIndex == 0)
                            {
                                if (!mapGenInputData.MapActiveCube[coord_y][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                                {
                                    bool bisMiddleNodeDraw = false;

                                    if (coord_z - 1 >= 0 && mapGenInputData.MapActiveCube[coord_y][coord_z - 1, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_z + 1 < realMapSize.y && mapGenInputData.MapActiveCube[coord_y][coord_z + 1, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_x - 1 >= 0 && mapGenInputData.MapActiveCube[coord_y][coord_z, coord_x - 1].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_x + 1 < realMapSize.x && mapGenInputData.MapActiveCube[coord_y][coord_z, coord_x + 1].HasFlag(MapActiveType.BIsNodeIsGateToBack))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }

                                    if (bisMiddleNodeDraw)
                                    {
                                        SetNodeActive(ref middleLayersResultPlanes[coord_y][coord_z, coord_x], middleLayerIndex);
                                        //middleLayersResultPlanes[middleLayerIndex][coord_z, coord_x] = true;

                                        //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item1.Add(new Vector3Int(pos.x, pos.y, 0));
                                        ////m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetTilebase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z)));
                                        //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetCompactMainTileBase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z), perlinNoiseValue));
                                    }
                                }
                                if (mapGenInputData.MapActiveCube[coord_y][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeActive))
                                {
                                    bool bisMiddleNodeDraw = false;

                                    if (coord_z - 1 >= 0 && !mapGenInputData.MapActiveCube[coord_y][coord_z - 1, coord_x].HasFlag(MapActiveType.BIsNodeActive))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_z + 1 < realMapSize.y && !mapGenInputData.MapActiveCube[coord_y][coord_z + 1, coord_x].HasFlag(MapActiveType.BIsNodeActive))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_x - 1 >= 0 && !mapGenInputData.MapActiveCube[coord_y][coord_z, coord_x - 1].HasFlag(MapActiveType.BIsNodeActive))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_x + 1 < realMapSize.x && !mapGenInputData.MapActiveCube[coord_y][coord_z, coord_x + 1].HasFlag(MapActiveType.BIsNodeActive))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }

                                    if (bisMiddleNodeDraw)
                                    {
                                        SetNodeActive(ref middleLayersResultPlanes[coord_y][coord_z, coord_x], middleLayerIndex);
                                        //middleLayersResultPlanes[middleLayerIndex][coord_z, coord_x] = true;

                                        //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item1.Add(new Vector3Int(pos.x, pos.y, 0));
                                        ////m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetTilebase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z)));
                                        //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetCompactMainTileBase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z), perlinNoiseValue));
                                    }
                                }
                                else
                                {
                                    SetNodeActive(ref middleLayersResultPlanes[coord_y][coord_z, coord_x], middleLayerIndex);
                                    //middleLayersResultPlanes[middleLayerIndex][coord_z, coord_x] = true;

                                    //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item1.Add(new Vector3Int(pos.x, pos.y, 0));
                                    ////m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetTilebase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z)));
                                    //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetCompactMainTileBase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z), perlinNoiseValue));
                                }
                            }
                            // After Middle Layers
                            else
                            {
                                if (!BCheckIsNodeActive(middleLayersResultPlanes[coord_y][coord_z, coord_x], middleLayerIndex - 1))
                                {
                                    bool bisMiddleNodeDraw = false;

                                    if (coord_z - 1 >= 0 && BCheckIsNodeActive(middleLayersResultPlanes[coord_y][coord_z - 1, coord_x], middleLayerIndex - 1))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_z + 1 < realMapSize.y && BCheckIsNodeActive(middleLayersResultPlanes[coord_y][coord_z + 1, coord_x], middleLayerIndex - 1))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_x - 1 >= 0 && BCheckIsNodeActive(middleLayersResultPlanes[coord_y][coord_z, coord_x - 1], middleLayerIndex - 1))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }
                                    else if (coord_x + 1 < realMapSize.x && BCheckIsNodeActive(middleLayersResultPlanes[coord_y][coord_z, coord_x + 1], middleLayerIndex - 1))
                                    {
                                        bisMiddleNodeDraw = true;
                                    }

                                    if (bisMiddleNodeDraw)
                                    {
                                        SetNodeActive(ref middleLayersResultPlanes[coord_y][coord_z, coord_x], middleLayerIndex);
                                        //middleLayersResultPlanes[middleLayerIndex][coord_z, coord_x] = true;

                                        //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item1.Add(new Vector3Int(pos.x, pos.y, 0));
                                        ////m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetTilebase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z)));
                                        //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetCompactMainTileBase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z), perlinNoiseValue));
                                    }
                                }
                                else
                                {
                                    SetNodeActive(ref middleLayersResultPlanes[coord_y][coord_z, coord_x], middleLayerIndex);
                                    //middleLayersResultPlanes[middleLayerIndex][coord_z, coord_x] = true;

                                    //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item1.Add(new Vector3Int(pos.x, pos.y, 0));
                                    ////m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetTilebase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z)));
                                    //m_curLayerMiddleLayerSetTileRequests[middleLayerIndex].Item2.Add(GetCompactMainTileBase(TileGroupInputDataSpec.TileEdgyType.Nor, new Vector3Int(coord_x, m_layerIndex, coord_z), perlinNoiseValue));
                                }
                            }
                        }
                    }
                }
            }

            return new MiddleLayersOutput
            {
                MiddleLayersResultPlanes = middleLayersResultPlanes
            };
        }

        private static bool BCheckIsNodeActive(in byte value, in int targetMiddleLayerIndex)
        {
            return (value & (0b0000_0001 << targetMiddleLayerIndex)) != 0;
        }
        private static void SetNodeActive(ref byte value, in int targetMiddleLayerIndex)
        {
            value |= (byte)(0b0000_0001 << targetMiddleLayerIndex);
        }
    }
}