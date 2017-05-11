using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Press : MonoBehaviour {

    bool pressed = false, done = false;
    public GameObject ff;
    private Button_Trigger bt;

    void Start()
    {
        bt = GetComponent<Button_Trigger>();
    }

    public void OnPress()
    {
        if(!done)
        {
            bt.Button();
            ff.SetActive(true);
            pressed = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
            done = true;
        }

    }
}
