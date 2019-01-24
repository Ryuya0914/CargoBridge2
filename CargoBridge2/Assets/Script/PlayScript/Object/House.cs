﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour {

    public GameObject clear;
    
	// Use this for initialization
	void Start () {
        clear.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag== "fruit")
        {
            
            Destroy(col.gameObject);
            GameObject[] list = GameObject.FindGameObjectsWithTag("fruit");
            Debug.Log(list.Length);
            if(list.Length <= 1)
            {
                Debug.Log("クリア！！！");
                clear.SetActive(true);
                GameObject[] player = GameObject.FindGameObjectsWithTag("player");
                foreach(GameObject obj in player)
                {
                    obj.GetComponent<Move>().stop = false;
                }
            }
        }
    }
}