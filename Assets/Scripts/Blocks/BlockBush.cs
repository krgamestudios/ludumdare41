using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBush : MonoBehaviour {
	GameObject burnt;

	void Awake() {
		burnt = transform.GetChild (0).gameObject;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//TODO: use durability class?
		FireDamager fire = collider.gameObject.GetComponent<FireDamager> ();
		if (fire != null) {
			burnt.SetActive (true);
			transform.DetachChildren ();
			Destroy (gameObject);
		}
	}
}
