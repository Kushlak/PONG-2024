using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameLevel : MonoBehaviour
{

    [SerializeField] private Button leaveGameButton;
    [SerializeField] private Button startGameButton;
    [SerializeField] private InputField firstUsernameInput;
    [SerializeField] private InputField secondUsernameInput;
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
        leaveGameButton.onClick.AddListener(BackToMenu);
        startGameButton.onClick.AddListener(StartGame);

    }



    void StartGame()
    {
        string firstUsername = firstUsernameInput.text;
        string secondUsername = secondUsernameInput.text;

        if(string.IsNullOrWhiteSpace(firstUsername) || string.IsNullOrWhiteSpace(secondUsername)){
            errorMessage.gameObject.SetActive(true);
            return;
        } 

         errorMessage.gameObject.SetActive(false);
        
        PlayerPrefs.SetInt("MaximumLimit", int.Parse(selectLimit.options[selectLimit.value].text));
        PlayerPrefs.SetString("FirstUsername", firstUsername);
        PlayerPrefs.SetString("SecondUsername", secondUsername);

        SceneManager.LoadScene("SampleScene");
        
    }

}
