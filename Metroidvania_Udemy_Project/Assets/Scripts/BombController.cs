using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float timeToExplode = 1f;
    [SerializeField] private GameObject explosion;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(rb.velocity.x, 5f);
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

            Destroy(gameObject);
        }
    }
    
}
