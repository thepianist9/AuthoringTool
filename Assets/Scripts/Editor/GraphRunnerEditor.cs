using AuthoringTool.Graphs;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(GraphRunner))]
public class GraphRunnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GraphRunner runner = (GraphRunner)target;

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Test Graphs", EditorStyles.boldLabel);
        EditorGUILayout.Space(5);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create Test Graph 1")) runner.CreateTestGraph1();
        if (GUILayout.Button("Create Test Graph 2")) runner.CreateTestGraph2();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create Test Graph 3")) runner.CreateTestGraph3();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Graph View", EditorStyles.boldLabel);
        EditorGUILayout.Space(5);

        if (GUILayout.Button("Execute Graph")) runner.ExecuteGraph();

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Import/Export", EditorStyles.boldLabel);
        EditorGUILayout.Space(5);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Export Graph")) runner.Export();
        if (GUILayout.Button("Import Graph")) runner.Import();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Scene Management", EditorStyles.boldLabel);
        EditorGUILayout.Space(5);

        if (GUILayout.Button("Clear Scene")) runner.ClearScene();

    }
}