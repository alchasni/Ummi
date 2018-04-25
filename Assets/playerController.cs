using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public VirtualAnalog joystick;
    public float speed = 0.1f;
    private Rigidbody2D rigid;
    public GameObject loading;
    public bool diam;
    

    private void Start()
    {
        diam = false;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (loading.activeSelf == false && !diam)
        {
            Vector3 pos = this.transform.position;
            Vector3 pos2 = joystick.InputDirection;
            Vector3 zero = new Vector3(0, 0, 0);
            if (pos2 != zero)
            {
                GetComponent<Animator>().SetBool("jalan", true);
                if (pos2.x > 0)
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                else if (pos2.x < 0)
                    transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                GetComponent<Animator>().SetBool("jalan", false);
            }

            this.transform.position = new Vector3(pos.x + pos2.x * speed, pos.y + pos2.y * speed, pos.z);
            //rigid.AddForce(joystick.InputDirection * speed * Time.deltaTime);
        }
    }
}
