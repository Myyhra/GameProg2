using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isGoingRight;
     float timer = 10;
    public float speed;
    void Start()
    {
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) Destroy(gameObject);

        if(isGoingRight)
        {
            gameObject.transform.Translate(Vector2.right * Time.deltaTime * speed,Space.World);
        }
        else
        {
            gameObject.transform.Translate(-Vector2.right * Time.deltaTime * speed,Space.World);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("Point Collided");
            GameManager.Instance.PointCollect +=1;
            Destroy(gameObject);
        }
    }
}
