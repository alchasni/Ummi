using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyubiController : MonoBehaviour {

    public GameObject[] anak;
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
            for(int i = 0; i < 4; i++)
            {
                anak[i].GetComponent<charController>().hungerTimer = anak[i].GetComponent<charController>().defhungerTimer;
                anak[i].GetComponent<charController>().hungry = false;
                anak[i].GetComponent<charController>().bathTimer = anak[i].GetComponent<charController>().defbathTimer;
                anak[i].GetComponent<charController>().dirty = false;
            }
        }
    }
}
