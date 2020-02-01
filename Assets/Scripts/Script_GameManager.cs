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

    public float currentSpeed = 3f;
    public float timeToSpawnABurger = 3f;

    public int life = 5;
    private int currentLife;
    public int currentScore = 0;

    public List<Acceleration> accelerationSetups;
    private float currentTimeToSpeedUp;
    private bool allowToSpeedUp = false ;
    private int currentAccelerationIdx = 0;

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
        currentTimeToSpeedUp = accelerationSetups[currentAccelerationIdx].newSpeed;
        Script_UIManager.Instance.UpdateScore(currentScore);
        Script_UIManager.Instance.UpdateLife(currentLife);
        SpawnARandomBurger();
        StartCoroutine(WaitSpawn());
     
    }

    private void Update()
    {
        SpeedUpCountDown();
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
            burgers.GetComponent<Script_Burger>().Move(Vector3.left, currentSpeed);
        }

        Debug.Log("speed up");
    }

    public void SetNewSpawnTime(float newSpawnRate)
    {
        timeToSpawnABurger = newSpawnRate;
    }

    void SpeedUp()
    {
        currentAccelerationIdx++;

        if(currentAccelerationIdx < accelerationSetups.Count)
        {
            SetNewSpeed(accelerationSetups[currentAccelerationIdx].newSpeed);
            SetNewSpawnTime(accelerationSetups[currentAccelerationIdx].newSpawnTime);
            currentTimeToSpeedUp = accelerationSetups[currentAccelerationIdx].timeToSpeedUp;
            allowToSpeedUp = false;
        }
       
    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(timeToSpawnABurger);
        SpawnARandomBurger();

        if (allowToSpeedUp)
        {
            SpeedUp();
        }

        StartCoroutine(WaitSpawn());
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

    void SpeedUpCountDown()
    {
        if(currentTimeToSpeedUp > 0)
        {
            currentTimeToSpeedUp -= Time.deltaTime;
        }
        else
        {
            allowToSpeedUp = true;
        }
    }
}

[System.Serializable]
public class Acceleration
{
    public string phaseName = "Phase 0";
    public float timeToSpeedUp;
    public float newSpeed;
    public float newSpawnTime;
}
