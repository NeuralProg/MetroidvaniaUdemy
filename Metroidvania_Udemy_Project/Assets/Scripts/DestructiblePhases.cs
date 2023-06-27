using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePhases : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Sprite[] phases;
    public bool canBeDestroyedByShoot = false;
    [SerializeField] private GameObject effectOnDespawn;
    [HideInInspector] public int currentPhase = 0;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPhase >= phases.Length)
        {
            if(effectOnDespawn!= null)
                Instantiate(effectOnDespawn, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            sr.sprite = phases[currentPhase];
        }
    }
}
