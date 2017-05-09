using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

    private Attack_Trigger at;
    private bool attacking;
    public float wait_time;
    private GameObject enemy = null;

    void Start()
    {
        at = transform.parent.GetComponent<Attack_Trigger>();
    }
	
	// Update is called once per frame
	public void attack () {
        if (!attacking)
            StartCoroutine(attack_anim());
	}


    public void rotate_sword()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, 180f);
    }

    IEnumerator attack_anim()
    {
        attacking = true;

        while (transform.rotation.eulerAngles.z > 270)
        {
            transform.Rotate(new Vector3(0, 0, -3));
            yield return new WaitForSeconds(0.001f);
        }
        if (enemy != null)
            enemy.GetComponent<Stats>().hurt(10);
        play_sound();
        while (transform.rotation.eulerAngles.z < 320)
        {
            transform.Rotate(new Vector3(0, 0, 3));
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(wait_time);
        attacking = false;
    }

    void play_sound()
    {
        at.Attack();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
            enemy = c.gameObject;
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Enemy")
            enemy = null;
    }
}
