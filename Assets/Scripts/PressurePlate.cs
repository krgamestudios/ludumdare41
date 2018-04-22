 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	public bool pressed;
	public Sprite alternateSprite;

	GameObject presser;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject go = collider.gameObject;

		if (go.GetComponent<Player>() != null || go.GetComponent<BlockIce>() != null || go.GetComponent<Bomb>() != null) {
			if (presser == null) {
				presser = go;
				pressed = true;
				SwitchSprite ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject == presser) {
			presser = null;
			pressed = false;
			SwitchSprite ();
		}
	}

	void SwitchSprite() {
		Sprite spr = spriteRenderer.sprite;
		spriteRenderer.sprite = alternateSprite;
		alternateSprite = spr;
	}
}
