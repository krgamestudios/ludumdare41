using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPosition : MonoBehaviour {

    public float lerpSpeed = 1f;
    public Transform destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var p = transform.position;
        p = Vector3.Lerp(p, destination.position, lerpSpeed * Time.deltaTime);
        transform.position = p;
	}
}
