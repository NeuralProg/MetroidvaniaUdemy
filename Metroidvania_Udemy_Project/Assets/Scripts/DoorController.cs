using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To control scenes

public class DoorController : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    [SerializeField] private Vector3 newPosition;
    private float distanceToOpen = 5;

    private PlayerController player;
    private Animator anim;


    void Start()
    {
        player = PlayerController.instance;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= distanceToOpen)
        {
            anim.SetBool("DoorOpen", true);
        }
        else
        {
            anim.SetBool("DoorOpen", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            player = PlayerController.instance;

            LoadingScene.instance.respawning = false;
            LoadingScene.instance.respawnPos = newPosition;
            LoadingScene.instance.respawnDir = -transform.localScale.x;
            LoadingScene.instance.SceneLoad(sceneToLoad);
        }
    }
}
