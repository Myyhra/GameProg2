using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMidterm;

public class MidtermEnemy : MonoBehaviour
{
    public Transform playerTransform;
    [Range(0, 1)]
    public float speed = 1.0f;

    public bool destroyEnemy = false;
    public int colorInt;
    [SerializeField] Renderer enemyColor;
    void Awake()
    {
        enemyColor = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        playerTransform = GameObject.Find("Player").transform;
        colorInt = MidtermGameManager.Instance.enemyColorInt;
        color(colorInt);
    }

    void OnDisable()
    {
            gameObject.transform.localPosition = Vector3.zero;

    }
    
    void Start()
    {
        
    }

    void color(int colorInt)
    {
        if(colorInt == 1)
        {
            enemyColor.material.color = MidtermGameManager.Instance.colorRed;
        }
        if(colorInt == 2)
        {
            enemyColor.material.color = MidtermGameManager.Instance.ColorGreen;

        }
        if(colorInt == 3)
        {
            enemyColor.material.color = MidtermGameManager.Instance.ColorBlue;

        }
    }

    void FixedUpdate()
    {
        Vector3 Go = Vector3.Lerp(this.transform.position, playerTransform.position,speed* Time.fixedDeltaTime);

        gameObject.transform.position = Go;
    }

    void OnTriggerEnter(Collider col)
    {
        
        if(col.CompareTag("Player"))
        {
            MidtermGameManager.Instance.gameOver.SetActive(true);
            PlayerMidterm.PlayerMidterm.alive = false;
        }
    }

    
    void Update()
    {
    }
}
