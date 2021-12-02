using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveElevator : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    public float distance = 2;
    private float speed = 1;

    private bool turnBack = false;
    void Start()
    {
        pos1 = new Vector3(transform.position.x, transform.position.y + distance, 0f);
        pos2 = new Vector3(transform.position.x, transform.position.y - distance, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y>= pos1.y)
        {
            turnBack = true;
        }
        if (transform.position.y<=pos2.y)
        {
            turnBack = false;
        }
        if (turnBack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1, speed * Time.deltaTime);

        }
        if (turnBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
        }
    }
}
