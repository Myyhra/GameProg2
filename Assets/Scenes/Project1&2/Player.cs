using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ikillable
{
    void Kill();
}
public class Player : MonoBehaviour,Ikillable
{
    public float HP = 10;
    public float speed = 10f;
    float direction = 1f;
    public bool alive = true;
    public GameObject GameOverText;
    public GameObject Toggle;

    public GameObject Pivot;
    void Start()
    {
        
    }
    void Update()
    {
        if(alive)
        {
            Pivot.transform.Rotate(0,0, 10f * (speed * direction) * Time.deltaTime);
        }
        else
        {
            GameOverText.SetActive(true);
            Toggle.SetActive(false);
            speed = 0;
        }
        
    }

    public void Kill()
    {
        alive = false;
    }

    public void ChangeDirection(bool turn)
    {
        print(turn);
       if(turn) direction = -1f;
       if(!turn) direction = 1f;
    }

}
