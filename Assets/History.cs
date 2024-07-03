using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class History : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject recordPrefab;
    private List<Record> records = new List<Record>();


    public TextMeshProUGUI noRecord;

    private void UpdateRecords()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
        foreach (Record record in records)
        {
            GameObject recordEntry = Instantiate(recordPrefab, container);
            RecordEntryUI entryUI = recordEntry.GetComponent<RecordEntryUI>();
            if(entryUI != null)
            {
                entryUI.Setup(record.FirstUserName, record.SecondUserName, record.ScoreFirst, record.ScoreSecond);
            }
        }
    }

    static List<Record> ReadFromRecordsFile(string pathName)
    {
        List<Record> records = new List<Record>();
        if (File.Exists(pathName))
        
        {
            using (StreamReader sr = new StreamReader(pathName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    records.Add(Record.FromString(line));
                }
            }
        }
        return records;
    }


    public void CheckForRecords(){
        if (records.Count <= 0){
            noRecord.gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CheckForRecords();
        ReadFromRecordsFile(@"D:\Results.txt");
        UpdateRecords();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
