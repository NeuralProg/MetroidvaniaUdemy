using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Important to be able to use TMPro !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            PlayerAbilityTracker player = collision.GetComponentInParent<PlayerAbilityTracker>();

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
            StartCoroutine(StopPlayer(collision.GetComponentInParent<PlayerController>()));
        }
    }

    private void ShowAbilityMessage()
    {
        abilityNameRef.gameObject.transform.parent.gameObject.SetActive(true);
        GetComponent<Animator>().SetTrigger("AbilityTaken");
        abilityNameRef.text = abilityName;
        abilityInfoRef.text = abilityInfo;
        abilityImageRef.GetComponent<Image>().sprite = abilityImage;
        abilityImageRef.GetComponent<Image>().preserveAspect = true;
    }

    private IEnumerator StopPlayer(PlayerController plr)
    {
        plr.canMove = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        gameObject.GetComponent<CircleCollider2D>().radius = 0f;
        yield return new WaitForSeconds(12f);
        plr.canMove = true;
        Destroy(gameObject);
    }
}
