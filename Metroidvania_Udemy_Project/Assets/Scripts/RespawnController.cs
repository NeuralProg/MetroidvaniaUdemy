using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To control scenes

public class RespawnController : MonoBehaviour
{

    public static RespawnController instance;

    [HideInInspector] public int respawnScene;
    [HideInInspector] public Vector3 respawnPoint;
    [HideInInspector] public float respawnDirection = 1;
    [HideInInspector] public float respawnDelay = 3f;
    [SerializeField] private GameObject playerDeathEffect;
    [SerializeField] private GameObject respawnEffect;

    private PlayerController player;


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
        player = PlayerController.instance;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnDelay());
    }

    private IEnumerator RespawnDelay()
    {
        player.gameObject.SetActive(false);
        if (playerDeathEffect != null)
            Instantiate(playerDeathEffect, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(respawnDelay);

        LoadingScene.instance.SceneLoad(respawnScene);
        player = PlayerController.instance;

        player.transform.position = respawnPoint;
        player.transform.localScale = new Vector3(respawnDirection, 1f, 1f);
        player.gameObject.SetActive(true);
        player.HealPlayer(PlayerController.instance.maxHealth);
        player.currentHeals = PlayerController.instance.maxHeals;
        player.invincibilityTimer = 2f;

        yield return new WaitForSeconds(Time.deltaTime);

        if (respawnEffect != null)
            Instantiate(respawnEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
    }
}
