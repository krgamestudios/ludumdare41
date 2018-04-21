using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	Rigidbody2D rigidBody;

	public float timer;

	GameObject explosion;
	public GameObject iceBlockPrefab;

	float birthTime;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Start() {
		StartCoroutine (ExplodeAfter (timer));

		explosion = transform.GetChild (0).gameObject;

		birthTime = Time.time;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		FireDamager fire = collider.gameObject.GetComponent<FireDamager> ();
		if (fire != null) {
			//explode immediately
			StartCoroutine(ExplodeAfter(0));
		}

		IceDamager ice = collider.gameObject.GetComponent<IceDamager> ();
		if (ice != null) {
			GameObject iceBlock = Instantiate (iceBlockPrefab);
			iceBlock.transform.position = transform.position;
			iceBlock.GetComponent<BlockIce> ().bombTimer = timer - (Time.time - birthTime);
			Destroy (gameObject);
		}

		WindDamager wind = collider.gameObject.GetComponent<WindDamager> ();
		if (wind != null) {
			rigidBody.AddForce (collider.gameObject.GetComponent<Rigidbody2D> ().velocity / 2, ForceMode2D.Impulse);
		}
	}

	IEnumerator ExplodeAfter(float delay) {
		yield return new WaitForSeconds (delay);
		explosion.SetActive (true);
		transform.DetachChildren ();
		Destroy (gameObject);
	}
}
