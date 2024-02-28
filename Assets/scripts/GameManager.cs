// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// using System;
// public class GameManager : MonoBehaviour
// {
//     public static GameManager Instance { get; private set; }
//     public Flappingo flappingo;
//     public TextMeshProUGUI scoreText;
//     public GameObject playButton;
//     public GameObject gameOver;
//     private int score;
//     public event Action OnGameStarted;
//     public event Action OnGameOver;
//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//         Application.targetFrameRate = 60;
//         Pause();
//     }
//     public bool IsGameStarted { get; private set; }
//     public bool IsGameOver { get; private set; }

//     public void Play()
//     {
//         score=0;
//         scoreText.text= score.ToString();

//         playButton.SetActive(false);
//         gameOver.SetActive(false);
//         Time.timeScale= 1f;
//         flappingo.enabled=true;

//         Pipe[] pipe= FindObjectsOfType<Pipe>();

//         for(int i=0; i<pipe.Length; i++){
//             Destroy(pipe[i].gameObject);
//         }

//     }
//     public void Pause()
//     {
//         Time.timeScale = 0f;
//         flappingo.enabled= false;
//          IsGameStarted = false;

//     }


//    public void GameOver()
//    {
//     gameOver.SetActive(true);
//     playButton.SetActive(true);
//     Pause();
//     IsGameOver = true;
//    }
//    public void IncreaseScore()
//    {
//      score++;
//      scoreText.text = score.ToString();
//    }
// }



using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Flappingo flappingo;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject FlappyBird;
    public GameObject Developed;
    public GameObject Name;

    public AudioSource backgroundMusic; // Reference to the background music audio source

    public int score;

    // Define events for game start and game over
    public event Action OnGameStarted;
    public event Action OnGameOver;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Set the target frame rate
        Application.targetFrameRate = 60;

        // Pause the game initially
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        FlappyBird.SetActive(false);
        Developed.SetActive(false);
        Name.SetActive(false);
        Time.timeScale = 1f;
        flappingo.enabled = true;

        // Trigger the OnGameStarted event
        OnGameStarted?.Invoke();

        Pipe[] pipe = FindObjectsOfType<Pipe>();

        for (int i = 0; i < pipe.Length; i++)
        {
            Destroy(pipe[i].gameObject);
        }

        // Start playing the background music
        backgroundMusic.Play();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        flappingo.enabled = false;

        // Pause the background music
        backgroundMusic.Pause();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        FlappyBird.SetActive(true);
        Developed.SetActive(true);
        Name.SetActive(true);
        playButton.SetActive(true);
        Pause();
        

        // Trigger the OnGameOver event
        OnGameOver?.Invoke();

        // Stop the background music
        backgroundMusic.Stop();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}

