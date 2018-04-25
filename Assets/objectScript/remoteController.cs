using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remoteController : MonoBehaviour
{
    public GameObject button;
    public GameObject icon;

    public GameObject tv;

    public void Pressed()
    {
        tv.GetComponent<Animator>().SetBool("on", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi" && tv.GetComponent<Animator>().GetBool("on") == true)
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
