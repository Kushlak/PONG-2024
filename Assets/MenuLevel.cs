
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevel : MonoBehaviour
{
     [SerializeField] private Button startGameButton;
     void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    private void Start()
    {
        
        startGameButton.onClick.AddListener(StartGame);

    }


    public void QuitGame(){
        Application.Quit();
    }
}
