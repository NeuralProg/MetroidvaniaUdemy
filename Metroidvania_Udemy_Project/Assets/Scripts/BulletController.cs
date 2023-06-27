using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Weapon
{
    [HideInInspector] public float bulletSpeed = 12;
    [HideInInspector] public Vector2 moveDir;
    [HideInInspector] public bool shotByPlayer = false;

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
        if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy" && shotByPlayer)
        {
            other.GetComponent<Enemy>().DamageEnemy(damageAmount);
        }
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player" && !shotByPlayer)
        {
            PlayerController.instance.DamagePlayer(damageAmount);
        }
        if (LayerMask.LayerToName(other.gameObject.layer) == "Destructible" && other.GetComponent<DestructiblePhases>().canBeDestroyedByShoot == true)
        {
            other.GetComponent<DestructiblePhases>().currentPhase += 1;
        }

        if ((LayerMask.LayerToName(other.gameObject.layer) != "Enemy" && !shotByPlayer) || (LayerMask.LayerToName(other.gameObject.layer) != "Player" && shotByPlayer) || LayerMask.LayerToName(other.gameObject.layer) == "Destructible")
        {
            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
