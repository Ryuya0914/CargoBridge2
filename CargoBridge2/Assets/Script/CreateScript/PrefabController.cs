using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PrefabController : MonoBehaviour {
    //プレファブの場所
    string prefabDirectory = "Assets/Resources/Prefab/";

    //橋とステージのプレファブのロード、設置
    public GameObject loadPrefab(string prefabName, GameObject _parent) {
        GameObject Pre = (GameObject)Resources.Load<GameObject>("Prefab/" + prefabName);
        return Instantiate(Pre, _parent.transform);
    }
}
