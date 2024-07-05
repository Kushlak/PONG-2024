using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeChoiceLeading : MonoBehaviour
{
    [SerializeField] private Button startPvPButton;
    [SerializeField] private Button startAIButton;
    // Start is called before the first frame update
    void StartPvP()
    {
        SceneManager.LoadScene("StartGameScene");
    }
    void StartWithAI()
    {
        SceneManager.LoadScene("AIStartGameScene");
    }
    private void Start()
    {
        startPvPButton.onClick.AddListener(StartPvP);
        startAIButton.onClick.AddListener(StartWithAI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
