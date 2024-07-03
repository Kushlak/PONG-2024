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
        using (StreamWriter sw = new StreamWriter(pathName, true))
        {
            sw.WriteLine(record.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        string firstUsername = PlayerPrefs.GetString("FirstUsename");
        string secondUsername = PlayerPrefs.GetString("SecondUsename");
        int firstUserScore = PlayerPrefs.GetInt("FirstUserScore");
        int secondUserScore = PlayerPrefs.GetInt("SecondUserScore");
        Record newRecord = new Record(firstUsername, secondUsername, firstUserScore, secondUserScore);
        string pathName = @"D:\Results.txt";

        AppendRecordToFile(pathName, newRecord);
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
