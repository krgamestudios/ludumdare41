using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shootable
public class FireDamager : DamagerBase {
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.GetComponent<FireDamager> () == null) { //pass through other instances of self
			Destroy (gameObject);
		}
	}
}
