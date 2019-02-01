using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMode : MonoBehaviour {
    //Play上でのtexture
    [SerializeField] Sprite Texture = null;
    [SerializeField] Color _color = new Color(1f, 1f, 1f, 1f);

    void Start() {
        if (GameDirector.GameState == 1) {
            GetComponent<SpriteRenderer>().sprite = Texture;
            GetComponent<SpriteRenderer>().color = _color;
        }
    }
    
}
