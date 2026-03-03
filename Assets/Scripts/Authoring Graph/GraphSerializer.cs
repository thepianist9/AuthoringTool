using AuthoringTool.Blocks;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace AuthoringTool.Graphs
{
    public class GraphSerializer
    {
        public static BlockGraph ImportGraph(string path)
        {

            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path);
                BlockGraph graphData = JsonConvert.DeserializeObject<BlockGraph>(jsonData, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                return graphData;
            }
            Debug.LogError("Graph is null. Cannot import.");
            return null;
        }
        public static void ExportGraph(BlockGraph graph, string path)
        {
            if (graph != null)
            {
                string json = JsonConvert.SerializeObject(graph, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                File.WriteAllText(path, json);
            }
            else
            {
                Debug.LogError("Graph is null. Cannot export.");
            }

        }

    }
}
