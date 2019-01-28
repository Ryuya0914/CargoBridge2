using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour {
    //Rayとの当たり判定をレイヤーで設定
    public LayerMask layerMask;
    public LayerMask layerMask2;
    public GameObject pointPrefab;
    Vector3 backMouseScreenPos = new Vector3(0, 0, 0);

    void Update() {
        //マウスの位置取得
        Vector3 nowMouseScreenPos = Input.mousePosition;
        //マウスのホイール入力値取得
        float wheelScroll = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButtonDown(0)) {
            //Rayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10, layerMask);
            //Rayとなにか衝突したときの処理
            if (hit.collider) {
                GameObject obj = hit.collider.gameObject;
                if (obj.tag == "Point" || obj.tag == "Ground") {
                    GetComponent<CreateDirector>().Click(obj);
                }
            } else if (CreateDirector.state == 1) {
                GetComponent<CreateDirector>().Click(null);
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            //Rayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10, layerMask2);
            //Rayとなにか衝突したときの処理
            if (hit.collider) {
                GameObject obj = hit.collider.gameObject;
                if (obj.tag == "Walk" || obj.tag == "Wood") {
                    GetComponent<CreateDirector>().Eraser(obj);
                }
            }
        }
        if (Input.GetMouseButton(2)) {
            Camera.main.GetComponent<CameraController>().Move(backMouseScreenPos - nowMouseScreenPos);
        }
        if (wheelScroll != 0) {
            Camera.main.GetComponent<CameraController>().Zoom(wheelScroll);
        }
        backMouseScreenPos = nowMouseScreenPos;
    }

}
