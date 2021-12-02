using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    float speed = 2;
    private Vector3 pos1;
    private Vector3 pos2;
    private float distance = 1.75f;
    bool turnBack = false;
    public GameObject web;
    


    void Start()
    {
        

        pos1 = new Vector3(transform.position.x + distance, transform.position.y, 0);
        pos2 = new Vector3(transform.position.x - distance, transform.position.y, 0);
        InvokeRepeating(nameof(SpawnWeb), 5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x>=pos1.x)
        {
            turnBack = true;
        }
        if (transform.position.x <= pos2.x)
        {
            turnBack = false;
        }
        if (turnBack==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1, speed * Time.deltaTime);
        }
        if (turnBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
        }

        
    }

    private void SpawnWeb()
    {
        Instantiate(web, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="EnemyTrigger")
        {
            Destroy(gameObject);
        }
    }
}
