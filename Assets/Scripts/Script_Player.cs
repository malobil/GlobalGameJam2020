using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ToolType { Spatule, Knife, Sucker, Tongs}

public class Script_Player : MonoBehaviour
{
    public GameObject spatule, knife, sucker, tongs;
    private bool canUseTool = false;
    private InGameInputs inputs;
    private GameObject currentTargetBurger ;

    private void Awake()
    {
        inputs = new InGameInputs();
    }

    private void OnEnable()
    {
        EnableInputs();
    }

    private void OnDisable()
    {
        DisableInputs();
    }

    public void EnableInputs()
    {
        inputs.InGame.Spatule.performed += UseSpatule;
        inputs.InGame.Knife.performed += UseKnife;
        inputs.InGame.Tongs.performed += UseTongs;
        inputs.InGame.Sucker.performed += UseSucker;
        inputs.Enable();
    }

    public void DisableInputs()
    {
        inputs.InGame.Spatule.performed -= UseSpatule;
        inputs.InGame.Knife.performed -= UseKnife;
        inputs.InGame.Tongs.performed -= UseTongs;
        inputs.InGame.Sucker.performed -= UseSucker;
        inputs.Disable();
    }

    public void CheckUsedTool(ToolType usedTool)
    {
        if(currentTargetBurger != null)
        {
            BurgerType targetBurgerType = currentTargetBurger.GetComponent<Script_Burger>().type;

            if (targetBurgerType == BurgerType.hight && usedTool == ToolType.Spatule)
            {
                CorrectTool();
            }
            else if (targetBurgerType == BurgerType.longer && usedTool == ToolType.Knife)
            {
                CorrectTool();
            }
            else if (targetBurgerType == BurgerType.divide && usedTool == ToolType.Tongs)
            {
                CorrectTool();
            }
            else if (targetBurgerType == BurgerType.small && usedTool == ToolType.Sucker)
            {
                CorrectTool();
            }
            else
            {
                BadTool();
            }
        }
        else
        {
            BadTool();
        }
    }

    void CorrectTool()
    {
        Script_GameManager.Instance.AddScore(currentTargetBurger.GetComponentInParent<Script_Burger>().scoreValue);
        Destroy(currentTargetBurger.transform.root.gameObject);
        Debug.Log("Correct");
        canUseTool = false;
    }

    void BadTool()
    {
        canUseTool = false;
    }

    void ToolAnimation()
    {

    }

    public void UseSpatule(InputAction.CallbackContext context)
    {
        if(canUseTool)
        {
            CheckUsedTool(ToolType.Spatule);
            Debug.Log("Spatule");
        }
    }

    public void UseKnife(InputAction.CallbackContext context)
    {
        if (canUseTool)
        {
            CheckUsedTool(ToolType.Knife);
            Debug.Log("Knife");
        }
    }

    public void UseTongs(InputAction.CallbackContext context)
    {
        if (canUseTool)
        {
            CheckUsedTool(ToolType.Tongs);
            Debug.Log("Tongs");
        }
    }

    public void UseSucker(InputAction.CallbackContext context)
    {
        if (canUseTool)
        {
            CheckUsedTool(ToolType.Sucker);
            Debug.Log("Sucker");
        }
    }

    public void HideTool(ToolType toolToHide)
    {
        switch(toolToHide)
        {
            case ToolType.Spatule:
                spatule.SetActive(false);
                break;
            case ToolType.Knife:
                knife.SetActive(false);
                break;
            case ToolType.Sucker:
                sucker.SetActive(false);
                break;
            case ToolType.Tongs:
                tongs.SetActive(false);
                break;
        }
    }

    public void ShowTool(ToolType toolToHide)
    {
        switch (toolToHide)
        {
            case ToolType.Spatule:
                spatule.SetActive(true);
                break;
            case ToolType.Knife:
                knife.SetActive(true);
                break;
            case ToolType.Sucker:
                sucker.SetActive(true);
                break;
            case ToolType.Tongs:
                tongs.SetActive(true);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Script_Burger>())
        {
            currentTargetBurger = other.transform.parent.gameObject;
            canUseTool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Script_Burger>())
        {
            currentTargetBurger = null;
            canUseTool = false;
        }
    }
}
