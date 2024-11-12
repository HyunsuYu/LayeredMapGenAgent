using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

using Newtonsoft.Json;

using LayeredMapGenAgent.Internal.Manager.BasicMap;
using LayeredMapGenAgent.Internal.Data;
using LayeredMapGenAgent.Public.Data;
using LayeredMapGenAgent.Internal.Functor;

using SkiaSharp;
using LayeredMapGenAgent.Internal.Manager;


namespace LayeredMapGenAgent.Public.Manager
{
    public class ChiefMapGenAgentManager
    {
        internal sealed class ChiefMapGenerationInput
        {
            public AbstractInputDataSpec AbstractInputData;
            public BasicMapInputDataSpec BasicMapInputData;
            public RegionSelectionInputDataSpec RegionSelectionInputData;

            public string BasicMapGenOutputPath;
            public string TileEdgyOutputPath;
            public string RegionSelectionOutputPath;
        }

        public static void Main(string[] args)
        {
            //{
            //    int num = 3;
            //    var tempValues = DataMutiBitSaveFactors.GetTwoChannelMultiBit(num / (float)byte.MaxValue);
            //    //tempValues = new Tuple<float, float>(tempValues.Item1 * 255.0f, tempValues.Item2 * 255.0f);
            //    tempValues = new Tuple<float, float>(2.0f, 194.0f);

            //    Console.WriteLine(tempValues.Item1 + ", " + tempValues.Item2);

            //    tempValues = new Tuple<float, float>(tempValues.Item1 / 255.0f, tempValues.Item2 / 255.0f);

            //    Console.WriteLine(tempValues.Item1 + ", " + tempValues.Item2);

            //    float value = DataMutiBitSaveFactors.GetTwoChannelRestoredValue(tempValues);
            //    Console.WriteLine("Value : " + value);
            //    Console.WriteLine(System.Math.Ceiling(value * (float)byte.MaxValue));
            //}
            //{
            //    Console.WriteLine("=====================================");
            //    int num = 1;
            //    var tempValues = DataMutiBitSaveFactors.GetTwoChannelMultiBit(num / (float)byte.MaxValue);
            //    tempValues = new Tuple<float, float>(tempValues.Item1 * 255.0f, tempValues.Item2 * 255.0f);

            //    Console.WriteLine(tempValues.Item1 + ", " + tempValues.Item2);

            //    tempValues = new Tuple<float, float>(tempValues.Item1 / 255.0f, tempValues.Item2 / 255.0f);

            //    Console.WriteLine(tempValues.Item1 + ", " + tempValues.Item2);

            //    float value = DataMutiBitSaveFactors.GetTwoChannelRestoredValue(tempValues);
            //    Console.WriteLine("Value : " + value);
            //    Console.WriteLine(System.Math.Ceiling(value * (float)byte.MaxValue));
            //}
            //return;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ChiefMapGenerationInput chiefMapGenerationInput = null;
            try
            {
                Console.WriteLine(args[0]);
                Console.WriteLine();

                chiefMapGenerationInput = JsonConvert.DeserializeObject<ChiefMapGenerationInput>(args[0]);
                //chiefMapGenerationInput = JsonConvert.DeserializeObject<ChiefMapGenerationInput>("{\"AbstractInputData\":{\"SingleChunkSize\":{\"x\":1,\"y\":1,\"z\":1,\"magnitude\":65.95453,\"sqrMagnitude\":4350},\"MapSize\":{\"x\":5,\"y\":3,\"z\":5,\"magnitude\":7.68114567,\"sqrMagnitude\":59},\"SingleRoomSize\":{\"x\":7,\"y\":7,\"magnitude\":19.79899,\"sqrMagnitude\":392},\"AreaNameTable\":{\"51b33455-081e-4878-8758-a67b0d1102e2\":\"clear\",\"688c40e5-9b15-47ee-82ed-75ae48879149\":\"test\"}},\"BasicMapInputData\":{\"MaxTryCountRatio\":0.001,\"BrushSize\":{\"Item1\":1,\"Item2\":3},\"MainWayFillPercent\":0.15,\"SubWayFillPercent\":0.25,\"PenetratingWayCountRate\":0.001,\"PenetratingWayFillPercent\":0.1},\"RegionSelectionInputData\":{\"BaseColor\":{\"x\":0.5,\"y\":0.5,\"z\":0.5},\"SingleRegionDatas\":[{\"RegionName\":\"clear\",\"RegionID\":\"51b33455-081e-4878-8758-a67b0d1102e2\",\"RegionBlendColor\":{\"x\":0.5,\"y\":0.5,\"z\":0.5},\"IdealSpawnPos\":{\"x\":0.3,\"y\":0.5,\"z\":0.0},\"WeightVector\":{\"x\":2.0,\"y\":1.0,\"z\":1.0}},{\"RegionName\":\"test\",\"RegionID\":\"688c40e5-9b15-47ee-82ed-75ae48879149\",\"RegionBlendColor\":{\"x\":0.5,\"y\":0.5,\"z\":0.5},\"IdealSpawnPos\":{\"x\":1.0,\"y\":1.0,\"z\":1.0},\"WeightVector\":{\"x\":1.0,\"y\":1.0,\"z\":1.0}}]},\"BasicMapGenOutputPath\":\"C:/Storage/Sandbox/Unity/UnTitled_LayeredMapGenTool/Assets/StreamingAssets/LayeredMapGeneration/OutputData/BasicPathOutputData_\",\"TileEdgyOutputPath\":\"C:/Storage/Sandbox/Unity/UnTitled_LayeredMapGenTool/Assets/StreamingAssets/LayeredMapGeneration/OutputData/TileEdgyOutputData_\",\"RegionSelectionOutputPath\":\"C:/Storage/Sandbox/Unity/UnTitled_LayeredMapGenTool/Assets/StreamingAssets/LayeredMapGeneration/OutputData/RegionSelectionOutputData_\"}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            {
                int layerIndex = 0;
                while (true)
                {
                    string fileName = chiefMapGenerationInput.BasicMapGenOutputPath + layerIndex.ToString() + ".png";
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                        File.Delete(fileName + ".meta");
                        layerIndex++;
                    }
                    else
                    {
                        break;
                    }
                }

                layerIndex = 0;
                while (true)
                {
                    string fileName = chiefMapGenerationInput.BasicMapGenOutputPath + "_Region_" + layerIndex.ToString() + ".png";
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                        File.Delete(fileName + ".meta");
                        layerIndex++;
                    }
                    else
                    {
                        break;
                    }
                }

