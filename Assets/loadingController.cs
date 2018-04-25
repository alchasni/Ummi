using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingController : MonoBehaviour {
    public float timer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(timer <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}

    public void SetTimer(float time)
    {
        timer = time;
    }
}
