using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viraController : MonoBehaviour {

    public GameObject path;
    public Node[] PathNode;
    public float MoveSpeed;
    int CurrentNode;
    Vector3 destination;
    Transform startPosition;
    bool moving;

    public GameObject benda;

    // Use this for initialization
    void Start()
    {
        PathNode = path.GetComponentsInChildren<Node>();
        CheckNode();
    }

    void CheckNode()
    {
        startPosition = transform;
        destination = PathNode[CurrentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentNode == 5)
        {
            benda.GetComponent<mejaController>().state = 1;
        }
        moving = false;
        if (0f != Vector2.Distance(destination, transform.position))
        {
            if (destination.x > transform.position.x)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else
                transform.localScale = new Vector3(1f, 1f, 1f);

            float step = MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, destination, step);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            moving = true;
        }
        else if (!moving)
        {
            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
                moving = false;
            }
            else
            {
                CurrentNode = 0;
                CheckNode();
                moving = false;

            }
        }

    }
}
