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


namespace LayeredMapGenAgent.Public.Manager
{
    public class ChiefMapGenAgentManager
    {
        internal sealed class ChiefMapGenerationInput
        {
            public AbstractInputDataSpec AbstractInputData;
            public BasicMapInputDataSpec BasicMapInputData;

            public string BasicMapGenOutputPath;
        }

        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ChiefMapGenerationInput chiefMapGenerationInput = null;
            try
            {
                Console.WriteLine(args[0]);
                Console.WriteLine();

                chiefMapGenerationInput = JsonConvert.DeserializeObject<ChiefMapGenerationInput>(args[0]);
                //chiefMapGenerationInput = JsonConvert.DeserializeObject<ChiefMapGenerationInput>("{\"AbstractInputData\":{\"SingleChunkSize\":{\"x\":5,\"y\":3,\"z\":5,\"magnitude\":7.68114567,\"sqrMagnitude\":59},\"MapSize\":{\"x\":30,\"y\":20,\"z\":45,\"magnitude\":28.7228127,\"sqrMagnitude\":825},\"SingleRoomSize\":{\"x\":7,\"y\":7,\"magnitude\":9.899495,\"sqrMagnitude\":98},\"AreaNameTable\":{}},\"BasicMapInputData\":{\"MaxTryCountRatio\":0.001,\"BrushSize\":{\"Item1\":1,\"Item2\":3},\"MainWayFillPercent\":0.15,\"SubWayFillPercent\":0.25,\"PenetratingWayCountRate\":0.001,\"PenetratingWayFillPercent\":0.1},\"BasicMapGenOutputPath\":\"C:/Storage/Sandbox/Unity/UnTitled_LayeredMapGenTool/Assets/StreamingAssets/LayeredMapGeneration/OutputData/BasicPathOutputData_\"}");
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
            }

            #region Basic Map
            BasicMapGenerator.MapGenInputData basicMapGenInputData = new BasicMapGenerator.MapGenInputData()
            {
                m_mapSize = chiefMapGenerationInput.AbstractInputData.MapSize,
                m_singleChunkSize = chiefMapGenerationInput.AbstractInputData.SingleChunkSize,
                m_singleRoomSize = chiefMapGenerationInput.AbstractInputData.SingleRoomSize,

                m_maxTryCountRatio = chiefMapGenerationInput.BasicMapInputData.MaxTryCountRatio,
                m_brushSize = chiefMapGenerationInput.BasicMapInputData.BrushSize,
                m_mainWayFillPercent = chiefMapGenerationInput.BasicMapInputData.MainWayFillPercent,
                m_subWayFillPercent = chiefMapGenerationInput.BasicMapInputData.SubWayFillPercent,

                m_penetratingWayCountRate = chiefMapGenerationInput.BasicMapInputData.PenetratingWayCountRate,
                m_penetratingWayFillPercent = chiefMapGenerationInput.BasicMapInputData.PenetratingWayFillPercent,
            };

            BasicMapGenerator.BasicMapGenOutput basicMapGenOutput = BasicMapGenerator.GenerateMap(basicMapGenInputData);

            Console.WriteLine("Basic Map Generation Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "ms");

            Vector3Int fullMapSize = new Vector3Int()
            {
                x = basicMapGenInputData.m_mapSize.x * basicMapGenInputData.m_singleChunkSize.x * basicMapGenInputData.m_singleRoomSize.x,
                y = basicMapGenInputData.m_mapSize.y,
                z = basicMapGenInputData.m_mapSize.z * basicMapGenInputData.m_singleChunkSize.z * basicMapGenInputData.m_singleRoomSize.y
            };

            ////for (int coord_y = 0; coord_y < fullMapSize.y; coord_y++)
            ////{
            //for (int coord_z = 0; coord_z < fullMapSize.z; coord_z++)
            //{
            //    for (int coord_x = 0; coord_x < fullMapSize.x; coord_x++)
            //    {
            //        if (basicMapGenOutput.MapActiveCube[0][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeIsGateToBack))
            //        {
            //            Console.Write("★ ");
            //        }
            //        else if (basicMapGenOutput.MapActiveCube[0][coord_z, coord_x].HasFlag(MapActiveType.BIsNodeActive))
            //        {
            //            Console.Write("◼️");
            //        }
            //        else
            //        {
            //            Console.Write("◻️");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
            //Console.WriteLine();
            //Console.WriteLine();
            ////}

            string directoryPath = Path.GetDirectoryName(chiefMapGenerationInput.BasicMapGenOutputPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            List<RawBitmap> rawBitmaps = new List<RawBitmap>();
            for(int index = 0; index < basicMapGenOutput.MapActiveCube.Count; index++)
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

                        var values = DataMutiBitSaveFactors.GetTwoChannelMultiBit((int)basicMapGenOutput.MapActiveCube[index][coord_z, coord_x] / 255.0f);
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

            //File.WriteAllText(chiefMapGenerationInput.BasicMapGenOutputPath, JsonConvert.SerializeObject(basicMapGenOutput));

            BasicMapGenerator.Dispose();

            stopwatch.Stop();
            Console.WriteLine("Basic Map Generation Time: " + stopwatch.ElapsedMilliseconds / 1000.0f + "ms");
            #endregion
        }
    }
}