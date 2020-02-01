using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ToolType { Spatule, Knife, Sucker, Tongs}

public class Script_Player : MonoBehaviour
{
    public GameObject spatule, knife, sucker, tongs;
    private Animator animatorComp;
    private bool canUseTool = true;
    private InGameInputs inputs;
    private GameObject currentTargetBurger ;


    private void Awake()
    {
        inputs = new InGameInputs();
        animatorComp = GetComponent<Animator>();
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
        Script_GameManager.Instance.SpawnSpecificBurger(BurgerType.good, currentTargetBurger.transform.position);

        if(currentTargetBurger.GetComponent<Script_Burger>().type == BurgerType.longer)
        {
            Script_GameManager.Instance.SpawnSpecificBurger(BurgerType.good, new Vector3(
                currentTargetBurger.transform.position.x - 1.2f, currentTargetBurger.transform.position.y, currentTargetBurger.transform.position.z));
        }
        Destroy(currentTargetBurger.transform.root.gameObject);
    }

    void BadTool()
    {

    }

    public void AllowToolUse()
    {
        canUseTool = true;
    }

    public void ForbidToolUse()
    {
        canUseTool = false;
    }

    public void UseSpatule(InputAction.CallbackContext context)
    {
        if(canUseTool)
        {
            CheckUsedTool(ToolType.Spatule);
            animatorComp.SetTrigger("UseSpatule");
            ForbidToolUse();
        }
    }

    public void UseKnife(InputAction.CallbackContext context)
    {
        if (canUseTool)
        {
            CheckUsedTool(ToolType.Knife);
            animatorComp.SetTrigger("UseKnife");
            ForbidToolUse();
        }
    }

    public void UseTongs(InputAction.CallbackContext context)
    {
        if (canUseTool)
        {
            CheckUsedTool(ToolType.Tongs);
            animatorComp.SetTrigger("UseTongs");
            ForbidToolUse();
        }
    }

    public void UseSucker(InputAction.CallbackContext context)
    {
        if (canUseTool)
        {
            CheckUsedTool(ToolType.Sucker);
            animatorComp.SetTrigger("UseSucker");
            ForbidToolUse();
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
            currentTargetBurger = other.transform.root.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Script_Burger>())
        {
            currentTargetBurger = null;
        }
    }
}
