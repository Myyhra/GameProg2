using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MidtermGameManager : MonoBehaviour
{
    public static MidtermGameManager Instance;

    public Color colorRed = new Color(1,0,0);
    public Color ColorGreen = new Color(0,1,0);
    public Color ColorBlue = new Color(0,0,1);
    public Color currentColor;
    public int colorCycle = 1;

    List<GameObject> enemy = new List<GameObject>();
    [SerializeField] int capacity;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> enemySpawners = new List<GameObject>();
    [SerializeField] float interval =1f;
    int randomEnemySpawn;
    public int enemyColorInt;
    GameObject enem;

    public GameObject gameOver;
    void Awake()
    {
        if (Instance != null && Instance!=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        EnemyPooling();
    }
    
    void Start()
    {
        StartCoroutine(SpawnInterval());
    }

    
    void Update()
    {
        ColorCycle();
    }

    IEnumerator SpawnInterval()
    {
        randomEnemySpawn  = UnityEngine.Random.Range(1, 5);
        enemyColorInt = UnityEngine.Random.Range(1, 4);
        yield return new WaitForSeconds(interval);
        SpawnEnemies(randomEnemySpawn);
        
        StartCoroutine(SpawnInterval());

    }

    void SpawnEnemies(int spawner)
    {
        enem = GetPooledObject();

        if (enemy != null)
        {
            enem.transform.position = enemySpawners[spawner-1].transform.position;
            enem.SetActive(true);
        }
    }
    void EnemyPooling()
    {
        for(int i = 0; i < capacity; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            enemy.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            if(!enemy[i].activeInHierarchy)
            {
                return enemy[i];
            }
        }
        return null;
    }

    public void ColorCycle()
    {
        if(colorCycle == 1)
        {currentColor = colorRed;}
        else if(colorCycle == 2)
        {currentColor = ColorGreen;}
        else if (colorCycle == 3)
        {currentColor = ColorBlue;}

        if(colorCycle > 3 || colorCycle <1)
        {
            colorCycle = 1;
        }
        Debug.Log(colorCycle);
        
    }
}
