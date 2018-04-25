using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour {

    public AudioClip fuck;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi")
        {
            AudioSource sound = gameObject.GetComponent<AudioSource>();
            sound.PlayOneShot(fuck,1.0f);
        }

    }
}
