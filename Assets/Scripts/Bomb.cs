using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    Animator animator;
	Rigidbody2D rigidBody;

	public float timer;

	GameObject explosion;
	public GameObject iceBlockPrefab;
	public Sprite deadBomb;

	public Respawner respawner; //this can be respawned

	float birthTime;
    

	void Awake() {
		animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		if (timer < 0) {
			animator.enabled = false;

		}
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
			iceBlock.GetComponent<BlockIce> ().respawner = respawner;
			Destroy (gameObject);
		}

		WindDamager wind = collider.gameObject.GetComponent<WindDamager> ();
		if (wind != null) {
			rigidBody.AddForce (collider.gameObject.GetComponent<Rigidbody2D> ().velocity / 2, ForceMode2D.Impulse);
		}
	}

	IEnumerator ExplodeAfter(float delay) {
		if (delay >= 0) {
			yield return new WaitForSeconds (delay);
			explosion.SetActive (true);
			transform.DetachChildren ();
			if (respawner != null) {
				respawner.enabled = true;
			}
			Destroy (gameObject);
		}
	}
}
