using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    Ant ant;

    private void Start()
    {
        ant = transform.root.gameObject.GetComponent<Ant>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ant.groundCheck = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ant.groundCheck = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ant.groundCheck = false;
    }
}
