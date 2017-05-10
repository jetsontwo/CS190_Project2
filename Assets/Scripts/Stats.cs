using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int health, damage;
    public int initial_health;

    void Start()
    {
        health = initial_health;
    }


    public void hurt(int damage)
    {
        //Can heal by hurting with a negative number
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
