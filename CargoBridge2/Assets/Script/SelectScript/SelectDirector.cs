using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void back()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void select()
    {
        SceneManager.LoadScene("CreateScene");
    }
}
