using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Counter : MonoBehaviour {

    public GameObject enemy_holder;
    private Text counter;
    
    void Start()
    {
        counter = GetComponent<Text>();
    }	
	// Update is called once per frame
	void Update () {
        counter.text = "Enemies Left: " + enemy_holder.transform.childCount;
        if (enemy_holder.transform.childCount == 0)
            counter.text = "YOU WIN!";
	}
}
