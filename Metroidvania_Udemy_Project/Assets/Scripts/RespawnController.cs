using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To control scenes

public class RespawnController : MonoBehaviour
{

    public static RespawnController instance;

    public Transform respawnPoint;
    [HideInInspector] public float respawnDelay = 3f;

    private GameObject player;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = PlayerController.instance.gameObject;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnDelay());
    }

    private IEnumerator RespawnDelay()
    {
        player.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        player.transform.position = respawnPoint.position;
        player.transform.localScale = respawnPoint.localScale;
        player.SetActive(true);
        PlayerController.instance.HealPlayer(PlayerController.instance.maxHealth);
        PlayerController.instance.invincibilityTimer = 2f;
    }
}
