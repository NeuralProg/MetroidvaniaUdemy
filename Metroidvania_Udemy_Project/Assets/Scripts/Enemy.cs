using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int totalHealth = 4;
    [SerializeField] private int collisionDamageAmount = 1;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private UnityEngine.Transform enemyCenter;
    [SerializeField] private float knockbackVelocity = 10f;
    private float knockbackDuration = 0.2f;
    [HideInInspector] public bool isKnockbacked = false;

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
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }


    // Check player
    private void OnCollisionStay2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
            DealDamage();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
            DealDamage();

    }

    private void DealDamage()
    {
        PlayerController.instance.DamagePlayer(collisionDamageAmount);
        PlayerController.instance.Knockback(enemyCenter);
    }


    public void Knockback(UnityEngine.Transform t)
    {
        var dir = enemyCenter.position - t.position;

        GetComponent<Rigidbody2D>().velocity = dir.normalized * knockbackVelocity;
        StartCoroutine(StopKnockback());
    }
    private IEnumerator StopKnockback()
    {
        isKnockbacked = true;
        yield return new WaitForSeconds(knockbackDuration);
        isKnockbacked = false;
    }
}
