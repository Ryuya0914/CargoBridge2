using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 0;
    bool move;
    Vector2 vec;
    public GameObject fruit;
    public GameObject house;
    float count = 1;

    public LayerMask GroundLayer;
    // Use this for initialization
    void Start () {
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

        if (move == false)
        {
            if (count == 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    move = true;
                    speed = 2;
                    vec = fruit.transform.position;
                    count = 1;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    move = true;
                    speed = 2;
                    vec = house.transform.position;
                    count = 1;

                }
            }

        }

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

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(vec.x, vec.y),
            speed * Time.deltaTime);
    }
}
