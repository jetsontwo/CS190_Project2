using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Deleter : MonoBehaviour {

    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

	void Update () {
        if (!ps.isEmitting)
            Destroy(gameObject);
	}
}
