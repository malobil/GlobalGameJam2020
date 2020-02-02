using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{
    public static Script_Menu Instance { get; private set; }
    public GameObject menuCamera;
    public GameObject inGameCamera;
    public Transform transitionCamera;
    public Transform cameraIngame;
    public float cameraTranstionSpeed = 1.3f;
    public float cameraTranstionRotationSpeed = 1f;

    private InGameInputs inputs;
    private Vector2 mousePosition;
    private Script_Button lastButtonSelected;

    public Script_Player player;
    public GameObject UIManager;
    public GameObject gameManager;
    private bool gameIsRunning = false;
    private bool gameIsOver = false;

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

        inputs = new InGameInputs();
        
        inputs.InMenu.Submit.performed += ctx => PressButton();
        inputs.InMenu.MousePosition.performed += ctx => GetMousePos(inputs.InMenu.MousePosition.ReadValue<Vector2>());
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.InMenu.MousePosition.performed -= ctx => GetMousePos(inputs.InMenu.MousePosition.ReadValue<Vector2>());
        inputs.InMenu.Submit.performed -= ctx => PressButton();
      
    }

    private void Update()
    {
        if(Camera.main.transform.position == inGameCamera.transform.position && !gameIsRunning && !gameIsOver)
        {
            StartGame(); 
        }

        if (Camera.main.transform.position == menuCamera.transform.position && gameIsOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void MenuGameTransition()
    {
        inputs.Disable();
        inGameCamera.SetActive(true);
        menuCamera.gameObject.SetActive(false);
    }

    public void GameMenuTransition()
    {
        inGameCamera.SetActive(false);
        menuCamera.gameObject.SetActive(true);
    }

    void StartGame()
    {
        gameIsOver = false;
        gameManager.SetActive(true);
        UIManager.SetActive(true);
        player.enabled = true;
        gameIsRunning = true;
        Script_MusicManager.Instance.PlayGameMusic();
    }

    public void EndGame()
    {
        gameIsOver = true;
        Script_MusicManager.Instance.StopMusic();
        StartCoroutine(WaitTransition());
    }

    public IEnumerator WaitTransition()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
        GameMenuTransition();
        gameManager.SetActive(false);
        UIManager.SetActive(false);
        player.enabled = false;
        gameIsRunning = false;
    }

    private void GetMousePos(Vector2 mousePos)
    {
        mousePosition = mousePos;

        Ray cameraRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(cameraRay, out hit))
        {
            if (hit.collider.GetComponent<Script_Button>())
            {
                if (lastButtonSelected != hit.collider.GetComponent<Script_Button>())
                {
                    hit.collider.GetComponent<Script_Button>().UnLight();
                }
                
                hit.collider.GetComponent<Script_Button>().Highlight();
                lastButtonSelected = hit.collider.GetComponent<Script_Button>();
            }
        }
        else
        {
            if(lastButtonSelected != null)
            {
                lastButtonSelected.UnLight();
            }
        }
    }

    private void PressButton()
    {
       if(lastButtonSelected != null)
        {
            lastButtonSelected.Interact();
        }
    }

}
