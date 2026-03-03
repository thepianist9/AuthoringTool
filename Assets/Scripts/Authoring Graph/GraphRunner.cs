using AuthoringTool.Blocks;
using UnityEngine;

namespace AuthoringTool.Graphs
{
    public class GraphRunner: MonoBehaviour
    {
        public BlockGraph graph;

        // In GraphRunner
        [TextArea(3, 10)]
        public string graphStatus;


        [ContextMenu("Import Graph")]
        public void Import() {

            BlockGraph graph = GraphSerializer.ImportGraph(Application.persistentDataPath + "/graph.json");
            if (graph != null)
            {
                this.graph = graph;
                UpdateGraphStatus();
                Debug.Log("Graph imported successfully. Blocks: {graph.Blocks.Count}");
            }
            else
            {
                this.graph = null;
                Debug.LogError("Failed to import graph. Graph is null.");
            }
        }
        [ContextMenu("Export Graph")]
        public void Export( ) {
            if(graph != null)
            {
                GraphSerializer.ExportGraph(graph, Application.persistentDataPath + "/graph.json");
                UpdateGraphStatus();
                Debug.Log($"Graph exported successfully. Blocks: {graph.Blocks.Count}");
            }
            else
            {
                Debug.LogError("Graph is null. Cannot export.");
            }
        }
        [ContextMenu("Execute Graph")]
        public void ExecuteGraph()
        {
            if(graph != null)
                graph.Execute();
            else
                Debug.LogError("Graph is null. Cannot execute.");
        }

        [ContextMenu("Clear Scene")]
        public void ClearScene()
        {
            // Find and destroy all objects tagged as "GraphObject"
            GameObject[] graphObjects = GameObject.FindGameObjectsWithTag("GraphObject");
            foreach (GameObject obj in graphObjects)
            {
                DestroyImmediate(obj);
            }
            Debug.Log($"Cleared {graphObjects.Length} scene objects.");
        }

        [ContextMenu("Create Test Graph 1")]
        public void CreateTestGraph1()
        {
            this.graph = TestGraphFactory.CreateTestGraph1();
            UpdateGraphStatus();
        }

        [ContextMenu("Create Test Graph 2")]
        public void CreateTestGraph2()
        {
            this.graph = TestGraphFactory.CreateTestGraph2();
            UpdateGraphStatus();
        }

        [ContextMenu("Create Test Graph 3")]
        public void CreateTestGraph3()
        {
            this.graph = TestGraphFactory.CreateTestGraph3();
            UpdateGraphStatus();
        }

        private void UpdateGraphStatus()
        {
            if (graph == null)
            {
                graphStatus = "No graph loaded.";
                return;
            }

            graphStatus = $"Blocks: {graph.Blocks.Count}\nEntry: {graph.EntryBlockId}";
            foreach (var block in graph.Blocks.Values)
                graphStatus += $"\n[{block.Id}] {block.GetType().Name} → {block.NextBlockId}";
        }
    }
}
