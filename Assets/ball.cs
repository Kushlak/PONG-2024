using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{

    private int score;
    private int maxScore;
  //  public score scoreManager;

    public Rigidbody2D rigidbody2D;
    public Vector2 lastVelocity;
    public Score Score;
    public Movement LeftPlayer;
    public Movement RightPlayer;

    
    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaximumLimit");
        rigidbody2D = GetComponent<Rigidbody2D>();
        SendBallInRandomDirection();
    }



    public void SendBallInRandomDirection()
    {
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.isKinematic = true;
        transform.position = Vector3.zero;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5f;
        lastVelocity = rigidbody2D.velocity;
       
        LeftPlayer.speed = LeftPlayer.defaultSpeed;
        RightPlayer.speed = RightPlayer.defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SendBallInRandomDirection();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        lastVelocity = rigidbody2D.velocity * 1.1f;
        LeftPlayer.speed *= 1.1f;
        RightPlayer.speed *= 1.1f;
       

    }

    //private void OnCollisionEnter2D(Collision2D collision2D)
    //{
    //    Rigidbody2D.velocity = Vector2.Reflect(lastVelocity);
  //  }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x > 0)
        {
            Debug.Log("Left Player Scored");
            Score.LeftPlayerGoal();
 //           scoreManager.LeftPlayerGoal();
        }
        if(transform.position.x < 0)
        {
            Debug.Log("Right Player Scored");
            Score.RightPlayerGoal();
 //           scoreManager.RightPlayerGoal();
        }
        
        score++;
        if(score >= maxScore)
        {
            PlayerPrefs.SetInt("FirstUserScore", Score.playerLeftScore);
            PlayerPrefs.SetInt("SecondUserScore", Score.playerRightScore);
            PlayerPrefs.Save();
            SceneManager.LoadScene("SummaryArterFinish");
        }

        SendBallInRandomDirection();

    }

}