                layerIndex = 0;
                while (true)
                {
                    string fileName = chiefMapGenerationInput.TileEdgyOutputPath + layerIndex.ToString() + ".png";
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                        File.Delete(fileName + ".meta");
                        layerIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            #region Basic Map
            BasicMapGenerator.MapGenInputData basicMapGenInputData = new BasicMapGenerator.MapGenInputData()
            {
                MapSize = chiefMapGenerationInput.AbstractInputData.MapSize,
                SingleChunkSize = chiefMapGenerationInput.AbstractInputData.SingleChunkSize,
                SingleRoomSize = chiefMapGenerationInput.AbstractInputData.SingleRoomSize,

                MaxTryCountRatio = chiefMapGenerationInput.BasicMapInputData.MaxTryCountRatio,
                BrushSize = chiefMapGenerationInput.BasicMapInputData.BrushSize,
                MainWayFillPercent = chiefMapGenerationInput.BasicMapInputData.MainWayFillPercent,
                SubWayFillPercent = chiefMapGenerationInput.BasicMapInputData.SubWayFillPercent,

                PenetratingWayCountRate = chiefMapGenerationInput.BasicMapInputData.PenetratingWayCountRate,
                PenetratingWayFillPercent = chiefMapGenerationInput.BasicMapInputData.PenetratingWayFillPercent,
            };

            BasicMapGenerator.BasicMapGenOutput basicMapGenOutput = BasicMapGenerator.GenerateMap(basicMapGenInputData);

            Console.WriteLine("Basic Map Generation Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "s");
            #endregion

            #region Region Selection
            RegionSelector.MapGenInputData regionSelectionInputData = new RegionSelector.MapGenInputData()
            {
                MapSize = chiefMapGenerationInput.AbstractInputData.MapSize,
                SingleChunkSize = chiefMapGenerationInput.AbstractInputData.SingleChunkSize,
                SingleRoomSize = chiefMapGenerationInput.AbstractInputData.SingleRoomSize,

                RegionSelectionInputDataSpec = chiefMapGenerationInput.RegionSelectionInputData,

                MapActiveCube = basicMapGenOutput.MapActiveCube,
            };

            RegionSelector.RegionSelectionOutput regionSelectionOutput = RegionSelector.CalculateRegion(regionSelectionInputData);

            Console.WriteLine("Region Selection Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "s");
            #endregion

            #region Tile Edgy Detection
            //TileEdgyDetector.TileEdgyDetectionInput tileEdgyDetectionInput = new TileEdgyDetector.TileEdgyDetectionInput()
            //{
            //    MapSize = chiefMapGenerationInput.AbstractInputData.MapSize,
            //    SingleChunkSize = chiefMapGenerationInput.AbstractInputData.SingleChunkSize,
            //    SingleRoomSize = chiefMapGenerationInput.AbstractInputData.SingleRoomSize,

            //    MapActiveCube = basicMapGenOutput.MapActiveCube,
            //};

            //TileEdgyDetector.TileEdgyDetectionOutput tileEdgyDetectionOutput = TileEdgyDetector.DetectTileEdgy(tileEdgyDetectionInput);

            //Console.WriteLine("Tile Edgy Detection Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "s");
            #endregion

            Vector3Int fullMapSize = new Vector3Int()
            {
                x = chiefMapGenerationInput.AbstractInputData.MapSize.x * chiefMapGenerationInput.AbstractInputData.SingleChunkSize.x * chiefMapGenerationInput.AbstractInputData.SingleRoomSize.x,
                y = chiefMapGenerationInput.AbstractInputData.MapSize.y * chiefMapGenerationInput.AbstractInputData.SingleChunkSize.y,
                z = chiefMapGenerationInput.AbstractInputData.MapSize.z * chiefMapGenerationInput.AbstractInputData.SingleChunkSize.z * chiefMapGenerationInput.AbstractInputData.SingleRoomSize.y
            };

            string directoryPath = Path.GetDirectoryName(chiefMapGenerationInput.BasicMapGenOutputPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            #region Create Basic Map Png Image
            {
                int layerCount = mapGenInputData.MapSize.y * mapGenInputData.SingleChunkSize.y;

                List<ManualResetEvent> manualResetEvents = new List<ManualResetEvent>();
                int nextStartIndex = 0;
                while (true)
                {
                    bool bisEnd = false;
                    for (int index = nextStartIndex; index < layerCount; index++)
                    {
                        ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                        manualResetEvents.Add(manualResetEvent);

                        BasicMapLayerGenerator.BasicMapLayerGeneratorInput inputData = new BasicMapLayerGenerator.BasicMapLayerGeneratorInput()
                        {
                            MapSize = mapGenInputData.MapSize,
                            SingleChunkSize = mapGenInputData.SingleChunkSize,
                            SingleRoomSize = mapGenInputData.SingleRoomSize,

                            MaxTryCountRatio = mapGenInputData.MaxTryCountRatio,
                            BrushSize = mapGenInputData.BrushSize,
                            MainWayFillPercent = mapGenInputData.MainWayFillPercent,
                            SubWayFillPercent = mapGenInputData.SubWayFillPercent,

                            LayerIndex = index,

                            ManualResetEvent = manualResetEvent
                        };

                        BasicMapLayerGenerator basicMapLayerGenerator = new BasicMapLayerGenerator(inputData);
                        m_basicMapLayerGenerators.Add(basicMapLayerGenerator);

                        ThreadPool.QueueUserWorkItem(CalculateLayer, basicMapLayerGenerator);

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

                Console.WriteLine("Start Create Basic Map Png Image");
                //Dictionary<float, int> count = new Dictionary<float, int>();
                List<SKBitmap> rawBitmaps = new List<SKBitmap>();
                for (int index = 0; index < basicMapGenOutput.MapActiveCube.Count; index++)
                {
                    SKBitmap rawBitmap = new SKBitmap(fullMapSize.x, fullMapSize.z);
                    for (int coord_z = 0; coord_z < fullMapSize.z; coord_z++)
                    {
                        for (int coord_x = 0; coord_x < fullMapSize.x; coord_x++)
                        {
                            //rawBitmap.SetPixel(coord_x, coord_z,
                            //                   new RawColor((byte)((basicMapGenOutput.MapActiveCube[index][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeActive)) ? 255 : 0),
                            //                                (byte)((basicMapGenOutput.MapActiveCube[index][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack)) ? 255 : 0),
                            //                                (byte)255));

                            var values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)basicMapGenOutput.MapActiveCube[index][coord_z, coord_x] / (float)byte.MaxValue);
                            rawBitmap.SetPixel(coord_x, coord_z, new SKColor((byte)(values.Item1 * 255.0f), (byte)(values.Item2 * 255.0f), 255));

                            //float countValue = DataMutiBitSaveFactors.GetTwoChannelRestoredValue(values);
                            //if (!count.ContainsKey(countValue))
                            //{
                            //    count.Add(countValue, 0);
                            //}
                            //count[countValue]++;
                        }
                    }
                    rawBitmaps.Add(rawBitmap);
                }
                //foreach (var item in count)
                //{
                //    Console.WriteLine("Value: " + item.Key + " Count: " + item.Value);
                //}

                for (int index = 0; index < rawBitmaps.Count; index++)
                {
                    using SKFileWStream fileStream = new SKFileWStream(chiefMapGenerationInput.BasicMapGenOutputPath + index.ToString() + ".png");
                    rawBitmaps[index].Encode(fileStream, SKEncodedImageFormat.Png, 100);
                }
                Console.WriteLine("End Create Basic Map Png Image");
            }
            #endregion

            #region Create Region Map Png Image
            {
                Console.WriteLine("Start Create Region Map Png Image");
                //var singleRegionRainbowTable = RegionSelectionInputDataSpec.GetSingleRegionDataRainbowTable(chiefMapGenerationInput.RegionSelectionInputData.SingleRegionDatas);
                List<SKBitmap> rawBitmaps = new List<SKBitmap>();
                //Dictionary<int, int> countTable = new Dictionary<int, int>();
                for (int index = 0; index < regionSelectionOutput.RegionCube.Count; index++)
                {
                    SKBitmap rawBitmap = new SKBitmap(fullMapSize.x, fullMapSize.z);
                    for (int coord_z = 0; coord_z < fullMapSize.z; coord_z++)
                    {
                        for (int coord_x = 0; coord_x < fullMapSize.x; coord_x++)
                        {
                            //int key = (singleRegionRainbowTable.Keys.ToList().IndexOf(regionSelectionOutput.RegionCube[coord_z, index, coord_x]) + 2);
                            //var values = DataMutiBitSaveFactors.GetTwoChannelMultiBit(key / (float)(singleRegionRainbowTable.Keys.Count + 2));
                            var values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)regionSelectionOutput.RegionCube[index][coord_z, coord_x] / (float)byte.MaxValue);
                            rawBitmap.SetPixel(coord_x, coord_z, new SKColor((byte)(values.Item1 * 255.0f), (byte)(values.Item2 * 255.0f), 255));

                            //if(!countTable.ContainsKey(key))
                            //{
                            //    countTable.Add(key, 0);
                            //}
                            //countTable[key]++;
                        }
                    }
                    rawBitmaps.Add(rawBitmap);
                }

                //foreach (var item in countTable)
                //{
                //    Console.WriteLine("Region " + item.Key + " Count: " + item.Value);
                //}

                for (int index = 0; index < rawBitmaps.Count; index++)
                {
                    //using SKBitmap bmp = SKBitmap.Decode(rawBitmaps[index].GetBitmapBytes());
                    using SKFileWStream fileStream = new SKFileWStream(chiefMapGenerationInput.BasicMapGenOutputPath + "_Region_" + index.ToString() + ".png");
                    rawBitmaps[index].Encode(fileStream, SKEncodedImageFormat.Png, 100);
                }
                Console.WriteLine("End Create Region Map Png Image");
            }
            #endregion

            #region Create Tile Edgy Detection Png Image
            //{
            //    List<RawBitmap> rawBitmaps = new List<RawBitmap>();
            //    for (int index = 0; index < tileEdgyDetectionOutput.TileEdgyTypeCube.Count; index++)
            //    {
            //        RawBitmap rawBitmap = new RawBitmap(fullMapSize.x, fullMapSize.z);
            //        for (int coord_z = 0; coord_z < fullMapSize.z; coord_z++)
            //        {
            //            for (int coord_x = 0; coord_x < fullMapSize.x; coord_x++)
            //            {
            //                var values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)tileEdgyDetectionOutput.TileEdgyTypeCube[index][coord_z, coord_x] / 1024.0f);
            //                rawBitmap.SetPixel(coord_x, coord_z, new RawColor((byte)(values.Item1 * 255.0f), (byte)(values.Item2 * 255.0f), 255));
            //            }
            //        }
            //        rawBitmaps.Add(rawBitmap);
            //    }

            //    for (int index = 0; index < rawBitmaps.Count; index++)
            //    {
            //        using SKBitmap bmp = SKBitmap.Decode(rawBitmaps[index].GetBitmapBytes());
            //        using SKFileWStream fileStream = new SKFileWStream(chiefMapGenerationInput.TileEdgyOutputPath + index.ToString() + ".png");
            //        bmp.Encode(fileStream, SKEncodedImageFormat.Png, 100);
            //    }
            //}
            #endregion

            //File.WriteAllText(chiefMapGenerationInput.BasicMapGenOutputPath, JsonConvert.SerializeObject(basicMapGenOutput));

            BasicMapGenerator.Dispose();

            TileEdgyDetector.Dispose();

            stopwatch.Stop();
            Console.WriteLine("Basic Map Generation Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "s");
        }
    }
}