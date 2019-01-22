using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    //Rayとの当たり判定をレイヤーで設定
    public LayerMask layerMask;

    void Update()
    {
        Debug.Log("a");

        if (Input.GetMouseButtonDown(0))
        {
            //Rayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10, layerMask);
            Debug.DrawRay(ray.origin, ray.direction,Color.red);
            //Rayとなにか衝突したときの処理
            
            if (hit.collider)
            {
               
                hit.collider.gameObject.GetComponent<Move>().move = 
                    (hit.collider.gameObject.GetComponent<Move>(). move==0) ? -1 : 0;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Rayを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 10, layerMask);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            //Rayとなにか衝突したときの処理
            
            if (hit.collider)
            {
              
                hit.collider.gameObject.GetComponent<Move>().move =
                    (hit.collider.gameObject.GetComponent<Move>().move == 0) ? 1 : 0;
            }
        }
    }

}