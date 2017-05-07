using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Controller : MonoBehaviour {

    public GameObject explosion;
	// Update is called once per frame
	void Start()
    {
        StartCoroutine(explode());
    }


    IEnumerator explode()
    {
        while(true)
        {
            GameObject new_explosion = Instantiate(explosion);
            new_explosion.transform.position = new Vector2(Random.Range(-30f, 30f), Random.Range(-4f, -2.5f));
            new_explosion.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
        }
    }
}
