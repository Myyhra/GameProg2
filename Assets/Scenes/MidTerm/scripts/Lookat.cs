using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lookat : MonoBehaviour
{
    [SerializeField] GameObject player;
   public List<GameObject> enemy = new List<GameObject>();



   void OnTriggerEnter(Collider detect)
    {
        if(detect.CompareTag("Enemy"))
        {
            Transform enemyLocation = detect.transform;
            enemy.Add(detect.gameObject);
            player.transform.LookAt(enemyLocation);
        }
    }

    public void removeList()
    {
        enemy.RemoveAt(0);
    }
}
//List became useless because no time left t-t