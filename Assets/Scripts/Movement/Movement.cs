using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D rb;
    private Step_Trigger step;
    private Jump_Trigger jump;
    public Attack_Controller ac;
    public bool can_attack;
    private float horiz;
    private int count = 0;
    private bool on_ground = false, is_right = true, need_land = false;
    public float speed, max_vel, jump_power, decel;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        step = GetComponent<Step_Trigger>();
        jump = GetComponent<Jump_Trigger>();
	}

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxisRaw("Horizontal");
        if (rb.velocity.x != 0 && on_ground && horiz != 0)
            count++;
        if (horiz != 0 && rb.velocity.magnitude < max_vel)
            rb.velocity += new Vector2(horiz * speed * Time.deltaTime, 0);
        else if (horiz == 0)
            rb.velocity -= new Vector2(rb.velocity.x / decel, 0);
        if (horiz < 0 && is_right == true && can_attack)
        {
            is_right = false;
            ac.rotate_sword();
        }
        else if (horiz > 0 && is_right == false && can_attack)
        {
            is_right = true;
            ac.rotate_sword();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (touching_ground())
            {
                rb.AddForce(new Vector2(0, jump_power), ForceMode2D.Impulse);
                need_land = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && can_attack)
            ac.attack();

        if (count >= 24)
        {
            step.Step();
            count = 0;
        }
	}

    public bool touching_ground()
    {
        return on_ground;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Button")
            c.GetComponent<Button_Press>().OnPress();
        else if (need_land == true)
        {
            jump.Jump();
            count = 0;
            need_land = false;
        }
        if (c.tag == "Door")
            c.GetComponent<Scene_Change>().ChangeScene();
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
        else if (c.tag == "Button")
            c.GetComponent<Button_Press>().OnPress();
    }
}
