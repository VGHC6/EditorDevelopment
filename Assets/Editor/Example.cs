using UnityEditor;
using UnityEngine;

public class Example : EditorWindow
{
    [MenuItem("Tools/Example")]
    public static void ShowWindow()
    {
        GetWindow<Example>().Show();
    }

    public void OnGUI()
    {
        GUILayout.Label("Hello World");
        EditorGUILayout.Space();
        GUILayout.Button("Click Me");
    }
}
