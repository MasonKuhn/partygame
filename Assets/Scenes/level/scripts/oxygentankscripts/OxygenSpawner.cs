using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxygenSpawner : MonoBehaviour
{
    public GameObject oxygenTankPrefab;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public Transform[] Square;

    public TMP_Text scoreText;
    public int score = 0;
    public int maxScore = 5;
    public GameObject winScreen;
    public AudioSource AudioSource;

    private Movement playerMovement;
    private GameObject currentOxygenTank;
    private Transform playerTransform;
    private List<GameObject> spawnedOxygenTanks = new List<GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ResetScore();
        SpawnOxygenTank();
        UpdateScoreUI();

        if (winScreen != null)
        {
            winScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (spawnedOxygenTanks.Count < maxScore && currentOxygenTank == null)
        {
            SpawnOxygenTank();
        }
    }

    void SpawnOxygenTank()
    {
        if (spawnedOxygenTanks.Count >= maxScore) return;

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, Square.Length);
        }
        while (randomIndex == 4 || IsPlayerOnSquare(Square[randomIndex]));

        currentOxygenTank = Instantiate(oxygenTankPrefab, Square[randomIndex].position, Quaternion.identity);
        spawnedOxygenTanks.Add(currentOxygenTank);
        currentOxygenTank.GetComponent<OxygenTank>().SetSpawner(this);
    }

    bool IsPlayerOnSquare(Transform square)
    {
        return Vector3.Distance(playerTransform.position, square.position) < 0.1f;
    }

    public void OnOxygenTankCollected()
    {
        score++;

        if (currentOxygenTank != null)
        {
            Destroy(currentOxygenTank);
        }

        currentOxygenTank = null;

        if (AudioSource != null)
        {
            AudioSource.Play();
        }

        UpdateScoreUI();

        if (score >= maxScore)
        {
            ShowWinScreen();
        }
        
        else
        {
            SpawnOxygenTank();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{score}/{maxScore}";
        }
    }

    void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }

        Movement playerMovement = FindObjectOfType<Movement>();
        
        if (playerMovement != null)
        {
            playerMovement.StopMovement();
        }
        TimerScript timer = FindObjectOfType<TimerScript>();
        
        if (timer != null)
        {
            timer.StopTimer();
        }

        DestroyOxygenTanks();
    }

    void DestroyOxygenTanks()
    {
        foreach (GameObject tank in spawnedOxygenTanks)
        {
            if (tank != null)
            {
                Destroy(tank);
            }
        }

        spawnedOxygenTanks.Clear();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
        DestroyOxygenTanks();
    }
}