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
    [SerializeField] private TMP_Text abilityNameRef;
    [SerializeField] private TMP_Text abilityInfoRef;
    [SerializeField] private GameObject abilityImageRef;
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
            //ShowAbilityMessage();
            StartCoroutine(StopPlayer());
        }
    }

    private void ShowAbilityMessage()
    {
        UIController.instance.GetComponent<Animator>().SetTrigger("AbilityTaken");
        abilityNameRef.text = abilityName;
        abilityInfoRef.text = abilityInfo;
        abilityImageRef.GetComponent<Image>().sprite = abilityImage;
        abilityImageRef.GetComponent<Image>().preserveAspect = true;
    }

    private IEnumerator StopPlayer()
    {
        PlayerController.instance.canMove = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        gameObject.GetComponent<CircleCollider2D>().radius = 0f;
        yield return new WaitForSeconds(12f);
        PlayerController.instance.canMove = true;
        Destroy(gameObject);
    }
}
