using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spears : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    private float speed = 0.5f;

    private bool turnBack;

    private Ant ant;

    private void Start()
    {
        ant = FindObjectOfType<Ant>();
    }

    void Update()
    {
        if (transform.position.y >= pos1.position.y)
        {
            turnBack = true;
        }
        if (transform.position.y <= pos2.position.y)
        {
            turnBack = false;
        }
        if (turnBack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.position, this.speed * Time.deltaTime);
        }
        if (turnBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.position, this.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ant.killed != null)
            {
                ant.killed.Invoke();
            }
            
        }
    }
}
