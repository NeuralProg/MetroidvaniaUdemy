using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController instance;

    [SerializeField] GameObject[] maps;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActivateMap(string mapToActivate)
    {
        foreach (GameObject map in maps)
        {
            if (map.name == mapToActivate)
                map.SetActive(true);
            else
                map.SetActive(false);
        }
    }
}
