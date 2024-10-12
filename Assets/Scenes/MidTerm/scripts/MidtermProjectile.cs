using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using PlayerMidterm;

[RequireComponent(typeof(Rigidbody))]
public class MidtermProjectile : MonoBehaviour
{
    public int Color;
    [SerializeField] Rigidbody rb;
    Renderer color;
    public Lookat _lookAt;

    public bool destroyBullet = false;
    public int colorInt;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        color = GetComponent<Renderer>();
        _lookAt = FindAnyObjectByType<Lookat>();
        
    }

    void OnEnable()
    {
        StartCoroutine("Despawn");
    }
    void Update()
    {
        color.material.color = PlayerMidterm.PlayerMidterm.PlayerColor();
        colorInt = MidtermGameManager.Instance.colorCycle;
        
    }
    
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        if(_lookAt.enemy.Count > 2)
        {
            _lookAt.removeList();
        }
    }
    void OnDisable()
    {
        rb.velocity = Vector3.zero;

    }
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            int enemyInt = collision.GetComponent<MidtermEnemy>().colorInt;

            if(colorInt == enemyInt)
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                // _lookAt.removeList();

            }

        }
    }


    
}
