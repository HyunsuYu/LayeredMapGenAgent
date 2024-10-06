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

            public string BasicMapGenOutputPath;
            public string TileEdgyOutputPath;
        }

        public static void Main(string[] args)
        {
            //int num = 26486;
            //var tempValues = DataMutiBitSaveFactors.GetTwoChannelMultiBit(num / 32767.0f);

            //Console.WriteLine(System.Math.Ceiling(DataMutiBitSaveFactors.GetTwoChannelRestoredValue(tempValues) * 32767.0f));
            //return;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ChiefMapGenerationInput chiefMapGenerationInput = null;
            try
            {
                Console.WriteLine(args[0]);
                Console.WriteLine();

                chiefMapGenerationInput = JsonConvert.DeserializeObject<ChiefMapGenerationInput>(args[0]);
                //chiefMapGenerationInput = JsonConvert.DeserializeObject<ChiefMapGenerationInput>("{\"AbstractInputData\":{\"SingleChunkSize\":{\"x\":5,\"y\":3,\"z\":5,\"magnitude\":7.68114567,\"sqrMagnitude\":59},\"MapSize\":{\"x\":25,\"y\":1,\"z\":25,\"magnitude\":65.95453,\"sqrMagnitude\":4350},\"SingleRoomSize\":{\"x\":14,\"y\":14,\"magnitude\":9.899495,\"sqrMagnitude\":98},\"AreaNameTable\":{}},\"BasicMapInputData\":{\"MaxTryCountRatio\":0.001,\"BrushSize\":{\"Item1\":1,\"Item2\":3},\"MainWayFillPercent\":0.15,\"SubWayFillPercent\":0.25,\"PenetratingWayCountRate\":0.001,\"PenetratingWayFillPercent\":0.1},\"BasicMapGenOutputPath\":\"C:/Storage/Sandbox/Unity/UnTitled_LayeredMapGenTool/Assets/StreamingAssets/LayeredMapGeneration/OutputData/BasicPathOutputData_\",\"TileEdgyOutputPath\":\"C:/Storage/Sandbox/Unity/UnTitled_LayeredMapGenTool/Assets/StreamingAssets/LayeredMapGeneration/OutputData/TileEdgyOutputData_\"}");
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

            Console.WriteLine("Basic Map Generation Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "ms");
            #endregion

            #region Region Selection

            #endregion

            #region Tile Edgy Detection
            TileEdgyDetector.TileEdgyDetectionInput tileEdgyDetectionInput = new TileEdgyDetector.TileEdgyDetectionInput()
            {
                MapSize = chiefMapGenerationInput.AbstractInputData.MapSize,
                SingleChunkSize = chiefMapGenerationInput.AbstractInputData.SingleChunkSize,
                SingleRoomSize = chiefMapGenerationInput.AbstractInputData.SingleRoomSize,

                MapActiveCube = basicMapGenOutput.MapActiveCube,
            };

            TileEdgyDetector.TileEdgyDetectionOutput tileEdgyDetectionOutput = TileEdgyDetector.DetectTileEdgy(tileEdgyDetectionInput);

            Console.WriteLine("Tile Edgy Detection Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "ms");
            #endregion

            Vector3Int fullMapSize = new Vector3Int()
            {
                x = chiefMapGenerationInput.AbstractInputData.MapSize.x * chiefMapGenerationInput.AbstractInputData.SingleChunkSize.x * chiefMapGenerationInput.AbstractInputData.SingleRoomSize.x,
                y = chiefMapGenerationInput.AbstractInputData.MapSize.y,
                z = chiefMapGenerationInput.AbstractInputData.MapSize.z * chiefMapGenerationInput.AbstractInputData.SingleChunkSize.z * chiefMapGenerationInput.AbstractInputData.SingleRoomSize.y
            };

            string directoryPath = Path.GetDirectoryName(chiefMapGenerationInput.BasicMapGenOutputPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            #region Create Basic Map Png Image
            {
                List<RawBitmap> rawBitmaps = new List<RawBitmap>();
                for (int index = 0; index < basicMapGenOutput.MapActiveCube.Count; index++)
                {
                    RawBitmap rawBitmap = new RawBitmap(fullMapSize.x, fullMapSize.z);
                    for (int coord_z = 0; coord_z < fullMapSize.z; coord_z++)
                    {
                        for (int coord_x = 0; coord_x < fullMapSize.x; coord_x++)
                        {
                            //rawBitmap.SetPixel(coord_x, coord_z,
                            //                   new RawColor((byte)((basicMapGenOutput.MapActiveCube[index][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeActive)) ? 255 : 0),
                            //                                (byte)((basicMapGenOutput.MapActiveCube[index][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack)) ? 255 : 0),
                            //                                (byte)255));

                            var values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)basicMapGenOutput.MapActiveCube[index][coord_z, coord_x] / (float)byte.MaxValue);
                            rawBitmap.SetPixel(coord_x, coord_z, new RawColor((byte)(values.Item1 * 255.0f), (byte)(values.Item2 * 255.0f), 255));
                        }
                    }
                    rawBitmaps.Add(rawBitmap);
                }

                for (int index = 0; index < rawBitmaps.Count; index++)
                {
                    using SKBitmap bmp = SKBitmap.Decode(rawBitmaps[index].GetBitmapBytes());
                    using SKFileWStream fileStream = new SKFileWStream(chiefMapGenerationInput.BasicMapGenOutputPath + index.ToString() + ".png");
                    bmp.Encode(fileStream, SKEncodedImageFormat.Png, 100);
                }
            }
            #endregion

            #region Create Tile Edgy Detection Png Image
            {
                List<RawBitmap> rawBitmaps = new List<RawBitmap>();
                for (int index = 0; index < tileEdgyDetectionOutput.TileEdgyTypeCube.Count; index++)
                {
                    RawBitmap rawBitmap = new RawBitmap(fullMapSize.x, fullMapSize.z);
                    for (int coord_z = 0; coord_z < fullMapSize.z; coord_z++)
                    {
                        for (int coord_x = 0; coord_x < fullMapSize.x; coord_x++)
                        {
                            var values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)tileEdgyDetectionOutput.TileEdgyTypeCube[index][coord_z, coord_x] / 1024.0f);
                            rawBitmap.SetPixel(coord_x, coord_z, new RawColor((byte)(values.Item1 * 255.0f), (byte)(values.Item2 * 255.0f), 255));
                        }
                    }
                    rawBitmaps.Add(rawBitmap);
                }

                for (int index = 0; index < rawBitmaps.Count; index++)
                {
                    using SKBitmap bmp = SKBitmap.Decode(rawBitmaps[index].GetBitmapBytes());
                    using SKFileWStream fileStream = new SKFileWStream(chiefMapGenerationInput.TileEdgyOutputPath + index.ToString() + ".png");
                    bmp.Encode(fileStream, SKEncodedImageFormat.Png, 100);
                }
            }
            #endregion

            //File.WriteAllText(chiefMapGenerationInput.BasicMapGenOutputPath, JsonConvert.SerializeObject(basicMapGenOutput));

            BasicMapGenerator.Dispose();

            TileEdgyDetector.Dispose();

            stopwatch.Stop();
            Console.WriteLine("Basic Map Generation Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "ms");
        }
    }
}