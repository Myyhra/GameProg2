using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midtermpooling : MonoBehaviour
{
    [SerializeField] Transform gunEndpoint;

    List<GameObject> bullets = new List<GameObject>();

    [SerializeField] int capacity;

    [SerializeField] GameObject bulletPrefab;
   void Awake()
    {
        for(int i = 0; i < capacity; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }
}
