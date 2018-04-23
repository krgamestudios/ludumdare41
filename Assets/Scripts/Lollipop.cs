using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lollipop : MonoBehaviour {
	Animator animator;

	public float timeTillWave = 10;
	float timeAccumulated;

	void Awake () {
		animator = GetComponent<Animator>();
		timeAccumulated = Random.Range(0, timeTillWave);
	}

	void Update () {
		timeAccumulated += Time.deltaTime;
		if (timeAccumulated >= timeTillWave) {
			if (Random.Range(0, 2) == 0) {
				animator.SetTrigger("SayHi");
			}
			timeAccumulated = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//TODO: begin the end screen process
	}
}
