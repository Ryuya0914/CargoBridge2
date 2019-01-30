using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    HingeJoint2D[] Joints;
    bool CheckFlag = false;
    bool DelFlag = false;

    void Start() {
        Joints = GetComponents<HingeJoint2D>();
        if (GameDirector.GameState == 0) CheckFlag = true;
        else if (GameDirector.GameState == 1) Invoke("PlayMode", 2.0f);
    }

    void Update() {
        if (CheckFlag) {
            JointReset();
        }
    }

    public void ConnectionBridge(GameObject obj) {
        for (int i = 0; i < 7; i++) {
            if (Joints[i].enabled == false) {
                Joints[i].enabled = true;
                Joints[i].connectedBody = obj.GetComponent<Rigidbody2D>();
                break;
            }
        }
        DelFlag = true;
    }

    public bool Check() {
        bool nullflag = false;
        bool sameflag = false;

        JointReset();

        for (int i = 0; i < 7; i++) {
            if (Joints[i].enabled == false) nullflag = true;
        }
        if (nullflag && !sameflag) return true;
        return false;
    }

    void JointReset() {
        int count = 0;
        for (int i = 0; i < 7; i++) {
            if (Joints[i].enabled == true && Joints[i].connectedBody == null) {
                Joints[i].breakForce = 99999;
                Joints[i].autoConfigureConnectedAnchor = true;
                Joints[i].enabled = false;
            }
            if (Joints[i].enabled == false) count++;
        }

        if (count >= 7 && DelFlag && gameObject.tag == "Point") Destroy(this.gameObject);
    }

    void PlayMode() {
        for (int i = 0; i < 7; i++) {
            if (Joints[i].enabled == true) {
                GameObject obj = Joints[i].connectedBody.gameObject;
                if (gameObject.tag == "Point") Joints[i].breakForce = obj.GetComponent<Bridge>().breakeForce;
                else if (gameObject.tag == "Ground") Joints[i].breakForce = obj.GetComponent<Bridge>().breakeForce * 1.2f;
            }
        }
    }
}
