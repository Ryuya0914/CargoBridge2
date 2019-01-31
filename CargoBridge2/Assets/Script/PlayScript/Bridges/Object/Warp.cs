using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    float TimeCount = 3;
    public GameObject warpPoint;
    public GameObject Player;
    public bool warpFalg = true;
    bool stop = true;
    Vector3 vec;


    // Use this for initialization
    void Start () {
        vec = warpPoint.transform.position - transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
       
        if(warpFalg)
        {
            transform.Rotate(0.0f, 0.0f, -800.0f * Time.deltaTime);
        }
        else
        {
            TimeCount -= Time.deltaTime;
            if (TimeCount <= 0)
            {
                warpFalg = true;
                TimeCount = 3;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (warpFalg)
        {
            GameObject obj = col.gameObject;
            if(obj.tag == "player")
            {
                warpFalg = false;
                warpPoint.GetComponent<Warp>().warpFalg = false;
                obj.transform.parent.transform.position += vec;
            }

            if (obj.tag == "fruit")
            {
                warpFalg = false;
                warpPoint.GetComponent<Warp>().warpFalg = false;
                if (obj.transform.GetChild(0).GetComponent<Cargo>().connect==true)
                {
                    obj.transform.parent.transform.position += vec;
                    Debug.Log(obj.transform.parent.name);
                }
                else
                    obj.transform.position += vec;
            }
            //if (stop)
            //{
            //    if (col.gameObject.tag == "player")
            //    {
            //        GameObject obj = col.gameObject;
            //        if(obj.GetComponent<Move>().connect == null)
            //        {

                    //            warpFalg = false;
                    //            warpPoint.GetComponent<Warp>().warpFalg = false;
                    //            Player.GetComponent<Move>().move = 0;
                    //            col.gameObject.transform.position = warpPoint.transform.position;

                    //        }
                    //        else
                    //        {
                    //            stop = false;        
                    //        }
                    //    }
                    //}
                    //if (col.gameObject.tag == "fruit"&& col.gameObject.tag == "player")
                    //{
                    //    GameObject obj = col.gameObject;
                    //    if (obj.GetComponent<Cargo>().connect != null)
                    //    {
                    //        stop = false;
                    //        warpFalg = false;
                    //        warpPoint.GetComponent<Warp>().warpFalg = false;
                    //        Player.GetComponent<Move>().move = 0;
                    //        obj.transform.position = warpPoint.transform.position;
                    //        Player.transform.position = warpPoint.transform.position;
                    //    }
                    //}
        }
    }
}
