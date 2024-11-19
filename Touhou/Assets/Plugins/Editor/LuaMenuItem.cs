using UnityEditor;
using System.IO;

public class LuaMenuItem : Editor
{
    [MenuItem("Assets/Create/Lua Script")]
    private static void CreateLuaScript()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string fileName = "NewLuaScript.lua";
        int fileIndex = 0;
        while (File.Exists(Path.Combine(path, fileName)))
        {
            fileIndex++;
            fileName = "NewLuaScript" + fileIndex + ".lua";
        }

        string newFilePath = Path.Combine(path, fileName);
        File.Create(newFilePath).Dispose();
        AssetDatabase.Refresh();
    }

}