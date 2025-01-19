using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerTxt;
    public GameObject loseScreen;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public OxygenSpawner oxygenSpawner;

    void Start()
    {
        TimerOn = false;

        if (loseScreen != null)
        {
            loseScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                CheckLoseCondition();
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime = Mathf.Max(currentTime, 0);

        int seconds = Mathf.FloorToInt(currentTime);
        int milliseconds = Mathf.FloorToInt((currentTime - seconds) * 1000);

        TimerTxt.text = $"{seconds:D2}:{milliseconds:D3}";
    }

    void CheckLoseCondition()
    {
        if (oxygenSpawner != null && oxygenSpawner.score < oxygenSpawner.maxScore)
        {
            ShowLoseScreen();
        }
    }

    void ShowLoseScreen()
    {
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
        }
    
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }

        Movement playerMovement = FindObjectOfType<Movement>();
        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }
    }
    
    public void StartTimer()
    {
        TimerOn = true;
    }
    
    public void StopTimer()
    {
        TimerOn = false;
    }

    public void ResetTimer(float resetTime)
    {
        TimeLeft = resetTime;
        StopTimer();
    }
}
