using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Button : MonoBehaviour
{
    public enum ButtonType { Play, Tuto, Quit}
    public ButtonType bType;

    public void Interact()
    {
        switch(bType)
        {
            case ButtonType.Play:
                Debug.Log("Play");
                break;
            case ButtonType.Tuto:
                Debug.Log("Tuto");
                break;
            case ButtonType.Quit:
                Application.Quit();
                Debug.Log("Quit");
                break;
        }
    }
}
