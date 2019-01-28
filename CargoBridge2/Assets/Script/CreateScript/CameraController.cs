using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    float cameraSize = 5;
    float MaxCameraSize;
    float Top, Bottom, Right, Left;

    void Start() {
        Invoke("CameraSet", 2.0f);
    }

    void CameraSet() {
        Top = GameObject.Find("TopRight").transform.position.y - 1;
        Bottom = GameObject.Find("BottomLeft").transform.position.y + 1;
        Right = GameObject.Find("TopRight").transform.position.x - 1;
        Left = GameObject.Find("BottomLeft").transform.position.x + 1;
        MaxCameraSize = Mathf.Min((Top - Bottom) / 2, (Right - Left) * 8 / 10);
    }

    //カメラの移動
    public void Move(Vector3 moveVec) {
        moveVec.z = 0;
        Vector3 newPos = transform.position + moveVec / 15f;
        transform.position = newPos;
        PosSet();
    }

    //カメラの位置制限
    void PosSet() {
        float cameraPosR = transform.position.x + cameraSize * 8 / 5;
        float cameraPosL = transform.position.x - cameraSize * 8 / 5;
        float cameraPosT = transform.position.y + cameraSize;
        float cameraPosB = transform.position.y - cameraSize;
        Vector3 newPos = transform.position;

        if (cameraPosR > Right) newPos.x -= cameraPosR - Right;
        else if (cameraPosL < Left) newPos.x += Left - cameraPosL;
        if (cameraPosT > Top) newPos.y -= cameraPosT - Top;
        else if (cameraPosB < Bottom) newPos.y += Bottom - cameraPosB;

        transform.position = newPos;
    }

    //カメラのズームイン、ズームアウト
    public void Zoom(float scrollValue) {
        cameraSize -= scrollValue;
        cameraSize = Mathf.Clamp(cameraSize, 2.5f, MaxCameraSize);
        GetComponent<Camera>().orthographicSize = cameraSize;
        PosSet();
    } 
}
