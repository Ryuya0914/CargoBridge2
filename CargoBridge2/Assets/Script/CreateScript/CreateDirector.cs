using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//TitleからstateName, cost
//Play のとき start()にloadPrefab("00")

public class CreateDirector : PlaySE {
    static public int cost = 10000;
    static public int state = 0;   //0 始点決定前、　1 始点決定後
    static public int buildState = 0; //0 wolk, 1 wood 
    public GameObject[] BridgePrefab; //橋のプレファブ
    public GameObject pointPrefab; //pointのプレファブ
    GameObject point1 = null, point2 = null, bridge = null; //選択中のpointと橋
    Vector2 MousePos;
    public GameObject subPoint;
    public GameObject Stage;
    public GameObject costLabel;

    void Start() {
        state = 0;
        cost = GameDirector.cost;
        CostLabelUpdate();
    }

    void Update() {
        //マウスの位置取得
        Vector3 mousePos3 = Input.mousePosition;
        mousePos3.z = 10;
        MousePos = (Vector2)Camera.main.ScreenToWorldPoint(mousePos3);

        //生成前の橋の位置を動かす
        if (state == 1) {
            MoveBridge();
        }
    }

    //pointがクリックされたときにオブジェクトが送られてくる
    public void Click(GameObject obj) {
        if (state == 0) {
            if (obj.GetComponent<Point>().Check()) {
                point1 = obj;
                bridge = Instantiate(BridgePrefab[buildState], Stage.transform);
                state = 1;
            }
        } else if (state == 1) {

            if (obj == point1) {        //終点が始点と同じところを指定された時
                PlayAudio(1);
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
                        PlayAudio(1);
                        Destroy(bridge);
                        Reset();
                    } else {
                        point2 = subPoint;
                        subPoint = Instantiate(pointPrefab, transform);
                        subPoint.transform.position = new Vector2(30, 0);
                        point2.transform.position = pointPos;
                        point2.transform.parent = Stage.transform;
                        Connection();
                    }
                }
            } 
            CostLabelUpdate();
        }
    }

    //現在の操作を取り消す
    void Reset() {
        point1 = null;
        point2 = null;
        state = 0;
    }

    //橋をpointに固定する
    void Connection() {
        PlayAudio(0);
        state = 0;
        bridge.GetComponent<Bridge>().Cargo(point1, point2);
        point1.GetComponent<Point>().ConnectionBridge(bridge);
        point2.GetComponent<Point>().ConnectionBridge(bridge);
        Reset();
        CostLabelUpdate();
    }
    
    //橋の位置を動かす
    Vector2 MoveBridge() {
        return bridge.GetComponent<Bridge>().Move(point1.transform.position, MousePos);
    }

    //橋の長さチェック
    bool MoveCheck(GameObject obj2) {
        return bridge.GetComponent<Bridge>().MoveCheck(point1.transform.position, obj2.transform.position);
    }

    //UI変更
    public void CostLabelUpdate() {
        costLabel.GetComponent<Text>().text = "cost : " + cost.ToString("D4"); 
    }

    //buildState切り替え
    public void BuildStateChange(int num) {
        buildState = num;
        if (state == 1) Destroy(bridge);
        Reset();
    }

    //消しゴム機能
    public void Eraser(GameObject obj) {
        if (state == 0) {
            PlayAudio(2);
            cost += obj.GetComponent<Bridge>().haveCost;
            Destroy(obj);
            CostLabelUpdate();
        }
    }

    //Play移行時
    public void GoPlay() {
        if (state == 1) {
            Destroy(bridge);
            Reset();
        }
    }
}
