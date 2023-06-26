using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : Weapon
{
    private float timeToExplode = 1f;
    private int damage = 1;
    private float blastRange = 1.5f;
    private float blastPower = 15f;
    [SerializeField] private LayerMask whatIsDestructible;
    [SerializeField] private GameObject explosion;


    public override void Start()
    {
        base.Start();
        rb.velocity = new Vector2(rb.velocity.x, 5f);
        damageAmount = damage;
    }

    void Update()
    {
        timeToExplode -= Time.deltaTime;

        if(timeToExplode <= 0)
        {
            if(explosion != null)
            {
                Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1.15f, transform.position.z), transform.rotation);
            }

            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(new Vector3(transform.position.x, transform.position.y + 1.15f, transform.position.z), blastRange, whatIsDestructible);
        
            if(objectsToDamage.Length > 0)
            {
                foreach (Collider2D col in objectsToDamage)
                {
                    if (LayerMask.LayerToName(col.gameObject.layer) == "Destructible")
                    {
                        col.GetComponent<DestructiblePhases>().currentPhase += 1;
                    }

                    if (LayerMask.LayerToName(col.gameObject.layer) == "Player")
                    {
                        Rigidbody2D rBody = col.gameObject.GetComponentInParent<Rigidbody2D>();


                        if (rBody != null)
                        {
                            rBody.velocity = new Vector2(rBody.velocity.x, blastPower);
                        }
                    }

                    if (LayerMask.LayerToName(col.gameObject.layer) == "Enemy")
                    {
                        col.gameObject.GetComponent<Enemy>().DamageEnemy(damageAmount);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
    
}
