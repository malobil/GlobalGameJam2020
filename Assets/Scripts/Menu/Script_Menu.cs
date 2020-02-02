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

    public List<Script_Button> buttons;
    private int currentButtonSelected = 0;

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
        inputs.InMenu.Up.performed += ctx => UpButton();
        inputs.InMenu.Down.performed += ctx => DownButton();
        inputs.Enable();
    }

    private void Start()
    {
        SelectButton();
    }

    private void OnDisable()
    {
        inputs.InMenu.Submit.performed -= ctx => PressButton();
        inputs.InMenu.Up.performed -= ctx => UpButton();
        inputs.InMenu.Down.performed -= ctx => DownButton();
        inputs.Disable();
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
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1;
        GameMenuTransition();
        gameManager.SetActive(false);
        UIManager.SetActive(false);
        player.enabled = false;
        gameIsRunning = false;
    }

    private void UpButton()
    {
        if (currentButtonSelected > 0)
        {
            currentButtonSelected--;
            SelectButton();
        }
    }

    private void DownButton()
    {
        if (currentButtonSelected < buttons.Count-1)
        {
            currentButtonSelected++;
            SelectButton();
        }
    }

    void SelectButton()
    {
        if (lastButtonSelected != null)
        {
            lastButtonSelected.UnLight();
        }

        lastButtonSelected = buttons[currentButtonSelected];
        lastButtonSelected.Highlight();
    }

    private void PressButton()
    {
       if(lastButtonSelected != null)
        {
            lastButtonSelected.Interact();
        }
    }

}
