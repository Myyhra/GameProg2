using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidtermRotateAround : MonoBehaviour
{

    public float speed = 10f;
    void Update()
    {
        gameObject.transform.Rotate(0,1f*speed*Time.deltaTime,0f);
    }
}
