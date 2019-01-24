using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public  bool stop = true;
    public int move = 0;
    private Vector2 m_moveDirection = Vector2.right;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    //void OnCollisionStay2D(Collision2D i_collision)
    //{

    //    var normal = i_collision.contacts[0].normal;

    //    Vector2 dir = m_moveDirection - Vector2.Dot(m_moveDirection, normal) * normal;
    //    m_moveDirection = dir.normalized;
    //    Debug.Log(normal);
    //    Debug.Log(dir);

    //}
}
