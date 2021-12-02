using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private Ant ant;

    public GameObject[] liveHearts;
    public GameObject gameOverUI;
    public Text scoreText;

    public int lives { get; private set; }
    public int score { get; private set; }

    public GameObject startPoint;
    public GameObject checkPoint;

    private void Awake()
    {
        this.ant = FindObjectOfType<Ant>();
        Time.timeScale = 1;
        
        
    }

    private void Start()
    {
        this.ant.transform.position = startPoint.transform.position;
        this.ant.killed += OnAntKilled;
        this.ant.scored += OnAntScored;
        NewGame();
    }

    private void NewGame()
    {
        SetLives(3);
        SetScore(0);
        NewRound();
    }
    private void SetLives(int lives)
    {
        this.lives = Mathf.Max(lives, 0);

        for (int i = 0; i < lives; i++)
        {
            liveHearts[i].SetActive(true);
        }
        

    }

    private void SetScore(int score)
    {
        this.score = score;
        this.scoreText.text = this.score.ToString().PadLeft(4,'0');
    }
    private void OnAntKilled()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        this.ant.gameObject.SetActive(false);
        for (int i = 0; i < lives; i++)
        {
            liveHearts[i].SetActive(false);
        }

        SetLives(lives - 1);

        if (this.lives >0)
        {
            Invoke(nameof(NewRound), 1.0f);
        }
        else if (this.lives <= 0)
        {
            GameOver();

        }
        
            

    }
    void OnAntScored()
    {
        SetScore(this.score + 10);
    }

    void GameOver()
    {
        this.gameOverUI.SetActive(true);

    }
    void NewRound()
    {
        if (checkPoint != null)
        {
            this.ant.transform.position = checkPoint.transform.position;
        }
        else
        {
            this.ant.transform.position = startPoint.transform.position;
        }
        this.ant.gameObject.SetActive(true);
        this.ant.ElevatorCheck = false;
        
        
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
