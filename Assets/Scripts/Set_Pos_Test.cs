using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Pos_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AkSoundEngine.SetObjectPosition(gameObject, transform.position.x, transform.position.y, transform.position.z, 1f, 0, 0);
    }
}
