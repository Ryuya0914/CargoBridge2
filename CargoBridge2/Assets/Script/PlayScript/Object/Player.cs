using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 0;
    //動いているかどうか
    bool move;
    //目的地
    Vector2 vec;
    public GameObject fruit;      
    public GameObject house;       
    Vector2 fruitPos;              
    Vector2 housePos;
    float count = 1;

    public LayerMask GroundLayer;
    // Use this for initialization
    void Start () {
       
        fruitPos = fruit.transform.position;
        housePos = house.transform.position;
        move = false;
	}
	
	// Update is called once per frame
	void Update () {
        MoveController();
	}
    public void MoveController()
    {

        count = -0.01f;
        if (count < 0) count = 0;
        //キャラを動かす処理
        if (move == false)
        {
            if (count == 0)
            {
                if (Input.GetMouseButtonDown(1))  //右
                {
                    move = true;
                    speed = 2;
                    vec = fruitPos;
                    count = 1;
                }
                if (Input.GetMouseButtonDown(0))  //左
                {
                    move = true;
                    speed = 2;
                    vec = housePos;
                    count = 1;

                }
            }
        }
        //キャラを止める処理
        if (move == true)
        {
            if (count == 0)
            {
                if (Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1))
                {
                    move = false;
                    speed = 0;
                    count = 1;
                }
            }

        }
        Debug.Log(count);
        Debug.Log(move);
        Debug.Log(speed);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(vec.x+1, vec.y),
            speed * Time.deltaTime);

        if(transform.position.x>=(fruitPos.x+0.9f))
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            speed = 0;
            move = false;
        }
    }



}
