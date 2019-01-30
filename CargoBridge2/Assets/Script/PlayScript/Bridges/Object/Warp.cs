using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform worpPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "player")
        {
            //col.GetComponent<>
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
