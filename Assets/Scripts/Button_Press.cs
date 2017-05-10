using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Press : MonoBehaviour {

    bool pressed = false, done = false;
    public GameObject ff;

    public void OnPress()
    {
        if(!done)
        {
            ff.SetActive(true);
            pressed = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
            done = true;
        }

    }
}
