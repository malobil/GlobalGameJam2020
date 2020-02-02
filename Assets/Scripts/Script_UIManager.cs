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

    public GameObject inputIndicationPrefab;
    public Transform inputIndicationHolder;
    public TextMeshProUGUI gameOverScore;

    public List<InputsUI> inputUIList;

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

    public GameObject SpawnInputIndication(BurgerType bType)
    {
        int inputsUIIdx = 0;

        if(Gamepad.current != null)
        {
            if(Gamepad.current.displayName == "Xbox Controller")
            {
                inputsUIIdx = 1;
                
            }
            else if(Gamepad.current.displayName == "Wireless Controller")
            {
                inputsUIIdx = 2;
            }

            Debug.Log(Gamepad.current.displayName);
        }
       

        GameObject uiSpawned = Instantiate(inputIndicationPrefab, inputIndicationHolder);
        Image spawnedImg = uiSpawned.GetComponent<Image>();
        
        switch(bType)
        {
            case BurgerType.divide:
                spawnedImg.sprite = inputUIList[inputsUIIdx].tongsInputSpr;
                break;
            case BurgerType.good:
                spawnedImg.sprite = inputUIList[inputsUIIdx].nothingInputSpr;
                break;
            case BurgerType.hight:
                spawnedImg.sprite = inputUIList[inputsUIIdx].spatuleInputSpr;
                break;
            case BurgerType.longer:
                spawnedImg.sprite = inputUIList[inputsUIIdx].knifeInputSpr;
                break;
            case BurgerType.small:
                spawnedImg.sprite = inputUIList[inputsUIIdx].suckerInputSpr;
                break;
        }

        return uiSpawned;
    }

    public void UpdateInputIndicationPosition(GameObject inputIndication, float positionPercent)
    {
        float newPosition = Screen.width * (positionPercent/100) ;
        inputIndication.GetComponent<RectTransform>().position = new Vector2(newPosition, inputIndication.GetComponent<RectTransform>().position.y);
    }
}

[System.Serializable]
public class InputsUI
{
    public string controllerName;
    public Sprite spatuleInputSpr;
    public Sprite tongsInputSpr;
    public Sprite knifeInputSpr;
    public Sprite suckerInputSpr;
    public Sprite nothingInputSpr;
}
