﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    public GameObject CreateSet, PlaySet, Bridge, CroneBridge;
    static public int cost = 3000;
    static public string stageName = "01";
    static public int GameState = 0;

    void Start() {
        StartCoroutine(Fade());
        GetComponent<PrefabController>().loadPrefab(stageName, Bridge);
    }

    //CreateとPlayを入れ替える
    public void ChangeMode() {
        StartCoroutine(Fade());
        if (GameState == 0) {       //Create → Play
            GameState = 1;
            Instantiate(Bridge, CroneBridge.transform);
            CreateSet.SetActive(false);
            PlaySet.SetActive(true);
        } else if (GameState == 1) {//Play → Create
            GameState = 0;
            Destroy(CroneBridge.transform.GetChild(0).gameObject);
            PlaySet.SetActive(false);
            CreateSet.SetActive(true);
        }
    }

    //TitleかSelectにシーン移行
    public void GoOtherScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    
    //作った橋をリセットする
    public void StageReset() {
        SceneManager.LoadScene("CreateScene");
    }

    //Playをリスタート
    public void ReStart() {
        StartCoroutine(Fade());
        Destroy(CroneBridge.transform.GetChild(0));
        Instantiate(Bridge.transform.GetChild(0), CroneBridge.transform);
    }

    //FadeInOut
    IEnumerator Fade() {
        float Gage = 0f;
        while (true) {
            Gage += Time.deltaTime;

            if (Gage > 10f) yield break;
            yield return null;
        }
    }

    //StageSelectからステージの情報を受け取る
    static public void StageSet(int _cost, string _stageName) {
        cost = _cost;
        stageName = _stageName;
    }
}
