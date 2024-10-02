using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

/* namespace Obstaclesmove
{ */

public class Obstacle : MonoBehaviour
{
    public bool isGoingRight;
    float timer = 10;
    public float speed;
    void Start()
    {
        // isGoingRight = true;
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

    /* public static void GoMove(bool isGoingRight)
    {
        var move = new Obstacle();
        if(isGoingRight) move.GoRight();
        else{move.GoLeft();}
    }

    public void GoRight()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime);
        Vector2.MoveTowards(gameObject.transform.position, Vector2.left * Time.deltaTime, 1);
    }

    public void GoLeft()
    {
        gameObject.transform.Translate(Vector2.left * Time.deltaTime);
    } */

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("Collided");
            var player = col.GetComponent<Ikillable>();
            if(player == null) return;
            player.Kill();
            
        }
    }
   
}
//}
