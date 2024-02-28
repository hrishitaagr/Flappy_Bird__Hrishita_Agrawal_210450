using UnityEngine;

public class MedalAwarder : MonoBehaviour
{
    public GameObject bronzeMedal;
    public GameObject silverMedal;
    public GameObject goldMedal;

    // Start is called before the first frame update
    void Start()
    {
        // Hide all medals initially
        bronzeMedal.SetActive(false);
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game is over
        if (GameManager.Instance.gameOver.activeSelf)
        {
            // Show the appropriate medal based on the score
            int score = GameManager.Instance.score;
            if (score >= 1 && score <= 5)
            {
                bronzeMedal.SetActive(true);
            }
            else if (score >= 6 && score <= 10)
            {
                silverMedal.SetActive(true);
            }
            else if (score > 10)
            {
                goldMedal.SetActive(true);
            }
        }
        else
        {
            // Hide all medals if the game is not over
            bronzeMedal.SetActive(false);
            silverMedal.SetActive(false);
            goldMedal.SetActive(false);
        }
    }
}
