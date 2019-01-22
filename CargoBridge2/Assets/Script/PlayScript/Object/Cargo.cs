using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour {
    bool hit = true;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (hit&&col.gameObject.tag == "player" )
        {
            Debug.Log("hit");

            //if(col.gameObject.GetComponent<DistanceJoint2D>().enabled==false)
            //{
            //    col.gameObject.GetComponent<DistanceJoint2D>().enabled = true;
            //    col.gameObject.GetComponent<DistanceJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
            //}
            if (col.gameObject.GetComponent<HingeJoint2D>().enabled == false)
            {
                col.gameObject.GetComponent<HingeJoint2D>().enabled = true;
                col.gameObject.GetComponent<HingeJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
            }

        }
    }
}
