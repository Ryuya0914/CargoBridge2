using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject connect = null;
    public  bool stop = true;
    bool playFlag = false;
    public int move = 0;
    private Vector2 m_moveDirection = Vector2.right;
    
    // Use this for initialization
    void Start()
    {
        if (GameDirector.GameState == 1)
        {
            playFlag = true;
            Invoke("ObjectModeChange", 1.8f);
        }
    }
    public void ObjectModeChange()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (playFlag)
        {
            if (stop)
            {
                if (move != 0)
                {
                    transform.rotation = Quaternion.Euler(0.0f, Mathf.Min(0, 180.0f * move), 0.0f);
                }
                Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
                Vector2 force = new Vector2(move * 10.0f, 0.0f);    // 力を設定
                rb.AddForce(force, ForceMode2D.Force);  // 力を加える

                rb.velocity = new Vector2(Mathf.Max(-3, (Mathf.Min(3, rb.velocity.x))), rb.velocity.y);

            }
        }
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "fruit")
        {
            connect = col.gameObject;
        }
    }
}
