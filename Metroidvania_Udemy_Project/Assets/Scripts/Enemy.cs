using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int totalHealth = 4;
    [SerializeField] private int collisionDamageAmount = 1;
    [SerializeField] private GameObject deathEffect;

    public void DamageEnemy(int damage)
    {
        totalHealth -= damage;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        if (totalHealth <= 0)
        {
            if(deathEffect != null)
                Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject.transform.parent.gameObject);
        }
        StartCoroutine(HitBlinkDelay());
    }

    private IEnumerator HitBlinkDelay()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }


    // Check player
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
            DealDamage();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
            DealDamage();

    }

    private void DealDamage()
    {
        PlayerController.instance.DamagePlayer(collisionDamageAmount);  
    }
}
