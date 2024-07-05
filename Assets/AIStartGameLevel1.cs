using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AIStartGameLevel : MonoBehaviour
{

    [SerializeField] private Button leaveAIGameButton;
    [SerializeField] private Button startAIGameButton;
    [SerializeField] private InputField fisrtUsernameInput;
    [SerializeField] private TMP_Dropdown selectLimit;
    [SerializeField] public TextMeshProUGUI errorMessage;

    // Start is called before the first frame update
    void BackToMenu()
    {
        SceneManager.LoadScene("main menu");
        
    }


    // Update is called once per frame
    private void Start()
    {
        leaveAIGameButton.onClick.AddListener(BackToMenu);
        startAIGameButton.onClick.AddListener(StartAIGame);

    }

    void StartAIGame()
    {
        string firstUsername = fisrtUsernameInput.text;

        if(string.IsNullOrWhiteSpace(firstUsername)){
            errorMessage.gameObject.SetActive(true);
            return;
        }
         errorMessage.gameObject.SetActive(false);
        
        PlayerPrefs.SetInt("MaximumLimit", int.Parse(selectLimit.options[selectLimit.value].text));
        PlayerPrefs.SetString("FirstUsename", firstUsername);
        PlayerPrefs.SetString("SecondUsename", "AI-player");

        SceneManager.LoadScene("AiSampleScene");
    }
}
    