using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill : MonoBehaviour {
    bool hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hit != true)
        {
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        transform.localPosition = new Vector3(0, 0, 0);
        hit = false;
	}

    void OnTriggerStay2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if(obj.tag == "Grass" || obj.tag == "Wood" || obj.tag == "Walk")
        {
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 0;
            hit = true;
        }
    }
}
