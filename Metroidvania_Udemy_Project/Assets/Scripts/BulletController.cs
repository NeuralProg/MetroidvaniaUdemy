using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Weapon
{
    protected float bulletSpeed = 12;
    [HideInInspector] public Vector2 moveDir;

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        rb.velocity = moveDir * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy")
            other.GetComponent<Enemy>().DamageEnemy(damageAmount);

        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
