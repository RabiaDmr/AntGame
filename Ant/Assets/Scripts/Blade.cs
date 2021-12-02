using UnityEngine;

public class Blade : MonoBehaviour
{
    float rotationSpeed = 1;
    float speed = 2;
    private Vector3 pos1;
    private Vector3 pos2;
    private float distance = 2.35f;
    private bool turnBack = false;

    private Ant ant;

    void Start()
    {
        ant = FindObjectOfType<Ant>();
        pos1 = new Vector3(transform.position.x + distance, transform.position.y, 0);
        pos2 = new Vector3(transform.position.x - distance, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);

        if (transform.position.x >= pos1.x)
        {
            turnBack = true;
        }
        if (transform.position.x <= pos2.x)
        {
            turnBack = false;
        }
        if (turnBack == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1, speed * Time.deltaTime);

        }
        if (turnBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ant.killed != null )
            {
                ant.killed.Invoke();
            }
        }
    }
}
