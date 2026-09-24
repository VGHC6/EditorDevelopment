using System;
using UnityEditor;
using UnityEngine;
//节点自定义额外选项，Hierarchy是层级窗口
[InitializeOnLoad]
public class CustomExtraOptions
{
    static CustomExtraOptions()
    {
        EditorApplication.hierarchyWindowItemOnGUI += DrawCustomExtraOptions;
    }

    static void DrawCustomExtraOptions(int id, Rect rect)
    {
        DrawPlaceRect(id, rect);
        DrawAddInformationRect(id);
        DrawInfomation(id, rect, string.Empty);
    }

    static Rect RrawRect(float x, float y, int size)
    {
        return new Rect(x, y, size, size);
    }

    //绘制按钮矩形
    static void DrawButtonRect(int id, float x, float y, int size)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(id) as GameObject;
        if (gameObject)
        {
            Rect button = RrawRect(x, y, size);
            gameObject.SetActive(GUI.Toggle(button, gameObject.activeSelf, string.Empty));
        }
    }

    //放置
    static void DrawPlaceRect(int id, Rect rect)
    {
        DrawButtonRect(id, rect.x - 20, rect.y - 2, 20);
    }

    //信息展示
    static void DrawInformationRect(float x, float y, int size, string name, GameObject gameObject
                                    , Action action, string tooltip)
    {
        if (gameObject)
        {
            GUIStyle style = new GUIStyle();
            style.fixedHeight = 0;
            style.fixedWidth = 0;
            style.stretchHeight = true;
            style.stretchWidth = true;

            Rect rect = RrawRect(x, y, size);
            Texture t = Resources.Load(name) as Texture;//加载纹理
            GUIContent content = new GUIContent(t, tooltip);//创建GUI内容
            GUIContent guicontent = new GUIContent(content);
            guicontent.image = t;
            guicontent.text = "";
            guicontent.tooltip = tooltip;
            bool isClicked = GUI.Button(rect, guicontent, style);
            if (isClicked)
            {
                action?.Invoke();
            }
        }
    }

    //得到信息
    static void DrawInfomation(int id, Rect rect, string tooltip)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(id) as GameObject;
        if (gameObject)
        {
            bool hasInformation = gameObject.GetComponent<ImformationDescripts>();
            if (hasInformation)
            {
                ImformationDescripts infoScripts = gameObject.GetComponent<ImformationDescripts>();
                if (infoScripts)
                {
                    tooltip = infoScripts.information;
                }
            }
        }
        DrawInformationRect(rect.x + 150, rect.y, 20, "info", gameObject, () => { }, tooltip);
    }

    //添加信息的组件
    static void DrawAddInformationRect(int id)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(id) as GameObject;
        if (!gameObject)
        {
            return;
        }

        bool hasInformation = gameObject.GetComponent<ImformationDescripts>();
        if (!hasInformation)
        {
            gameObject.AddComponent<ImformationDescripts>();
        }
    }
}
