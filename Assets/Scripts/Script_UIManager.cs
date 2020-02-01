using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverUI;

    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;
        }
       else
        {
            Destroy(this);
        }
    }

    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString("");
    }

    public void UpdateLife(int newLife)
    {
        lifeText.text = "Life : " + newLife.ToString("");
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
    }
}
