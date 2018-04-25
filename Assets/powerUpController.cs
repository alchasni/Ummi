using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpController : MonoBehaviour {

    public int type;
    public bool active;
    public float timer;
    public float time;
    public float pwTimer;
    bool buff;
    public GameObject umi;
    public GameObject cameera;
    public static bool uciha;

    // Use this for initialization
    void Start () {
        timer = time;
        active = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!active)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else if (active)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<PolygonCollider2D>().enabled = true;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            active = true;
        }
        if (pwTimer > 0)
        {
            pwTimer -= Time.deltaTime;
        }
        else if(buff)
        {
            if(type == 1)
            {
                umi.gameObject.GetComponent<playerController>().speed /= 2;
                buff = false;
            }
            else if(type == 2)
            {
                buff = false;
                cameera.GetComponent<Camera>().orthographicSize = 5;
            }
            else
            {
                buff = false;
                umi.GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "umi" && active)
        {
            if(type == 1)
            {
                coll.gameObject.GetComponent<playerController>().speed *= 2;
                pwTimer = 10;
                active = false;
                buff = true;
                timer = time;
            }
            if(type == 2)
            {
                cameera.GetComponent<Camera>().orthographicSize = 10;
                pwTimer = 10;
                active = false;
                timer = time;
                buff = true;
            }
            if(type == 3)
            {
                umi.GetComponent<CapsuleCollider2D>().enabled = false;
                pwTimer = 10;
                active = false;
                timer = time;
                buff = true;
            }
        }
    }
}
