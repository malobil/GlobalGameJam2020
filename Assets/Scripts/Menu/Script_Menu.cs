using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Script_Menu : MonoBehaviour
{
    public Camera menuCamera;

    private InGameInputs inputs;
    private Vector2 mousePosition;

    private void Awake()
    {
        inputs = new InGameInputs();
        
        inputs.InMenu.Submit.performed += ctx => PressButton();
        inputs.InMenu.MousePosition.performed += ctx => GetMousePos(inputs.InMenu.MousePosition.ReadValue<Vector2>());
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.InMenu.MousePosition.performed -= ctx => GetMousePos(inputs.InMenu.MousePosition.ReadValue<Vector2>());
        inputs.Disable();
    }

    private void GetMousePos(Vector2 mousePos)
    {
        mousePosition = mousePos;
    }

    private void PressButton()
    {
       Ray cameraRay = menuCamera.ScreenPointToRay(mousePosition);
       RaycastHit hit;

       if(Physics.Raycast(cameraRay,out hit))
       {
            if(hit.collider.GetComponent<Script_Button>())
            {
                hit.collider.GetComponent<Script_Button>().Interact();
            }
            Debug.Log(hit.collider.gameObject);
       }
    }

}
