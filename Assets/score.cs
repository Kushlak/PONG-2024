using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
        public TextMeshProUGUI leftPlayer;
        public TextMeshProUGUI rightPlayer;

    public int playerLeftScore = 0;
    public int playerRightScore = 0;

    public Text playerLeftScoreText;
    public Text playerRightScoreText; 


    public void Start()
    {
        SetUsers();
    }

    public void SetUsers()
    {
        leftPlayer.text = PlayerPrefs.GetString("FirstUsename");
        rightPlayer.text = PlayerPrefs.GetString("SecondUsename");
    }

        public void LeftPlayerGoal()
        {
            playerLeftScore++;
            playerLeftScoreText.text = playerLeftScore.ToString();
        }

        public void RightPlayerGoal()
        {
            playerRightScore++;
            playerRightScoreText.text = playerRightScore.ToString();
        }


}
