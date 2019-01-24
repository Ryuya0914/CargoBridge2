using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    //現在つなげているpoint
    public List<GameObject> connectionPoint;
    

    HingeJoint2D[] Joints;
    

    void Start() {
        Joints = GetComponents<HingeJoint2D>();
    }

    public void ConnectionBridge(GameObject obj) {
        for (int i = 0; i < 7; i++) {
            if (Joints[i].enabled == false) {
                Joints[i].enabled = true;
                Joints[i].connectedBody = obj.GetComponent<Rigidbody2D>();
                Joints[i].breakForce = obj.GetComponent<Bridge>().breakeForce;
                break;
            }
        }
    }

    public bool Check() {
        bool nullflag = false;
        bool sameflag = false;
        
        for (int i = 0; i < 7; i++) {
            if (Joints[i].enabled == true && Joints[i].connectedBody == null) Joints[i].enabled = false;
        }
        
        for (int i = 0; i < 7; i++) {
            if (Joints[i].enabled == false) nullflag = true;
        }
        if (nullflag && !sameflag) return true;
        return false;
    }
}
