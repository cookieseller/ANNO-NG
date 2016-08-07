using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[ExecuteInEditMode]
public class CreatePrefab
{
    public static string prefabFolder = "Assets/Prefab/Map/Water/";
    public static string prefabPrefix = "Water";

    [MenuItem("MyMenu/Create Prefab from Folder")]
    static void createPrefab() {
        string path = EditorUtility.OpenFolderPanel("Folder", "", "");
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles("*.png");
        int i = 0;
        foreach (FileInfo file in files) {
            i++;
            Object prefab = PrefabUtility.CreateEmptyPrefab(prefabFolder + prefabPrefix + i.ToString() + ".prefab");
            
            GameObject obj = new GameObject();
            SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
            
            string filename = file.Name.Substring(0, file.Name.Length - 4);
            Sprite spr = Resources.Load<Sprite>(filename);
            renderer.sprite = Resources.Load<Sprite>(filename);
            PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
            Object.DestroyImmediate(obj);
        }
    }

    /*
    void Start() {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles("*.png");
        int i = 0;
        foreach (FileInfo file in files) {
            i++;
            Object prefab = EditorUtility.CreateEmptyPrefab(prefabFolder + prefabPrefix + i.ToString() + ".prefab");
            //EditorUtility.ReplacePrefab(t.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
        }
    }*/
}
