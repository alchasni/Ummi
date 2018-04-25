using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class computerController : MonoBehaviour {

    public GameObject vas;
    public GameObject tv;
    public GameObject toilet;
    public GameObject lamp;
    public GameObject[] anak;
    bool free;
    bool fams;
    bool work;
    public float progress;

    public GameObject text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.GetComponent<Text>().text = progress.ToString();
        if(progress >= 150f)
        {
            SceneManager.LoadScene(3);

        }
        if (work)
        {
            GetComponent<Animator>().SetBool("working", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("working", false);
        }
        for (int i = 0; i < 4; i++)
        {
            if (anak[i].GetComponent<charController>().hungry || anak[i].GetComponent<charController>().dirty)
            {
                fams = false;
                break;
            }
            if (i == 3)
                fams = true;
        }
        if (vas.GetComponent<mejaController>().state == 0
            && tv.GetComponent<Animator>().GetBool("on") == false
            && toilet.GetComponent<toiletController>().state == 0
            && lamp.GetComponent<lampuController>().state == 0
            && fams)
        {
            free = true;
        }
        else
            free = false;
        if (!free)
        {
            work = false;
        }
        if (work)
        {
            progress += 0.1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi" && free)
        {
            work = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "umi")
        {
            work = false;
        }
    }
}
