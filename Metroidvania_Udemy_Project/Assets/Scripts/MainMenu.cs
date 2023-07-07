using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject continueButton;

    void Start()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
            continueButton.SetActive(true);

        AudioManager.instance.PlayMainMenuMusic();
    }

    public void Continue()
    {
        RespawnController.instance.respawnScene = PlayerPrefs.GetInt("SavedLevel");
        RespawnController.instance.respawnPoint = new Vector3(PlayerPrefs.GetFloat("SavedPositionX"), PlayerPrefs.GetFloat("SavedPositionY"), PlayerPrefs.GetFloat("SavedPositionZ"));
        RespawnController.instance.respawnDirection = PlayerPrefs.GetFloat("SavedDirection");

        RespawnController.instance.RespawnInstant();
    }

    public void NewGame()
    {

        PlayerPrefs.DeleteAll();

        LoadingScene.instance.SceneLoad(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
