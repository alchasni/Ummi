using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoveController : MonoBehaviour
{
    public Sprite[] anim;
    public int state;
    public GameObject button;
    public GameObject icon;
    float timer;

    public GameObject[] anak;

    // Use this for initialization
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = anim[state];
        if (timer <= 0)
        {
            if (state == 1)
            {
                timer = 8.0f;
                state = 2;
            }
            else if (state == 2)
            {
                state = 3;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void Pressed() {
        if (state == 0)
        {
            timer = 6.0f;
            state = 1;
        }
        else if (state == 2)
        {
            for (int i = 0; i < 4; i++)
            {
                if (anak[i].GetComponent<charController>().hungry == true)
                {
                    anak[i].GetComponent<charController>().hungry = false;
                    anak[i].GetComponent<charController>().hungerTimer = anak[i].GetComponent<charController>().defhungerTimer;
                    break;
                }
            }
            state = 0;
        }
        else if (state == 3)
            state = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi" && button.activeSelf == false && state != 1)
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
