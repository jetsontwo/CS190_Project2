﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour {

    public GameObject player;
    private Rigidbody2D rb;
    private Step_Trigger step;
    private float horiz;
    private int count = 0;
    private bool on_ground = false;
    public float speed, max_vel, decel, detect_dist;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        step = GetComponent<Step_Trigger>();
    }
	
	// Update is called once per frame
	void Update () {
        horiz = Find_Player();
        if (rb.velocity.x != 0 && on_ground)
            count++;
        if (horiz != 0 && rb.velocity.magnitude < max_vel)
            rb.velocity += new Vector2(horiz * speed * Time.deltaTime, 0);
        else if (horiz == 0)
            rb.velocity -= new Vector2(rb.velocity.x / decel, 0);

        if (count >= 24)
        {
            step.Step();
            count = 0;
        }
    }


    private int Find_Player()
    {
        int movement = 0;
        
        if(transform.position.x > player.transform.position.x - detect_dist && transform.position.x < player.transform.position.x + detect_dist)
            movement = transform.position.x < player.transform.position.x ? 1 : -1;
        return movement;
    }
}
