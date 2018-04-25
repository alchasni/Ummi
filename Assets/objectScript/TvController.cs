using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour {

    public Sprite anim;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<Animator>().GetBool("on") == false)
            gameObject.GetComponent<SpriteRenderer>().sprite = anim;
    }
}
