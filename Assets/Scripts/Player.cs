using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Animator animator;
	Rigidbody2D rigidBody;

	float speed;
	Vector2 deltaForce;
	Vector2 lastDirection;
	bool isShooting;

	void Awake() {
		animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();

		speed = 1f;
	}

	void Update() {
		HandleInput ();
		Move ();
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
	}

	void Move() {
		//determine how to move the character
		rigidBody.velocity = Vector2.zero;
		Vector2 impulse = deltaForce.normalized * speed;
		rigidBody.AddForce (impulse, ForceMode2D.Impulse);
	}

	void SendAnimationInfo() {
		animator.SetFloat ("xSpeed", lastDirection.x);
		animator.SetFloat ("ySpeed", lastDirection.y);
		animator.SetBool ("isShooting", isShooting);
	}
}
