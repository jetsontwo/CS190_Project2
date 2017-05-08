using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Controller : MonoBehaviour {

    public bool go_right;
    public float speed;
    void Start()
    {
        if(go_right)
        {
            transform.position = new Vector3(-35, Random.Range(0f, 5f));
        }
        else
        {
            transform.position = new Vector3(35, Random.Range(0f, 5f));
        }
        speed *= Random.Range(0.8f, 1.2f);
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);

    }
    void Update()
    {
        if ((transform.position.x < -35 && speed < 0) || (transform.position.x > 35 && speed > 0))
            Destroy(gameObject);
    }
}
