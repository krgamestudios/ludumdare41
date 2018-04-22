using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopSaysHi : MonoBehaviour {

    float timeAccumulated;
    public float timeTillWave = 10;
    // Use this for initialization
    Animator a;

	void Start () {
        timeAccumulated = Random.Range(0, timeTillWave);
        a = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timeAccumulated += Time.deltaTime;
        if (timeAccumulated >= timeTillWave)
        {
            if (Random.Range(0, 2) == 0)
            {
                a.SetTrigger("SayHi");
            }
            timeAccumulated = 0;
        }
	}
}
