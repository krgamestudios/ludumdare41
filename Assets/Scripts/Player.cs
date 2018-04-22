using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Animator animator;
	Rigidbody2D rigidBody;
	witchAnimate witchAnimateScript;

	//movement
	float speed;
	Vector2 deltaForce;
	Vector2 lastDirection = new Vector2(0, -1);

	//attacking
	float lastAttack = float.NegativeInfinity;
	const float attackDelay = 0.5f;

	//prefabs
	public GameObject firePelletPrefab;
	public GameObject icePelletPrefab;
	public GameObject windPelletPrefab;

	void Awake() {
		animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		witchAnimateScript = GetComponent<witchAnimate> ();

		speed = 0.79f;
	}

	void Update() {
		HandleInput ();
	}

	void FixedUpdate() {
		Move ();
		Attack ();
	}

	void HandleInput() {
		//determine the input from the player
		//NOTE: duplicate code
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		deltaForce = new Vector2 (horizontal, vertical);

		//calculate last direction
		if (deltaForce != Vector2.zero) {
			lastDirection = rigidBody.velocity;
		}
	}

	void Move() {
		//determine how to move the character
		rigidBody.velocity = Vector2.zero;
		Vector2 impulse = deltaForce.normalized * speed;
		rigidBody.AddForce (impulse, ForceMode2D.Impulse);
	}

	void Attack() {
		if (Time.time - lastAttack > attackDelay && witchAnimateScript.current == witchAnimate.Deed.shoot) {
			lastAttack = Time.time;
			GameObject pellet = null;

			switch (witchAnimateScript.el) {
			case witchAnimate.Element.fire:
				pellet = Instantiate (firePelletPrefab);
				break;
			case witchAnimate.Element.ice:
				pellet = Instantiate (icePelletPrefab);
				break;
			case witchAnimate.Element.wind:
				pellet = Instantiate (windPelletPrefab);
				break;
			}

			//HACK-ish
			Vector2 distance = GetShootingPoint();
			pellet.transform.position = new Vector2(transform.position.x + distance.x, transform.position.y + distance.y);
			pellet.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			pellet.GetComponent<Rigidbody2D> ().AddForce (lastDirection.normalized * 2, ForceMode2D.Impulse);
		}

		if (witchAnimateScript.current != witchAnimate.Deed.shoot) {
			lastAttack = float.NegativeInfinity;
		}
	}

	//utilities
	Vector2 GetShootingPoint() {
		return lastDirection.normalized * 0.15f;
	}
}
