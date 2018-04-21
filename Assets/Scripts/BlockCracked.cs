using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCracked : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D collision) {
		//TODO: use durability class?
		ExplosionDamager exp = collision.gameObject.GetComponent<ExplosionDamager> ();
		if (exp != null) {
			Destroy (gameObject);
		}
	}
}
