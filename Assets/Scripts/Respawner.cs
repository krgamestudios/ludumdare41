using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {
	public GameObject instance;
	GameObject saved;
	Vector3 startPos;

	float timer = float.NegativeInfinity;
	public float delay = 3f;

	void Awake() {
		//make a backup copy
		saved = Instantiate (instance);
		saved.SetActive (false);
		startPos = instance.transform.position;
	}

	void FixedUpdate() {
		//start the countdown
		if (timer == float.NegativeInfinity && instance == null) {
			timer = Time.time;
		}

		//stop the countdown
		if (timer != float.NegativeInfinity && Time.time - timer >= delay) {
			instance = Instantiate (saved);
			instance.SetActive (true);
			instance.transform.position = startPos;
			timer = float.NegativeInfinity;

			//what is it?
			if (instance.GetComponent<Bomb>() != null) {
				instance.GetComponent<Bomb> ().respawner = this;
			}

			if (instance.GetComponent<BlockIce>() != null) {
				instance.GetComponent<BlockIce> ().respawner = this;
			}

			this.enabled = false;
		}
	}

	void OnEnable() {
		if (timer != float.NegativeInfinity) {
			timer = Time.time;
		}
	}
}
