using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

   

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
        Vector3 force = new Vector3(2.0f, 0.0f, 0.0f);    // 力を設定
        rb.AddForce(force);  // 力を加える

    }
}
