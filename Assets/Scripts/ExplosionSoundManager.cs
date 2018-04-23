using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSoundManager : MonoBehaviour {
	AudioSource asrc;

	void Awake () {
		asrc = GetComponent<AudioSource>();

		//only play the explosion sound if the player is close enough to hear it
		Vector3 playerPos = GameObject.Find ("Player").transform.position;
		if (Vector3.Distance(transform.position, playerPos) <= 1) {
			asrc.Play();
		}
	}
}
