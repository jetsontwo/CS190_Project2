using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;
    private float horiz;
    private bool on_ground = false;
    public float speed, max_vel, jump_power, decel;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        horiz = Input.GetAxisRaw("Horizontal");
        print(horiz != 0 && rb.velocity.magnitude < max_vel);
        if (horiz != 0 && rb.velocity.magnitude < max_vel)
            rb.velocity += new Vector2(horiz * speed * Time.deltaTime, 0);
        else if (horiz == 0)
            rb.velocity -= new Vector2(rb.velocity.x / decel, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            if (touching_ground())
                rb.AddForce(new Vector2(0, jump_power), ForceMode2D.Impulse);

        print(rb.velocity);
	}

    public bool touching_ground()
    {
        return on_ground;
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Ground")
            on_ground = true;
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Ground")
            on_ground = false;
    }
}
