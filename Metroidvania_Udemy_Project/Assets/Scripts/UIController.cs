using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Hearts")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Heals")]
    public TMP_Text healsAmount;

    [Header("Coins")]
    public TMP_Text coinsAmount;

    [Header("Scenes transition")]
    public Image fadeScreen;
    [HideInInspector] public float fadeSpeed = 1f;
    private bool fadingToBlack, fadingFromBlack;

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

        // UI heals
        healsAmount.SetText("x" + player.currentHeals);
        if(player.currentHeals <= 0)
        {
            healsAmount.color = new Color32(200, 200, 200, 255);
        }
        else if(player.currentHeals >= player.maxHeals)
        {
            healsAmount.color = new Color32(0, 226, 8, 255);
        }
        else
        {
            healsAmount.color = Color.white;
        }

        // UI coins
        coinsAmount.SetText("x" + player.coins);

        // Scene transition
        if (fadingToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1f)
            {
                fadingToBlack = false;
            }
        }
        else if(fadingFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                fadingFromBlack = false;
            }
        }
    }

    public void SceneTransitionFadeIn()
    {
        fadingToBlack = true;
        fadingFromBlack = false;
    }
    public void SceneTransitionFadeOut()
    {
        fadingToBlack = false;
        fadingFromBlack = true;
    }

    public void Cinematic(float duration)
    {
        StartCoroutine(CinematicMode(duration));
    }

    private IEnumerator CinematicMode(float duration)
    {
        GetComponent<Animator>().SetBool("Cinematic", true);
        player.canMove = false;
        player.rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(duration);
        GetComponent<Animator>().SetBool("Cinematic", false);
        yield return new WaitForSeconds(0.25f / 1);
        player.canMove = true;
    }
}
