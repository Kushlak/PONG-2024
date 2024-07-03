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
    [SerializeField] private InputField fisrtUsernameInput;
    [SerializeField] private InputField secondUsernameInput;
    [SerializeField] private TMP_Dropdown selectLimit;
    [SerializeField] public TextMeshProUGUI errorMessage;

    // Start is called before the first frame update
    void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }


    // Update is called once per frame
    private void Start()
    {
        leaveGameButton.onClick.AddListener(BackToMenu);
        startGameButton.onClick.AddListener(StartGame);

    }


    void StartGame()
    {
        string firstUsername = fisrtUsernameInput.text;
        string secondUsername = secondUsernameInput.text;

        if(string.IsNullOrWhiteSpace(firstUsername) || string.IsNullOrWhiteSpace(secondUsername)){
            errorMessage.gameObject.SetActive(true);
            return;
        }
         errorMessage.gameObject.SetActive(false);
        
        PlayerPrefs.SetInt("MaximumLimit", int.Parse(selectLimit.options[selectLimit.value].text));
        PlayerPrefs.SetString("FirstUsename", firstUsername);
        PlayerPrefs.SetString("SecondUsename", secondUsername);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

}
