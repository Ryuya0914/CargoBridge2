using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Base : MonoBehaviour {
    //このオブジェクトのパラメータ
    public float mass = 0;
    public float gravity = 0;
    public float breakeForce = 0;
    public float length = 0;
    public float cost = 0;

    //当たり判定や重力の変更
    public void ObjectModeChange() {
        //PlaySceneの場合は動くようにする
        if (CreateDirector.state == 0) gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    //橋の移動
    public void Move(Vector2 startPos, Vector2 endPos) {
        //位置
        transform.position = (startPos + endPos) / 2;
        //角度
        float dx = startPos.x - endPos.x;
        float dy = startPos.y - endPos.y;
        float rad = Mathf.Atan2(dy, dx);
        transform.rotation = Quaternion.EulerAngles(0, 0, rad);
        //長さ
        float _length = Mathf.Sqrt(dx * dx + dy * dy);
        transform.localScale = new Vector2(1.5f + 6.5f * _length, 3);
    }
}
