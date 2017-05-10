using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_Fade : MonoBehaviour {

    public float rate;
    SpriteRenderer sr;
	
	// Update is called once per frame
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Fade());
	}

    IEnumerator Fade()
    {
        while (true)
        {
            while (sr.color.a > 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - rate);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.3f);
            while (sr.color.a < 1)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + rate);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
