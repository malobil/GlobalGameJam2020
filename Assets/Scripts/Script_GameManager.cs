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

    public Transform burgerSpawnPoint;

    public float currentSpeed = 3f;
    public float timeToSpawnABurger = 3f;

    public int currentScore = 0;

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
        Script_UIManager.Instance.UpdateScore(currentScore);
        SpawnARandomBurger();
        StartCoroutine(WaitSpawn());
    }

    public void SpawnARandomBurger()
    {
        int randomBurgerIdx = Random.Range(0, 5);
        BurgerType burgerToSpawn = BurgerType.good ; 

        switch(randomBurgerIdx)
        {
            case 0:
                burgerToSpawn = BurgerType.good;
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
            case 4:
                burgerToSpawn = BurgerType.divide;
                break;
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

        newBurger.GetComponent<Script_Burger>().moveSpeed = currentSpeed;
    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(timeToSpawnABurger);
        SpawnARandomBurger();
        StartCoroutine(WaitSpawn());
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        Script_UIManager.Instance.UpdateScore(currentScore);
    }
}
