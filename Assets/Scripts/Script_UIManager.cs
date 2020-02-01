using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverUI;

    public GameObject inputIndicationPrefab;
    public Transform inputIndicationHolder;

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

    public void UpdateLife(int newLife)
    {
        lifeText.text = "Life : " + newLife.ToString("");
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
    }

    public GameObject SpawnInputIndication(BurgerType bType)
    {
        int inputsUIIdx = 0;
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
