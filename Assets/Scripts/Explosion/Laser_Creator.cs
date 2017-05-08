using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Creator : MonoBehaviour {


    public GameObject laser1, laser2;

	// Update is called once per frame
	void Start () {
        StartCoroutine(create_lasers());
	}

    IEnumerator create_lasers()
    {
        while(true)
        {
            int ran_num = Random.Range(1, 3);
            GameObject new_laser;
            if (ran_num == 1)
                new_laser = Instantiate(laser1);
            else if (ran_num == 2)
                new_laser = Instantiate(laser2);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
