 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
	SpriteRenderer spriteRenderer;

	public bool pressed;
	public Sprite alternateSprite;

	GameObject presser;

    AudioSource asrc;
    public AudioClip sound;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
        asrc = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject go = collider.gameObject;

		if (go.GetComponent<Player>() != null || go.GetComponent<BlockIce>() != null || go.GetComponent<Bomb>() != null) {
			if (presser == null) {
				presser = go;
				pressed = true;
				SwitchSprite ();
                asrc.PlayOneShot(sound);
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject == presser) {
			presser = null;
			pressed = false;
			SwitchSprite ();
            asrc.PlayOneShot(sound);
        }
	}

	void SwitchSprite() {
		Sprite spr = spriteRenderer.sprite;
		spriteRenderer.sprite = alternateSprite;
		alternateSprite = spr;
	}
}
