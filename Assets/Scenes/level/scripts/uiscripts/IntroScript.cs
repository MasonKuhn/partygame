using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float introDuration = 2f;

    private float timer = 0f;

    void Start()
    {
        introText.text = "{IntroText}";
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= introDuration)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}