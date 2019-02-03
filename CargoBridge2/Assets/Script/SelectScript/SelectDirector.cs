using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDirector : MonoBehaviour {
    string[] stage = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10" };
    int[] cost = { 2000, 2000, 3000, 0, 2000, 0, 5000, 7000, 2000, 2000 };

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

    public void select(int a)
    {
        GameDirector.StageSet(cost[a], stage[a]);
        SceneManager.LoadScene("CreateScene");
    }
}
