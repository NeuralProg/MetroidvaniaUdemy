using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityUnlock : MonoBehaviour
{
    [SerializeField] private bool unlockDoubleJumpAbility, unlockDashAbility, unlockBallAbility, unlockBombAbility, unlockWallJumpAbility;
    [SerializeField] private GameObject pickupEffect;

    [Header("Message")]
    [SerializeField] private string abilityName;
    [SerializeField] private string abilityInfo;
    [SerializeField] private Sprite abilityImage;
    private PlayerAbilityTracker player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = PlayerController.instance.GetComponent<PlayerAbilityTracker>();

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            if (unlockDoubleJumpAbility)
                player.doubleJumpAbility = true;
            if (unlockDashAbility)
                player.dashAbility = true;
            if (unlockBallAbility)
                player.ballAbility = true;
            if (unlockBombAbility)
                player.bombAbility = true;
            if (unlockWallJumpAbility)
                player.wallJumpAbility = true;

            Instantiate(pickupEffect, transform.position, transform.rotation);
            ShowAbilityMessage();
            StartCoroutine(StopPlayer());
        }
    }

    private void ShowAbilityMessage()
    {
        UIController.instance.GetComponent<Animator>().SetTrigger("AbilityTaken");

        GameObject.Find("AbilityName").gameObject.GetComponent<TMP_Text>().text = abilityName;
        GameObject.Find("AbilityInfo").gameObject.GetComponent<TMP_Text>().text = abilityInfo;
        GameObject.Find("AbilityImage").gameObject.GetComponent<Image>().sprite = abilityImage;
        GameObject.Find("AbilityImage").gameObject.GetComponent<Image>().preserveAspect = true;
    }

    private IEnumerator StopPlayer()
    {
        PlayerController.instance.canMove = false;
        UIController.instance.canPause = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(9f);
        PlayerController.instance.canMove = true;
        UIController.instance.canPause = true;
        Destroy(gameObject);
    }
}
