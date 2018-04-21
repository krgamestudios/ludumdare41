﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shootable
public class WindDamager : DamagerBase {
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.GetComponent<WindDamager> () == null) { //pass through other instances of self
			Destroy (gameObject);
		}
	}
}
