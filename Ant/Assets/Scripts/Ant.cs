using UnityEngine;
using UnityEngine.SceneManagement;


public class Ant : MonoBehaviour
{
    public float speed = 20f;
    public float jumpSpeed = 30f;

    public bool groundCheck;

    private Rigidbody2D rb;
    private Animator anim;
    private Animator animBridge;
    private Animator animElevator;
    private Animator animClick;

    public System.Action killed;
    public System.Action scored;

    private GameManager gm;

    public GameObject bridge;
    public GameObject elevator;
    public GameObject click;
    public GameObject winUI;

    public bool OnClick = false;
    public bool ElevatorCheck = false;








    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("BackGround");
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        animBridge = bridge.GetComponent<Animator>();
        animElevator = elevator.GetComponent<Animator>();
        animClick = click.GetComponent<Animator>();

        
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (groundCheck == true)
            {
                rb.AddForce(Vector2.up * jumpSpeed);
            }
            else
            {
                rb.AddForce(Vector2.up * 0f);
            }

        }
    }


    private void FixedUpdate()
    {
        float _direction = Input.GetAxis("Horizontal");

        if (_direction>0)
        {
            this.transform.Translate(_direction * speed * Time.deltaTime, 0, 0);
            
        }
        if (_direction<0)
        {
            this.transform.Translate(_direction * speed * Time.deltaTime, 0, 0);
            
        }
        



        //rb.AddForce(Vector2.right * _direction * this.speed);
        anim.SetBool("GroundCheck", groundCheck);
        anim.SetFloat("Speed", Mathf.Abs(_direction));
        animBridge.SetBool("OnClick", OnClick);
        animElevator.SetBool("ElevatorCheck", ElevatorCheck);
        animClick.SetBool("OnClick", OnClick);
        

        if (_direction > 0.1)
        {
            transform.localScale = new Vector2(1, 1);

        }
        else if (_direction < -0.1)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Coin")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            other.gameObject.SetActive(false);
            if (this.scored != null)
            {
                this.scored.Invoke();
            }

        }

        if (other.gameObject.tag=="Border")
        {

            if (this.killed != null)
            {
                this.killed.Invoke();
            }
        }

        if (other.gameObject.tag == "CheckPoint")
        {
            gm.checkPoint = other.gameObject;
        }

        if (other.gameObject.tag == "Click")
        {
            OnClick = true;
        }
        if (other.gameObject.tag== "Elevator")
        {
            ElevatorCheck = true;
        }
        if (other.gameObject.tag== "FinishPoint")
        {
            winUI.SetActive(true);
            Time.timeScale = 0;
        }
        

        
    }

}
