using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class PrefabController : MonoBehaviour {
    //プレファブの場所
    string prefabDirectory = "Assets/Resources/Prefab/";

    //橋のプレファブのセーブ
    public void savePrefab(GameObject obj) {
        UnityEditor.PrefabUtility.CreatePrefab(prefabDirectory + "00.prefab", obj);
        UnityEditor.AssetDatabase.SaveAssets();
    }

    //橋とステージのプレファブのロード、設置
    public GameObject loadPrefab(string prefabName) {
        GameObject Pre = (GameObject)Resources.Load<GameObject>("Prefab/" + prefabName);
        return Instantiate(Pre);
    }
}
