using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : PlaySE {
    public GameObject CreateSet, PlaySet, Bridge, CroneBridge;
    static public int cost = 3000;
    static public string stageName = "01";
    static public int GameState = 0;
    public GameObject LoadUI;
    public GameObject LoadBar;

    void Awake() {
        GameState = 0;
    }

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
        Destroy(CroneBridge.transform.GetChild(0).gameObject);
        Instantiate(Bridge.gameObject, CroneBridge.transform);
    }

    //FadeInOut
    IEnumerator Fade() {
        LoadUI.SetActive(true);
        float Gage = 0f;
        Image Bar = LoadBar.GetComponent<Image>();

        PlayAudio(0);

        while (true) {
            Gage += Time.deltaTime;
            Bar.fillAmount = Gage / 1.5f;
            if (Bar.fillAmount >= 1f) {
                LoadUI.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }

    //StageSelectからステージの情報を受け取る
    static public void StageSet(int _cost, string _stageName) {
        cost = _cost;
        stageName = _stageName;
    }
}
