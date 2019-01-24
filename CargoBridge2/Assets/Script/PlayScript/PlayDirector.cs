using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDirector : MonoBehaviour {

    void Start() {
        GetComponent<PrefabController>().loadPrefab("00");
        Invoke("BridgeStart", 2.0f);
    }

    void BridgeStart() {
        GameObject[] bridges = GameObject.FindGameObjectsWithTag("Walk");
        foreach (GameObject obj in bridges) {
            obj.GetComponent<Bridge>().ObjectModeChange();
        }
        bridges = GameObject.FindGameObjectsWithTag("Wood");
        foreach (GameObject obj in bridges) {
            obj.GetComponent<Bridge>().ObjectModeChange();
        }
    }
}
