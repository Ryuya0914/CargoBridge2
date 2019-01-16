using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    //現在つなげている数
    public int Count = 0;
    //接続した橋
    List<GameObject> Bridges;
    HingeJoint2D[] Joints;
    

    void Start() {
        Bridges = new List<GameObject>();
        Joints = GetComponents<HingeJoint2D>();
    }

    public void ConnectionBridge(GameObject obj) {
        Debug.Log(obj.gameObject.name);
        Joints[Count].connectedBody = obj.GetComponent<Rigidbody2D>();
        Count++;
        Bridges.Add(obj);
    }
}
