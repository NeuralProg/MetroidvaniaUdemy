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

        Destroy(MapController.instance.gameObject);
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

        LoadingScene.instance.respawnPos = new Vector3(14.6f, 1f, 0);
        LoadingScene.instance.respawnDir = -1f;
        LoadingScene.instance.SceneLoad(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
