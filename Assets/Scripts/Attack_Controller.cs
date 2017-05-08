using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Controller : MonoBehaviour {

    private bool attacking;
    private GameObject enemy = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!attacking && Input.GetKeyDown(KeyCode.Mouse0))
            StartCoroutine(attack());
	}


    private void rotate_sword()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, 180f);
    }

    IEnumerator attack()
    {
        attacking = true;
        if (enemy != null)
            enemy.GetComponent<Stats>().hurt(10);
        while(transform.rotation.eulerAngles.z > -90)
        {
            transform.Rotate(new Vector3(0, 0, -1));
            yield return new WaitForSeconds(0.001f);
        }
        while(transform.rotation.eulerAngles.z < -40)
        {
            transform.Rotate(new Vector3(0, 0, 1));
            yield return new WaitForSeconds(0.001f);
        }
        attacking = false;
    }

    void OnColliderEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
            enemy = c.gameObject;
    }
    void OnCollderExit2D(Collider2D c)
    {
        if (c.tag == "Enemy")
            enemy = null;
    }
}
