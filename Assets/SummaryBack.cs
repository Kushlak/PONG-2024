using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SummaryBack : MonoBehaviour
{
    [SerializeField] private Button backToMainMenuButton;

    void BackToMainMenu()
    {
        SceneManager.LoadScene("main menu");
    }

    static void AppendRecordToFile(string pathName, Record record)
    {
        if (record != null && !string.IsNullOrEmpty(record.FirstUserName) && !string.IsNullOrEmpty(record.SecondUserName))
        {
            using (StreamWriter sw = new StreamWriter(pathName, true))
            {
                sw.WriteLine(record.ToString());
            }
        }
    }

  
    void Start()
    {
        backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        string firstUsername = PlayerPrefs.GetString("FirstUsername");
        Debug.Log("FirstUsername");
        string secondUsername = PlayerPrefs.GetString("SecondUsername");
        Debug.Log("SecondUsername");
        int firstUserScore = PlayerPrefs.GetInt("FirstUserScore");
        Debug.Log("FirstUserScore");
        int secondUserScore = PlayerPrefs.GetInt("SecondUserScore");
        Debug.Log("SecondUserScore");

        // Можна перевірити чи пусті змінні 
        if (!string.IsNullOrEmpty(firstUsername) && !string.IsNullOrEmpty(secondUsername))
        {
            Record newRecord = new Record(firstUsername, secondUsername, firstUserScore, secondUserScore);
            string pathName = @"D:\Results.txt";
            AppendRecordToFile(pathName, newRecord);
        }

        PlayerPrefs.DeleteAll();
    }


    void Update()
    {
    }
}

