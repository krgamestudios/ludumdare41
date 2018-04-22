using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSoundManager : MonoBehaviour {

    static AudioSource asrc;


	// Use this for initialization
	void Awake () {
        if (asrc == null)
        {
            asrc = GetComponent<AudioSource>();
            asrc.Play();
        }
	}
	
	
	void LateUpdate () {
        asrc = null;
	}
}
