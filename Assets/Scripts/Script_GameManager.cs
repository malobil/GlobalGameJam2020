using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GameManager : MonoBehaviour
{
    public static Script_GameManager Instance { get; private set; }

    [Header("SPAWN")]
    public GameObject burgerGood;
    public GameObject burgerSmall;
    public GameObject burgerHight;
    public GameObject burgerLong;
    public GameObject burgerDivide;
    private List<GameObject> burgerSpawned = new List<GameObject>();

    [Range(0,100)]
    public float chanceToSpawnGoodBuger = 10f;

    public Transform burgerSpawnPoint;
    public Transform burgerEndPoint;

    public float currentSpeed = 3f;
    public float speedMult = 1.2f;
    public float spawnMult = 1.2f;
    public float burgerToSpeedUpMult = 1.2f;
    public int burgerToSpawnToSpeedUp = 10;
    public Vector2 timeToSpawnABurger = new Vector2(2,3) ;
    private float currentTimeToSpawnBurger = 2f;

    public int life = 5;
    private int currentLife;
    public int currentScore = 0;

    private int burgerSpawnedThisPhase = 0;

    public Renderer tapisRenderer;
    public List<Sprite> pnjsSprite;
    public GameObject pnjObject;


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

    // Start is called before the first frame update
    void Start()
    {
        currentLife = life;
        Script_UIManager.Instance.UpdateScore(currentScore);
        Script_UIManager.Instance.UpdateLife(currentLife);
        SpawnARandomBurger();
        StartCoroutine(WaitSpawn());
        StartCoroutine(WaitPNJSpawn());
    }

    private void Update()
    {
        TapisAnimation();
    }

    void TapisAnimation()
    {
        float xOffset = -currentSpeed * Time.time;
        tapisRenderer.material.mainTextureOffset = new Vector2(xOffset, 0);
    }

    public void SpawnARandomBurger()
    {
        BurgerType burgerToSpawn = BurgerType.good;
        if (Random.Range(0,101) > chanceToSpawnGoodBuger)
        {
            int randomBurgerIdx = Random.Range(0, 4);

            switch (randomBurgerIdx)
            {
                case 0:
                    burgerToSpawn = BurgerType.divide;
                    break;
                case 1:
                    burgerToSpawn = BurgerType.hight;
                    break;
                case 2:
                    burgerToSpawn = BurgerType.longer;
                    break;
                case 3:
                    burgerToSpawn = BurgerType.small;
                    break;
            }
        }       

        SpawnSpecificBurger(burgerToSpawn, burgerSpawnPoint.transform.position);
    }

    public void SpawnSpecificBurger(BurgerType burgerToSpawn, Vector3 spawnPosition)
    {
        GameObject newBurger = null;
        switch(burgerToSpawn)
        {
            case BurgerType.good:
                newBurger = Instantiate(burgerGood, spawnPosition, Quaternion.identity);
                break;
            case BurgerType.divide:
                newBurger = Instantiate(burgerDivide, spawnPosition, Quaternion.identity);
                break;
            case BurgerType.small:
                newBurger = Instantiate(burgerSmall, spawnPosition, Quaternion.identity);
                break;
            case BurgerType.hight:
                newBurger = Instantiate(burgerHight, spawnPosition, Quaternion.identity);
                break;
            case BurgerType.longer:
                newBurger = Instantiate(burgerLong, spawnPosition, Quaternion.identity);
                break;
        }

        AddBurgerToList(newBurger);
        newBurger.GetComponent<Script_Burger>().Move(Vector3.left, currentSpeed);
        newBurger.GetComponent<Script_Burger>().associateInputUI = Script_UIManager.Instance.SpawnInputIndication(burgerToSpawn);
    }

    public void AddBurgerToList(GameObject burgerToAdd)
    {
        burgerSpawned.Add(burgerToAdd);
    }

    public void RemoveBurgerFromList(GameObject burgerToRemove)
    {
        burgerSpawned.Remove(burgerToRemove);
    }

    public void SetNewSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;

        foreach (GameObject burgers in burgerSpawned)
        {
            if(burgers != null)
            {
                burgers.GetComponent<Script_Burger>().Move(Vector3.left, currentSpeed);
            }
        }
    }

    public void SetNewSpawnTime(float newSpawnRate)
    {
        currentTimeToSpawnBurger = newSpawnRate;
    }

    public void SetNewSpawnInterval()
    {
        timeToSpawnABurger *= spawnMult;
    }

    public void NextPhase()
    {
        SetNewSpeed(currentSpeed *= speedMult);
        SetNewSpawnInterval();
        burgerSpawnedThisPhase = 0;
        burgerToSpawnToSpeedUp = Mathf.RoundToInt(burgerToSpawnToSpeedUp * burgerToSpeedUpMult);
    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(currentTimeToSpawnBurger);
        SpawnARandomBurger();
        SetNewSpawnTime(
               Random.Range(timeToSpawnABurger.x, timeToSpawnABurger.y));
        burgerSpawnedThisPhase++;

        if(burgerSpawnedThisPhase >= burgerToSpawnToSpeedUp)
        {
            NextPhase();
        }

        StartCoroutine(WaitSpawn());
    }

    IEnumerator WaitPNJSpawn()
    {
        yield return new WaitForSeconds(Random.Range(1f,4f));
        SpawnAPnj();
        StartCoroutine(WaitPNJSpawn());
    }

    void SpawnAPnj()
    {
        int rdmPnj = Random.Range(0, pnjsSprite.Count);
        int rdmAnimation = Random.Range(0, 6);
        GameObject newPnj = Instantiate(pnjObject);
        newPnj.GetComponent<SpriteRenderer>().sprite = pnjsSprite[rdmPnj];
        newPnj.GetComponent<Animator>().SetInteger("Anim", rdmAnimation);
    }

    public void AddScore(int scoreToAdd)
    {
        if(scoreToAdd + currentScore > 0)
        {
            currentScore += scoreToAdd;
           
        }
        else
        {
            currentScore = 0;
        }
        Script_UIManager.Instance.UpdateScore(currentScore);
    }

    public void SubstractLife(int lifeLost)
    {
        currentLife-= lifeLost;
        Script_UIManager.Instance.UpdateLife(currentLife);
        if(currentLife <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Script_UIManager.Instance.ShowGameOver();
        StopAllCoroutines();
        Time.timeScale = 0;
    }

    public float GetPercentDistance(Vector3 actualPos)
    {
        float distanceFromStart =
            (Vector3.Distance(burgerSpawnPoint.position, actualPos) / Vector3.Distance(burgerSpawnPoint.position, burgerEndPoint.position))*100f;
        return distanceFromStart;
    }
}