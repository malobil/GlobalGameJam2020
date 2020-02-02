using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public List<Image> lifeIcons ;
    private int currentLifeIdx = 0;
    public GameObject gameOverUI;

    public TextMeshProUGUI gameOverScore;

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

    public void DamageUI()
    {
        lifeIcons[currentLifeIdx].color 
            = new Color(lifeIcons[currentLifeIdx].color.r, lifeIcons[currentLifeIdx].color.g, lifeIcons[currentLifeIdx].color.b, 1f);
        currentLifeIdx++;
    }

    public void ShowGameOver()
    {
        gameOverScore.text = Script_GameManager.Instance.currentScore.ToString("");
        gameOverUI.SetActive(true);
    }
}


