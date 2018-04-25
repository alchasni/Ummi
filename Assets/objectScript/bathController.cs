using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathController : MonoBehaviour
{
    public Sprite[] anim;
    public int state;
    public GameObject button;
    public GameObject icon;
    float timer;

    public GameObject[] anak;
    int id;

    bool filling;

    // Use this for initialization
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = anim[state];
        if (state == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (anak[i].GetComponent<charController>().dirty == true)
                {
                    if(i == 2)
                    {
                        anak[2].GetComponent<SpriteRenderer>().enabled = false;
                        anak[2].GetComponent<playerController>().diam = true;
                        anak[2].GetComponent<charController>().dirty = false;
                        anak[2].GetComponent<charController>().bathTimer = anak[i].GetComponent<charController>().defbathTimer;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            anak[2].GetComponent<SpriteRenderer>().enabled = false;
                            anak[2].GetComponent<playerController>().diam = true;
                        }
                        anak[i].SetActive(false);
                        anak[i].GetComponent<charController>().dirty = false;
                        anak[i].GetComponent<charController>().bathTimer = anak[i].GetComponent<charController>().defbathTimer;
                    }
                    id = i;
                    timer = 7.0f;
                    state = 2;
                    break;
                }
            }
        }
        if (timer <= 0)
        {
            if (filling == true)
            {
                state = 1;
                timer = 20;
                filling = false;
            }
            else if (state == 1)
            {
                state = 0;
            }
            else if (state == 2)
            {
                state = 0;
                if(id == 2)
                {
                    anak[2].GetComponent<SpriteRenderer>().enabled = true;
                    anak[2].GetComponent<playerController>().diam = false;
                    anak[2].GetComponent<charController>().bathTimer = anak[id].GetComponent<charController>().defbathTimer;
                }
                else
                {
                    anak[id].SetActive(true);
                    if (id == 0)
                    {
                        anak[2].GetComponent<SpriteRenderer>().enabled = true;
                        anak[2].GetComponent<playerController>().diam = false;
                    }
                    anak[id].GetComponent<charController>().bathTimer = anak[id].GetComponent<charController>().defbathTimer;

                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void Pressed()
    {
        timer = 4.0f;
        filling = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi" && button.activeSelf == false && state == 0 && !filling)
        {
            button.SetActive(true);
            icon.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi" && icon.activeSelf == true)
        {
            button.SetActive(false);
            icon.SetActive(false);
        }
    }
}
