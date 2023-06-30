using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealsPickup : MonoBehaviour
{
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private bool increaseMaxHealsAmount = false;
    [SerializeField] private int increaseAmount = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = PlayerController.instance;

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            if (increaseMaxHealsAmount)
            {
                player.maxHeals += increaseAmount;
                player.currentHeals = player.maxHeals;

                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if (player.currentHeals < player.maxHeals)
            {
                player.currentHeals += increaseAmount;

                if (pickupEffect != null)
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
