using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

// using Obstaclesmove;
public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> Spawner;
    public List<GameObject> Obstacles;
    public GameObject point;
    int randomSpawnValue;
    int _object;
    [SerializeField] float speed = 1.0f;
    void Start()
    {
        StartCoroutine("PickSpawner");
    }
    void Update()
    {

    }

    IEnumerator PickSpawner()
    {

        yield return new WaitForSeconds(3);
        randomSpawnValue = Random.Range(1, 7);
        _object = Random.Range(1,3);
        if (_object <= 1)
        {
            ObstacleSpawn(randomSpawnValue);
        }
        else if (_object >= 2)
        {
            PointSpawn(randomSpawnValue);
        }

        StartCoroutine("PickSpawner");


        Debug.Log(randomSpawnValue);
    }


    void ObstacleSpawn(int spawn)
    {
        int randomObstacle = Random.Range(1, 4);
        GameObject obstacles = Instantiate(Obstacles[randomObstacle-1], Spawner[spawn-1].transform);
        var obj = obstacles.GetComponent<Obstacle>();
        obj.speed = speed;
        if(randomSpawnValue >=4)
        {
            obj.isGoingRight = true;
            Debug.Log("obj.isGoingRight");
        }
        else
        {
            obj.isGoingRight=false;
            Debug.Log("obj.isGoingLeft");
        }
    }
    void PointSpawn(int spawn)
    {
        GameObject coin = Instantiate(point,Spawner[randomSpawnValue-1].transform);
        var coinPoint = coin.GetComponent<Point>();
        coinPoint.speed = speed;
        if(randomSpawnValue >=4)
        {
            coinPoint.isGoingRight = true;
            Debug.Log("CoinPoint.isGoingRight");
        }
        else
        {
            coinPoint.isGoingRight=false;
            Debug.Log("CoinPoint.isGoingLeft");
        }
    }
    
    





}
