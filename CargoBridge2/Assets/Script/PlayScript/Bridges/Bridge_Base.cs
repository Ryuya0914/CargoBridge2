using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Base : MonoBehaviour {
    //このオブジェクトのパラメータ
    public float mass = 0;
    public float gravity = 0;
    public float breakeForce = 0;
    public float maxLength = 0;
    public int cost = 0;
    float length = 0;
    public List<GameObject> connectedPoint;
    public Color _color;
    public int haveCost = 0;

    GameObject createRoot;

    void Start() {
        createRoot = GameObject.Find("CreateRoot");
    }

    //当たり判定や重力の変更
    public void ObjectModeChange() {
        //PlaySceneの場合は動くようにする
        if (CreateDirector.state == 0) {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    //橋の移動
    public Vector2 Move(Vector2 startPos, Vector2 endPos) {
        float dx = endPos.x - startPos.x;
        float dy = endPos.y - startPos.y;
        Vector2 vec = new Vector2(dx, dy);
        //角度
        float rad = Mathf.Atan2(dy, dx);
        transform.rotation = Quaternion.EulerAngles(0, 0, rad);
        //長さ
        length = vec.magnitude;
        length = Mathf.Min(length, maxLength);
        length = Mathf.Min(length, (float)CreateDirector.cost / cost);
        transform.localScale = new Vector2(0.14f + 0.37f * length, 0.8f);
        //位置
        Vector2 pos = new Vector2(8, 8);
        pos.x = startPos.x + length * Mathf.Cos(rad);
        pos.y = startPos.y + length * Mathf.Sin(rad);
        transform.position = (pos + startPos) / 2;
        if (length <= 0.5f) return new Vector2(50, 0);
        else return pos;
    }

    public bool MoveCheck(Vector2 pos1, Vector2 pos2) {
        float dx = pos2.x - pos1.x;
        float dy = pos2.y - pos1.y;
        Vector2 vec = new Vector2(dx, dy);
        float _length = vec.magnitude;
        return (_length <= maxLength) ? true : false;
    }

    public void Cargo(GameObject obj1, GameObject obj2) {
        connectedPoint.Add(obj1);
        connectedPoint.Add(obj2);
        haveCost = (int)(length * cost);
        CreateDirector.cost -= haveCost;
        GetComponent<SpriteRenderer>().color = _color;
    }

    void OnDestroy() {
        CreateDirector.cost += haveCost;
    }

}
