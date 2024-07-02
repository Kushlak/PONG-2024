using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class History : MonoBehaviour
{

    private List<Record> records = new List<Record>();


    public TextMeshProUGUI noRecord;

    public void CheckForRecords(){
        if (records.Count <= 0){
            noRecord.gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CheckForRecords();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
