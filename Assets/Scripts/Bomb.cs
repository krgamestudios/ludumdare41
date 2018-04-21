using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	public float timer;

	GameObject explosion;

	void Awake() {
		StartCoroutine (ExplodeAfter (timer));

		explosion = transform.GetChild (0).gameObject;
	}

	IEnumerator ExplodeAfter(float delay) {
		yield return new WaitForSeconds (delay);
		explosion.SetActive (true);
		transform.DetachChildren ();
		Destroy (gameObject);
	}
}
