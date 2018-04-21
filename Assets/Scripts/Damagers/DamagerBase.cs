using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerBase : MonoBehaviour {
	public int value = 1;

	void Awake() {
		StartCoroutine (DestroySelfAfter (30));
	}

	IEnumerator DestroySelfAfter(float delay) {
		yield return new WaitForSeconds (delay);
		Destroy (gameObject);
	}
}