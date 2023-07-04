using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 4;
    [SerializeField] protected int collisionDamageAmount = 1;
    [SerializeField] protected GameObject deathEffect;
    [SerializeField] protected UnityEngine.Transform enemyCenter;
    public float knockbackVelocity = 10f;
    [SerializeField] protected GameObject coin;
    protected float knockbackDuration = 0.2f;
    [HideInInspector] public bool isKnockbacked = false;

    public virtual void DamageEnemy(int damage)
    {
        health -= damage;

        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;

        if (health <= 0)
        {
            if(deathEffect != null)
                Instantiate(deathEffect, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(0, 5); i++)
            {
                if (coin != null)
                {
                    Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-24, 24) * 0.05f, transform.position.y + Random.Range(-24, 24) * 0.05f, transform.position.z);
                    Instantiate(coin, spawnPos, transform.rotation);
                }
            }
            KillEnemy();
        }
        StartCoroutine(HitBlinkDelay());
    }

    protected virtual void KillEnemy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    protected IEnumerator HitBlinkDelay()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }


    // Check player
    protected void OnCollisionStay2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
            DealDamage();
    }
    protected void OnTriggerStay2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
            DealDamage();

    }

    protected void DealDamage()
    {
        PlayerController.instance.DamagePlayer(collisionDamageAmount);
        PlayerController.instance.Knockback(enemyCenter);
    }


    public virtual void Knockback(UnityEngine.Transform t)
    {
        if (knockbackVelocity > 0)
        {
            var dir = enemyCenter.position - t.position;

            GetComponent<Rigidbody2D>().velocity = dir.normalized * knockbackVelocity;
            StartCoroutine(StopKnockback());
        }
    }
    protected IEnumerator StopKnockback()
    {
        isKnockbacked = true;
        yield return new WaitForSeconds(knockbackDuration);
        isKnockbacked = false;
    }
}
