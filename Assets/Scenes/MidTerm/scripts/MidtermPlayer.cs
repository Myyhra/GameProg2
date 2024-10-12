using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Pool;

public class MidtermPlayer : MonoBehaviour
{/* 
    [Tooltip("Prefab To Shoot!")]
    [SerializeField] Projectile projectilePrefab;

    [Tooltip("Projectile Force")]
    [SerializeField] float projectileVelocity = 700f;

    [Tooltip("Gun Endpoint")]
    [SerializeField] Transform gunEndpoint;

    [Tooltip("Firing Rate / smaller = faster")]
    [SerializeField] float cooldownWindow = 0.1f;

    private IObjectPool<Projectile> objectPool;
    private ObjectPool<Projectile> projecPool;
 */
    [SerializeField] bool collectionCheck = true; //throw an exception if we try to return an existing item already in the pool

    [Tooltip("Bullet Capacity")]
    [SerializeField] int defaultCapacity = 20;
    [SerializeField] int maxSize = 100;

    private float nextTimeToShoot;

    void Awake()
    {
        
    }

    

    void Start()
    {
        
    }

    void FixedUpdate()
    {
       
    }
    /* void Update()
    {
        
    } */
}
