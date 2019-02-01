using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour {
    [SerializeField] GameObject stage;
    public GameObject clear;
    bool playFalg = false;
	// Use this for initialization
	void Start () {
        clear = GameObject.Find("Clear");
        if (GameDirector.GameState == 1) {
            playFalg = true;
            clear.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playFalg)
        {
            if (col.gameObject.tag == "fruit")
            {

                Destroy(col.gameObject);
                GameObject[] list = GameObject.FindGameObjectsWithTag("fruit");
                Debug.Log(list.Length);
                foreach(GameObject obj in list) {
                    Debug.Log(obj.transform.parent.name);
                }
                if (list.Length <= 1) {
                    Debug.Log("クリア！！！");
                    clear.SetActive(true);
                    GameObject[] player = GameObject.FindGameObjectsWithTag("player");
                    foreach (GameObject obj in player) {
                        obj.GetComponent<Move>().stop = false;
                    }
                }
            }
        }
    }
}
