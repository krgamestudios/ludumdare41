using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeVictoryCandyColor : MonoBehaviour {

    public Sprite[] sprites;
    public static int spriteIndex;
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[spriteIndex];
    }


	
	// Update is called once per frame
	void Update () {

	}
}
