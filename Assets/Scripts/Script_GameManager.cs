using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GameManager : MonoBehaviour
{
    public static Script_GameManager Instance { get; private set; }

    [Header("SPAWN")]
    public List<GameObject> burgerPrefabs;
    public Transform burgerSpawnPoint;

    public float timeToSpawnABurger = 3f;

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
        SpawnABurger();
        StartCoroutine(WaitSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnABurger()
    {
        int randomBurgerIdx = Random.Range(0, burgerPrefabs.Count);
        Instantiate(burgerPrefabs[randomBurgerIdx], burgerSpawnPoint.position,Quaternion.identity);
    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(timeToSpawnABurger);
        SpawnABurger();
        StartCoroutine(WaitSpawn());
    }
}
