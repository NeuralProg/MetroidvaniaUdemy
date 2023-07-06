using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            PlayerController.instance.coins += 1;

            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, transform.rotation) ;

            AudioManager.instance.PlayAdjustedSFX(5);

            Destroy(gameObject);
        }
    }
}
