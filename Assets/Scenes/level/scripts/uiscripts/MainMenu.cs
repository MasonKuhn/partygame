using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI mainMenuText;
    public GameObject startButton;
    public GameObject restartButton;
    public GameObject introText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public float introDuration = 2f;

    private TimerScript timerScript;
    private Movement playerMovement;
    private OxygenSpawner oxygenSpawner;

    void Start()
    {
        gameObject.SetActive(true);

        timerScript = FindObjectOfType<TimerScript>();
        playerMovement = FindObjectOfType<Movement>();
        oxygenSpawner = FindObjectOfType<OxygenSpawner>();

        if (timerScript != null)
        {
            timerScript.StopTimer();
        }

        if (playerMovement != null)
        {
            playerMovement.StopMovement();
        }

        if (mainMenuText != null)
        {
            mainMenuText.gameObject.SetActive(true);
        }

        if (startButton != null)
        {
            startButton.SetActive(true);
        }

        if (introText != null)
        {
            introText.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }
    }

    public void StartGame()
    {
        gameObject.SetActive(false);

        if (mainMenuText != null)
        {
            mainMenuText.gameObject.SetActive(false);
        }

        if (startButton != null)
        {
            startButton.SetActive(false);
        }

        if (introText != null)
        {
            introText.SetActive(true);
            Invoke(nameof(StartGameplay), introDuration);
        }

        if (oxygenSpawner != null)
        {
            oxygenSpawner.ResetScore();
        }

        if (playerMovement != null)
        {
            playerMovement.StopMovement();
            playerMovement.transform.position = new Vector3(0f, 0f, playerMovement.transform.position.z);
        }
    }

    void StartGameplay()
    {
        if (introText != null)
        {
            introText.SetActive(false);
        }

        if (timerScript != null)
        {
            timerScript.StartTimer();
        }

        if (playerMovement != null)
        {
            playerMovement.StartMovement();
            playerMovement.transform.position = new Vector3(0f, 0f, playerMovement.transform.position.z);
        }
    }

    public void RestartGame()
    {
        gameObject.SetActive(false);

        if (oxygenSpawner != null)
        {
            oxygenSpawner.ResetScore();
        }

        if (timerScript != null)
        {
            timerScript.ResetTimer(10f);
            timerScript.StartTimer();
        }

        if (playerMovement != null)
        {
            playerMovement.StartMovement();
            playerMovement.transform.position = new Vector3(0f, 0f, playerMovement.transform.position.z);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }

        if (winScreen != null)
        {
            winScreen.SetActive(false);
        }

        if (loseScreen != null)
        {
            loseScreen.SetActive(false);
        }
    }

    public void ShowWinScreen()
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

        TimerScript timer = FindObjectOfType<TimerScript>();
        if (timer != null)
        {
            timer.StopTimer();
        }
    }

    public void LoadMainMenu()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(false);
        }

        if (loseScreen != null)
        {
            loseScreen.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }

        gameObject.SetActive(true);

        if (mainMenuText != null)
        {
            mainMenuText.gameObject.SetActive(true);
        }

        if (startButton != null)
        {
            startButton.SetActive(true);
        }

        if (oxygenSpawner != null)
        {
            oxygenSpawner.ResetScore();
        }

        if (timerScript != null)
        {
            timerScript.ResetTimer(10f);
        }

        if (playerMovement != null)
        {
            playerMovement.StopMovement();
            playerMovement.transform.position = new Vector3(0f, 0f, playerMovement.transform.position.z);
        }
    }
}