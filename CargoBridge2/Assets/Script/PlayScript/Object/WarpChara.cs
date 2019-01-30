using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpChara : MonoBehaviour {
    public enum WarpCharaState
    {
        normal,
        goTooWarpPoint,
    };

    private WarpCharaState state;
    private Transform warpPoint;
    public float walkSpeed;
    public float goToWaitPointSpeed;

	// Use this for initialization
	void Start () {
        state = WarpCharaState.normal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
