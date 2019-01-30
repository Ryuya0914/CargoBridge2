using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour {
    bool hit = true;
    bool playFalg = false;
    void Start()
    {
        if (GameDirector.GameState == 1)
        {
            playFalg = true;
            Invoke("ObjectModeChange", 1.8f);
        }
    }
    public void ObjectModeChange()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (playFalg)
        {
            if (hit && col.gameObject.tag == "player")
            {


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
}
