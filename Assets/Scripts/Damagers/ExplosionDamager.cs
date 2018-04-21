using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamager : DamagerBase {
	//simply causes damage and then disappears
	void Awake() {
		StartCoroutine (DestroyAfter (0.5f));
	}

	IEnumerator DestroyAfter(float delay) {
		yield return new WaitForSeconds (delay);
		Destroy (gameObject);
	}
}
