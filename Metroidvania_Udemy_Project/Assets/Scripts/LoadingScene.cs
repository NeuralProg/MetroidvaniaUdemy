using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;
    private int sceneBuildIndex;

    [HideInInspector] public bool loaded = false;

    [HideInInspector] public bool respawning = false;
    [HideInInspector] public Vector3 respawnPos;
    [HideInInspector] public float respawnDir = 1;

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

    public void SceneLoad(int sceneBuildIdx)
    {
        // Loading screen
        loaded = false;
        sceneBuildIndex = sceneBuildIdx;
        StartCoroutine(SceneTransitionDelay());
    }

    private IEnumerator SceneTransitionDelay()
    {
        PlayerController.instance.canMove = false;
        UIController.instance.SceneTransitionFadeIn();
        yield return new WaitForSeconds(UIController.instance.fadeSpeed);
        StartCoroutine(LoadSceneAsynchronously());
    }

    private IEnumerator LoadSceneAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneBuildIndex); // Load scene in the background
        while (!operation.isDone)   // Wait till scene is fully loaded
        {
            //print(operation.progress);
            yield return null;
        }

        if(operation.isDone)
        {
            loaded = true;

            if (!respawning)
            {
                PlayerController player = PlayerController.instance;

                player.transform.position = respawnPos;
                player.transform.localScale = new Vector3(respawnDir, 1f, 1f);
                print("changes vars");
                loaded = false;
            }

            UIController.instance.SceneTransitionFadeOut();
            print("Loaded");
            PlayerController.instance.canMove = true;
            StopAllCoroutines();
        }
    }
}
