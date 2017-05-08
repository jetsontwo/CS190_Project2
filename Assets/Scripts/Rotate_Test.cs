using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("test");
        StartCoroutine(rotate());
	}

    IEnumerator rotate()
    {
        while(true)
        {
            transform.RotateAround(transform.parent.position, Vector3.up, 180f);
            yield return new WaitForSeconds(1f);
        }
    }

}
