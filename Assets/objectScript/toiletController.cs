using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toiletController : MonoBehaviour {

    public Sprite[] anim;
    public int state;
    public GameObject button;
    public GameObject icon;

    // Use this for initialization
    void Start()
    {
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = anim[state];
    }

    public void Pressed() { state = (state + 1) % 2; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi" && button.activeSelf == false && state != 0)
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
