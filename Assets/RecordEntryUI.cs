using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class RecordEntryUI : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI userNamesText;
  [SerializeField] private TextMeshProUGUI scoresTexts;

  public void Setup( string firstUsername,string secondUsername, int firstUserScore, int secondUserScore)
  {
    userNamesText.text = $"{firstUsername}vs{secondUsername}";
    scoresTexts.text = $"{firstUserScore}:{secondUserScore}";
  }
}
