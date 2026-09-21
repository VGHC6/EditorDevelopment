using UnityEditor;
using UnityEngine;

[InitializeOnLoad]//在Unity加载时初始化
public class CoustomInformationOption
{
    static CoustomInformationOption()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;//在Hierarchy窗口中添加自定义信息
    }

//在Hierarchy窗口中添加自定义信息
    static void OnHierarchyWindowItemOnGUI(int id, Rect rect)
    {
        Debug.Log("Hierarchy窗口中添加自定义信息");
    }
}
