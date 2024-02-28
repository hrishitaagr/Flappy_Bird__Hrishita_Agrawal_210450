// using UnityEngine;

// public class PauseManager : MonoBehaviour
// {
//     public GameObject pauseIcon; // Reference to the pause icon game object
//     public AudioSource backgroundMusic; // Reference to the background music audio source
//     public AudioClip pauseSound; // Sound effect to play when pausing

//     private bool isPaused = false;

//     private void Update()
//     {
//         // Check for "P" key input to toggle pause state
//         if (Input.GetKeyDown(KeyCode.P))
//         {
//             TogglePause();
//         }
//     }

//     public void Pause()
//     {
//         if (!isPaused)
//         {
//             isPaused = true;

//             Time.timeScale = 0f;

//             // Pause the background music
//             if (backgroundMusic != null)
//                 backgroundMusic.Pause();

//             // Play pause sound effect
//             if (pauseSound != null)
//                 AudioSource.PlayClipAtPoint(pauseSound, Camera.main.transform.position);

//             // Show pause icon
//             if (pauseIcon != null)
//                 pauseIcon.SetActive(true);
//         }
//     }

//     public void Unpause()
//     {
//         if (isPaused)
//         {
//             isPaused = false;

//             Time.timeScale = 1f;

//             // Unpause the background music
//             if (backgroundMusic != null)
//                 backgroundMusic.UnPause();

//             // Hide pause icon
//             if (pauseIcon != null)
//                 pauseIcon.SetActive(false);
//         }
//     }

//     public void TogglePause()
//     {
//         if (isPaused)
//         {
//             Unpause();
//         }
//         else
//         {
//             Pause();
//         }
//     }
// }


using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseIcon; // Reference to the pause icon game object
    public AudioSource backgroundMusic; // Reference to the background music audio source
    public AudioClip pauseSound; // Sound effect to play when pausing

    private bool isPaused = false;

    private void Update()
    {
        // Check for "P" key input to toggle pause state
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;

            Time.timeScale = 0f;

            // Pause the background music
            if (backgroundMusic != null)
                backgroundMusic.Pause();

            // Play pause sound effect
            if (pauseSound != null)
                AudioSource.PlayClipAtPoint(pauseSound, Camera.main.transform.position);

            // Show pause icon
            UpdatePauseIconVisibility(true);
        }
    }

    public void Unpause()
    {
        if (isPaused)
        {
            isPaused = false;

            Time.timeScale = 1f;

            // Unpause the background music
            if (backgroundMusic != null)
                backgroundMusic.UnPause();

            // Hide pause icon
            UpdatePauseIconVisibility(false);
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    private void UpdatePauseIconVisibility(bool visible)
    {
        if (pauseIcon != null)
        {
            pauseIcon.SetActive(visible);
        }
        else
        {
            Debug.LogWarning("Pause icon reference is not set.");
        }
    }
}
