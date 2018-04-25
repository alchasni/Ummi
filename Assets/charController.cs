using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charController : MonoBehaviour {
    public bool hungry;
    public bool dirty;

    public float hungerTimer;
    public float defhungerTimer;
    public float bathTimer;
    public float defbathTimer;

    // Use this for initialization
    void Start () {
        hungerTimer = defhungerTimer;
        bathTimer = defbathTimer;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hungry)
            GetComponent<Animator>().SetBool("lapar", true);
        if (dirty)
            GetComponent<Animator>().SetBool("mandi", true);
        if (!hungry)
            GetComponent<Animator>().SetBool("lapar", false);
        if (!dirty)
            GetComponent<Animator>().SetBool("mandi", false);

        if (hungerTimer > 0)
        {
            hungerTimer -= Time.deltaTime;
        }
        else
        {
            if (hungry)
                SceneManager.LoadScene(2);
            else
            {
                hungry = true;
                hungerTimer = defhungerTimer;
            }
        }

        if (bathTimer > 0)
        {
            bathTimer -= Time.deltaTime;
        }
        else
        {
            if (dirty)
                SceneManager.LoadScene(2);
            else
            {
                dirty = true;
                bathTimer = defbathTimer;
            }
        }
    }
}
