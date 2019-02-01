using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour {
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] GameObject AudioSourceObj;

    public void PlayAudio(int num) {
        AudioSourceObj.GetComponent<AudioSource>().PlayOneShot(audioClip[num]);
    }

}
