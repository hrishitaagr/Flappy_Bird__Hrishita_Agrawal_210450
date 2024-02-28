using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private bool musicStarted = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.OnGameStarted += StartMusic;
        GameManager.Instance.OnGameOver += StopMusic;
    }

    void StartMusic()
    {
        if (!musicStarted)
        {
            audioSource.Play();
            musicStarted = true;
        }
    }

    void StopMusic()
    {
        audioSource.Stop();
        musicStarted = false;
    }

    void OnDestroy()
    {
        GameManager.Instance.OnGameStarted -= StartMusic;
        GameManager.Instance.OnGameOver -= StopMusic;
    }
}


