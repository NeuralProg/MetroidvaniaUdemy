using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayMainMenuMusic();
    }

    public void NewGame()
    {
        LoadingScene.instance.SceneLoad(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
