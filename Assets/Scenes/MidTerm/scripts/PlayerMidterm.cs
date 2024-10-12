using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace PlayerMidterm
{
public class PlayerMidterm : MonoBehaviour
{
    [Tooltip("Lower is faster")]
    public float interval = 1f;
    public Midtermpooling pool;
    public float velocity;
    [SerializeField] Transform gunEndPoint;
   private static Renderer midtermPlayerColor;
    public static bool alive;
    public Transform enemy;
    
    void Awake()
    {
        midtermPlayerColor = GetComponent<Renderer>();
    }
    void Start()
    {
        alive = true;
        StartCoroutine(ShootInterval());

    }

    void Shoot()
    {
        GameObject bullet = pool.GetPooledObject();
        
        var rb = bullet.GetComponent<Rigidbody>();

        if(bullet != null)
        {
            bullet.transform.position = gunEndPoint.position;
            bullet.SetActive(true);

            rb.AddForce(gunEndPoint.forward * velocity, ForceMode.Force);
            
        }
    }

    IEnumerator ShootInterval()
    {
        yield return new WaitForSeconds(interval);
        if(alive)
        
        Shoot();
        yield return StartCoroutine(ShootInterval());
    }

    
    void Update()
    {
        midtermPlayerColor.material.color = MidtermGameManager.Instance.currentColor;
        // gameObject.transform.LookAt(enemy);
    }
    void FixedUpdate()
    {
        
    }
    void OnMouseDown()
    {
        if(alive)
        MidtermGameManager.Instance.colorCycle++;
        
    }

    public static Color PlayerColor()
    {
        
        return midtermPlayerColor.material.color;
    }

    

}
}
