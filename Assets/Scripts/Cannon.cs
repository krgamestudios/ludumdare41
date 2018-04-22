using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public enum Direction {
		NORTH, EAST, SOUTH, WEST
	};

	public Direction direction;
	public GameObject pelletPrefab;
	public float delay;
	float speed = 3f;

	public Sprite sprite; //TMP, hopefully

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprite;

		StartCoroutine (FireOnTimer (delay));
	}

	IEnumerator FireOnTimer(float seconds) {
		while(true) {
			yield return new WaitForSeconds (seconds);
			GameObject go = Instantiate (pelletPrefab);
			go.transform.position = transform.position;

			switch (direction) {
			case Direction.NORTH:
				go.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, speed), ForceMode2D.Impulse);
				break;
			case Direction.EAST:
				go.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed, 0), ForceMode2D.Impulse);
				break;
			case Direction.SOUTH:
				go.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -speed), ForceMode2D.Impulse);
				break;
			case Direction.WEST:
				go.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-speed, 0), ForceMode2D.Impulse);
				break;
			}
		}
	}
}
