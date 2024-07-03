using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

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
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }



    void Update()
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


    