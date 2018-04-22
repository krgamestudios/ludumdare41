using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	BoxCollider2D boxCollider;

	public PressurePlate trigger;
	public bool inverted = false;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		boxCollider = GetComponent<BoxCollider2D> ();
	}

	void Update() {
		if (trigger.pressed) {
			spriteRenderer.enabled = inverted;
			boxCollider.enabled = inverted;
		} else {
			spriteRenderer.enabled = !inverted;
			boxCollider.enabled = !inverted;
		}
	}
}
