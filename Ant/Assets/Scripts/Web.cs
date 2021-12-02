using UnityEngine;

public class Web : MonoBehaviour
{
    private Ant ant;
    private void Start()
    {
        ant = FindObjectOfType<Ant>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            if (this.ant.killed != null)
            {
                this.ant.killed.Invoke();
            }
        }
    }
}
