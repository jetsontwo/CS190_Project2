using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Counter : MonoBehaviour {

    public GameObject enemy_holder;
    public AkAmbient[] to_turn_off;
    public AkAmbient[] to_turn_on;
    private Text counter;
    bool won = true;
    
    void Start()
    {
        counter = GetComponent<Text>();
    }	
	// Update is called once per frame
	void Update () {
        if (enemy_holder.transform.childCount == 0)
            Win();
        else
        {
            counter.text = "Enemies Left: " + enemy_holder.transform.childCount;
        }
    }

    void Win()
    {
        if(won)
        {
            counter.text = "YOU WIN!";
            foreach (AkAmbient sound in to_turn_off)
                sound.enabled = false;
            foreach (AkAmbient sound in to_turn_on)
                sound.enabled = true;
            won = false;
        }        
    }
}
