using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string pinballSceneName;

    [Header("Button")]
    public Button playButton;
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(pinballSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
