using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour {
    //Rayとの当たり判定をレイヤーで設定
    public LayerMask layerMask;
    public GameObject pointPrefab;



    void Update() {
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
            } else if (CreateDirector.state == 2) {
                GetComponent<CreateDirector>().Click(null);
            }
        }
    }

}
