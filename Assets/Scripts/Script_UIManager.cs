using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;

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
}
