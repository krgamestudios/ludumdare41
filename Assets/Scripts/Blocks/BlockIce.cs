using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIce : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	Rigidbody2D rigidBody;

	public float bombTimer = -1;

	public GameObject bombPrefab;
	public Sprite alternateSprite;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigidBody = GetComponent<Rigidbody2D> ();

		rigidBody.Sleep ();
	}

	void Start() {
		//switch if it's a bomb block
		if (bombTimer >= 0) {
			Sprite spr = spriteRenderer.sprite;
			spriteRenderer.sprite = alternateSprite;
			alternateSprite = spr;
		}
	}

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

		WindDamager wind = collider.gameObject.GetComponent<WindDamager> ();
		if (wind != null) {
			rigidBody.AddForce (collider.gameObject.GetComponent<Rigidbody2D> ().velocity * 20, ForceMode2D.Impulse);
		}
	}
}
