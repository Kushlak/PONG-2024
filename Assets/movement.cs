using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private bool AI;
    [SerializeField] private GameObject ballObject;
    private ball ball;

    private UnityEngine.Vector2 aiPlayerMove;
    public Rigidbody2D rigidbody2D;
    public KeyCode UpKey;
    public KeyCode DownKey;
    public float speed = 2;
    public float defaultSpeed;

    void Awake()
    {
        defaultSpeed = speed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        print("Hello from start");
    }
    // Start is called before the first frame update
    void Start()
    {
         rigidbody2D = GetComponent<Rigidbody2D>();
 //       print("Hello from start");

        if (ballObject == null)
        {
            ballObject = GameObject.Find("Ball");
        }

        // Отримуємо посилання на скрипт м'яча
        if (ballObject != null)
        {
            ball = ballObject.GetComponent<ball>();
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void AIcontrol()
    {
        if(ball != null)
        {
            if(ball.transform.position.y > transform.position.y + 0.5f)
            {
                aiPlayerMove = new UnityEngine.Vector2(0, 1);
            }
            else if(ball.transform.position.y < transform.position.y + 0.5f)
            {
                aiPlayerMove = new Vector2(0, -1);
            }
            else
            {
                aiPlayerMove = new Vector2(0, 0);
            }
            rigidbody2D.velocity = aiPlayerMove * speed;
        }
    }


    void Update()
    {
        if (AI) //Ai player control
        {
            AIcontrol();
        }
        else // player/players control
        {
        if (Input.GetKey(UpKey) && transform.position.y < 4)
        {
            rigidbody2D.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(DownKey) && transform.position.y > -4 )
        {
            rigidbody2D.velocity = Vector2.down * speed;

        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        }
    }
}


    