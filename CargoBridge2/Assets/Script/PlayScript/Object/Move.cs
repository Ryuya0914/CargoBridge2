using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public int move = 0;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
        Vector2 force = new Vector2(move*10.0f, 0.0f);    // 力を設定
            rb.AddForce(force, ForceMode2D.Force);  // 力を加える
        Debug.Log(rb.velocity);
        rb.velocity = new Vector2(Mathf.Max(-3, (Mathf.Min(3, rb.velocity.x))), rb.velocity.y);
        
    }
}
