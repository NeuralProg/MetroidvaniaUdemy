using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Boss : Enemy
{
    [SerializeField] private bool hideWhenNotDetected = true;
    [HideInInspector] public bool detected = false;
    [HideInInspector] public bool canTakeDamage = false;
    private bool hasSpawned = false;

    private void Update()
    {
        if (!detected && hideWhenNotDetected && !hasSpawned)
        {
            GetComponent<Animator>().SetBool("Invisible", true);
        }
    }

    public void Spawn(float duration)
    {
        StartCoroutine(SpawnCinematic(duration));
    }
    private IEnumerator SpawnCinematic(float duration)
    {
        hasSpawned = true;
        GetComponent<Animator>().SetTrigger("Spawn");
        GetComponent<Animator>().SetBool("Invisible", false);
        yield return new WaitForSeconds(duration + 2);
        detected = true;
    }

    protected override void KillEnemy()
    {
        Destroy(gameObject);
    }

    public override void DamageEnemy(int damage)
    {
        if(canTakeDamage)
            base.DamageEnemy(damage);
    }
}
