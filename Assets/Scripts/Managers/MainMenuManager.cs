using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public Button btn_startGame;
    public Button btn_quitGame;

    // Start is called before the first frame update
    void Start()
    {
        btn_startGame.onClick.AddListener(GoToNextScene);
        btn_quitGame.onClick.AddListener(QuitGame);
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }
}
