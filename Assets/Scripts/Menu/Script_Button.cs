using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Button : MonoBehaviour
{
    public enum ButtonType { Play, ShowHide, Quit}
    public ButtonType bType;
    public Sprite normalSprite;
    public Sprite highlightSprite;
    public GameObject objectToShow;
    public GameObject objectToHide;
    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void UnLight()
    {
        spr.sprite = normalSprite;
    }

    public void Highlight()
    {
        spr.sprite = highlightSprite;
    }

    public void Interact()
    {
        switch(bType)
        {
            case ButtonType.Play:
                Script_Menu.Instance.StartTransition();
                break;
            case ButtonType.ShowHide:
                ShowUI();
                HideUI();
                break;
            case ButtonType.Quit:
                Application.Quit();
                Debug.Log("Quit");
                break;
        }
    }

    void ShowUI()
    {
        objectToShow.SetActive(true);
    }

    void HideUI()
    {
        objectToHide.SetActive(false);
    }
}
