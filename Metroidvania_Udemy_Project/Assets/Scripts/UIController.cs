using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public static UIController instance;
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

    void Update()
    {
        // UI Hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < player.maxHealth)
                hearts[i].enabled = true; // Enable on screen only hearts under our max amount of hearts
            else
                hearts[i].enabled = false;
        }
    }
}
