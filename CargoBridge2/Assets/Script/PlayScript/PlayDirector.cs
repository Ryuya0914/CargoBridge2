using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDirector : MonoBehaviour {

    void Start() {
        Invoke("BridgeStart", 2.0f);
        GetComponent<PrefabController>().loadPrefab("00");
    }

    void BridgeStart() {
        GameObject[] bridges = GameObject.FindGameObjectsWithTag("Walk");
        for (int i = 0; i < bridges.Length; i++) {
            bridges[i].GetComponent<Walk>().ObjectModeChange();
        }
        bridges = GameObject.FindGameObjectsWithTag("Wood");
        for (int i = 0; i < bridges.Length; i++) {
            bridges[i].GetComponent<Wood>().ObjectModeChange();
        }
    }
}
