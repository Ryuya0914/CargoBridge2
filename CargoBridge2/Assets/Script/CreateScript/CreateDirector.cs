using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//TitleからstateName, cost
//Play のとき start()にloadPrefab("00")

public class CreateDirector : MonoBehaviour {
    static public int cost = 10000;
    static public int cost_BackUp = 10000;
    static public string stageName = "01";
    static public int state = 10;   //0 プレイシーン、　1 始点決定前、　2 始点決定後  10：タイトルシーン
    static public int buildState = 0; //0 wolk, 1 wood 
    public GameObject[] BridgePrefab; //橋のプレファブ
    public GameObject pointPrefab; //pointのプレファブ
    GameObject point1 = null, point2 = null, bridge = null; //選択中のpointと橋
    Vector2 MousePos;
    public GameObject subPoint;
    GameObject Stage;
    GameObject costLabel;

    void Start() {
        Stage = GetComponent<PrefabController>().loadPrefab("00");
        if (state == 10) {
            GameObject obj2 = GetComponent<PrefabController>().loadPrefab(stageName);
            obj2.transform.parent = Stage.transform;
        }
        state = 1;
        costLabel = GameObject.Find("Cost");
        UICon();
        subPoint.transform.parent = Stage.transform;
    }

    void Update() {
        //マウスの位置取得
        Vector3 mousePos3 = Input.mousePosition;
        mousePos3.z = 10;
        MousePos = (Vector2)Camera.main.ScreenToWorldPoint(mousePos3);

        //生成前の橋の位置を動かす
        if (state == 2) {
            MoveBridge();
        }
    }

    //pointがクリックされたときにオブジェクトが送られてくる
    public void Click(GameObject obj) {
        if (state == 1) {
            if (obj.GetComponent<Point>().Check()) {
                point1 = obj;
                bridge = Instantiate(BridgePrefab[buildState], Stage.transform);
                state = 2;
            }
        } else if (state == 2) {

            if (obj == point1) {        //終点が始点と同じところを指定された時
                Destroy(bridge);
                Reset();
            } else {                    //終点が違うpointを指定された時
                if (obj != null && MoveCheck(obj)) {
                    if (obj.GetComponent<Point>().Check()) {
                        point2 = obj;
                        Connection();
                    }
                } else {   //終点がなにもないところを指定された時
                    Vector2 pointPos = MoveBridge();
                    if (pointPos.x >= 20) {
                        Destroy(bridge);
                        Reset();
                    } else {
                        point2 = subPoint;
                        subPoint = Instantiate(pointPrefab, Stage.transform);
                        subPoint.transform.position = new Vector2(10, 0);
                        point2.transform.position = pointPos;

                        Connection();
                    }
                }
            } 
            UICon();
        }
    }

    //現在の操作を取り消す
    void Reset() {
        point1 = null;
        point2 = null;
        state = 1;
    }

    //橋をpointに固定する
    void Connection() {
        switch (buildState) {
            case 0:
                bridge.GetComponent<Walk>().Cargo(point1, point2);
                break;
            case 1:
                bridge.GetComponent<Wood>().Cargo(point1, point2);
                break;
            case 2:
                break;
            case 3:
                break;
        }

        point1.GetComponent<Point>().ConnectionBridge(bridge);
        point2.GetComponent<Point>().ConnectionBridge(bridge);
        Reset();
        UICon();
    }
    
    //橋の位置を動かす
    Vector2 MoveBridge() {
        Vector2 bridgePos = new Vector2();
        switch (buildState) {
            case 0:
                bridgePos = bridge.GetComponent<Walk>().Move(point1.transform.position, MousePos);
                break;
            case 1:
                bridgePos = bridge.GetComponent<Wood>().Move(point1.transform.position, MousePos);
                break;
            case 2:
                break;
            case 3:
                break;
        }
        return bridgePos;
    }

    //橋の長さチェック
    bool MoveCheck(GameObject obj2) {
        switch (buildState) {
            case 0:
                return bridge.GetComponent<Walk>().MoveCheck(point1.transform.position, obj2.transform.position);
            case 1:
                return bridge.GetComponent<Wood>().MoveCheck(point1.transform.position, obj2.transform.position);
            case 2:
                break;
            case 3:
                break;
        }
        return false;
    }

    //UI変更
    public void UICon() {
        costLabel.GetComponent<Text>().text = "cost : " + cost.ToString("D4"); 
    }

    //シーン変更
    public void GoOtherScene(string nextSceneName) {
        if (nextSceneName == "PlayScene") {
            state = 0;
        } else if (nextSceneName == "TitleScene" || nextSceneName == "SelectScene" || nextSceneName == "CreateScene") {
            state = 10;
            Stage.transform.DetachChildren();
            cost = cost_BackUp;
        }
        GetComponent<PrefabController>().savePrefab(Stage);
        SceneManager.LoadScene(nextSceneName);
    }
    static public void cameTitleScene(int stagecost, string stagename) {
        cost = stagecost;
        cost_BackUp = cost;
        stageName = stagename;
    }

    //buildState切り替え
    public void BuildStateChange(int num) {
        buildState = num;
        if (state == 2) Destroy(bridge);
        Reset();
    }

    //消しゴム機能
    public void Eraser(GameObject obj) {
        Destroy(obj);
         UICon();
        
    }
}
