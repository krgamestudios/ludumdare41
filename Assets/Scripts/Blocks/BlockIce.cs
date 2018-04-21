using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIce : MonoBehaviour {
	public float bombTimer = -1;

	public GameObject bombPrefab;

	void OnTriggerEnter2D(Collider2D collider) {
		//TODO: use durability class?
		FireDamager fire = collider.gameObject.GetComponent<FireDamager> ();
		if (fire != null) {
			if (bombTimer >= 0) {
				GameObject bomb = Instantiate (bombPrefab);
				bomb.transform.position = transform.position;
				bomb.GetComponent<Bomb> ().timer = bombTimer;
			}
			Destroy (gameObject);
		}
	}
}
