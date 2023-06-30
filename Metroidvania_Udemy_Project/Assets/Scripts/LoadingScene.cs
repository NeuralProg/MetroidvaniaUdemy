using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;

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

    public void SceneLoad(int sceneBuildIndex)
    {
        // Loading screen
        StartCoroutine(LoadSceneAsynchronously(sceneBuildIndex));
    }

    private IEnumerator LoadSceneAsynchronously(int sceneBuildIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneBuildIndex); // Load scene in the background
        while (!operation.isDone)   // Wait till scene is fully loaded
        {
            yield return null;
        }
    }
}
