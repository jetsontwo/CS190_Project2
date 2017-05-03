using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;
    private float horiz;
    public float speed, max_vel, jump_power, decel;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horiz = Input.GetAxisRaw("Horizontal");

        if (horiz != 0 && rb.velocity.magnitude > max_vel)
            rb.velocity += new Vector2(horiz, 0);
        else if (horiz == 0)
            rb.velocity -= new Vector2(rb.velocity.x / decel, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Jump());

        if(horiz != 0)
        {
            rb.velocity.Normalize();
            rb.velocity *= speed * Time.deltaTime;
        }
	}

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
