using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    public int score = 0;
    public int maxTokens = 5;
    public float respawnTime = 0.5f;
    public TextMeshProUGUI scoreText;

    private bool isCollected = false;

    void Start()
    {
        UpdateScoreUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            score++;

            UpdateScoreUI();

            if (score >= maxTokens)
            {
                EndGame();
            }
            else
            {
                StartCoroutine(Respawn());
            }

            gameObject.SetActive(false);
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);

        isCollected = false;
        gameObject.SetActive(true);
    }

    void EndGame()
    {
        Debug.Log("Game Over! You collected all tokens.");
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
        scoreText.text = $"{score}/{maxTokens}";
        }
    }
}