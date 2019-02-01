using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    float cameraSize = 5;
    float MaxCameraSize;
    float Top, Bottom, Right, Left;
    Vector3 backMouseScreenPos = new Vector3(0, 0, 0); //1フレーム前のマウスの位置
    [SerializeField]AudioSource audioSource;


    void Start() {
        Invoke("CameraSet", 1.3f);
    }
    
    void Update() {
        //マウス位置取得
        Vector3 nowMouseScreenPos = Input.mousePosition;
        //マウスのホイール入力値取得
        float wheelScroll = Input.GetAxis("Mouse ScrollWheel");

        //ホイールクリック
        if (Input.GetMouseButton(2)) {
            Move(backMouseScreenPos - nowMouseScreenPos);
        }
        //ホイールスクロール
        if (wheelScroll != 0) {
            Zoom(wheelScroll);
        }
        backMouseScreenPos = nowMouseScreenPos;
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

    //SEの再生
    public void SoundPlay(AudioClip SE) {
        audioSource.clip = SE;
        audioSource.Play();
    }

}
