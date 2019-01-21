using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour {

    public GameObject player;
    Vector2 playerPos;
    public Rigidbody2D rb;
        

	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().enabled = false;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

    }
	
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position;
        if (playerPos.x > (transform.position.x+0.9))
        {
            GetComponent<CircleCollider2D>().enabled = true;
            rb.isKinematic = false;
        }
	}
}
