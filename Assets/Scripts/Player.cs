using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public enum Mode {
		FIRE, ICE, WIND,
		LAST
	};

	Animator animator;
	Rigidbody2D rigidBody;

	//movement
	float speed;
	Vector2 deltaForce;
	Vector2 lastDirection = new Vector2(0, -1);

	//attacking
	bool isShooting;
	float lastAttack = float.NegativeInfinity;
	const float attackDelay = 0.5f;
	Mode mode = Mode.FIRE;
	public GameObject firePelletPrefab;
	public GameObject icePelletPrefab;
	public GameObject windPelletPrefab;

	void Awake() {
		animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();

		speed = 0.79f;
	}

	void Update() {
		HandleInput ();
	}

	void FixedUpdate() {
		Move ();
		Attack ();
		SendAnimationInfo ();
	}

	void HandleInput() {
		//determine the input from the player
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		deltaForce = new Vector2 (horizontal, vertical);

		//calculate last direction
		if (deltaForce != Vector2.zero) {
			lastDirection = rigidBody.velocity;
		}

		//calculate if shooting
		isShooting = Input.GetButton ("Attack");

		if (Input.GetButtonDown("Switch")) {
			mode += 1;
			if (mode == Mode.LAST) {
				mode = 0;
			}
		}
	}

	void Move() {
		//determine how to move the character
		rigidBody.velocity = Vector2.zero;
		Vector2 impulse = deltaForce.normalized * speed;
		rigidBody.AddForce (impulse, ForceMode2D.Impulse);
	}

	void Attack() {
		if (Time.time - lastAttack > attackDelay && isShooting) {
			lastAttack = Time.time;
			GameObject pellet = null;

			switch (mode) {
			case Mode.FIRE:
				pellet = Instantiate (firePelletPrefab);
				break;
			case Mode.ICE:
				pellet = Instantiate (icePelletPrefab);
				break;
			case Mode.WIND:
				pellet = Instantiate (windPelletPrefab);
				break;
			}

			//HACK-ish
			Vector2 distance = GetShootingPoint();
			pellet.transform.position = new Vector2(transform.position.x + distance.x, transform.position.y + distance.y);
			pellet.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			pellet.GetComponent<Rigidbody2D> ().AddForce (lastDirection.normalized * 2, ForceMode2D.Impulse);
		}

		if (!isShooting) {
			lastAttack = float.NegativeInfinity;
		}
	}

	void SendAnimationInfo() {
		animator.SetFloat ("xSpeed", lastDirection.x);
		animator.SetFloat ("ySpeed", lastDirection.y);
		animator.SetBool ("isShooting", isShooting);
	}

	//utilities
	Vector2 GetShootingPoint() {
		Vector2 point = lastDirection.normalized;

		if (Mathf.Abs (point.x) == Mathf.Abs (point.y)) {
			point *= 0.26f; //diagonal
		} else if (Mathf.Abs (point.x) < Mathf.Abs (point.y)) {
			point *= 0.23f; //vertical
		} else {
			point *= 0.2f; //horizontal
		}

		return point;
	}
}
