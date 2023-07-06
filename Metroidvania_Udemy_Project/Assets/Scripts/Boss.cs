using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Boss : Enemy
{
    [SerializeField] private bool hideWhenNotDetected = true;
    [HideInInspector] public bool detected = false;
    [HideInInspector] public bool canTakeDamage = false;
    [SerializeField] private GhostClone clone;
    private bool hasSpawned = false;

    protected override void Update()
    {
        base.Update();

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

    public override void DamageEnemy(int damage)
    {
        if (canTakeDamage)
        {
            base.DamageEnemy(damage);

            AudioManager.instance.PlaySFX(1);

            if (clone != null && clone.gameObject.activeSelf)
                clone.BlinkEffect();
        }
    }

    protected override void KillEnemy()
    {
        StartCoroutine(KillBoss());
    }
    private IEnumerator KillBoss()
    {
        AudioManager.instance.PlaySFX(0);
        GetComponent<Animator>().SetTrigger("Dead");
        yield return new WaitForSeconds(0.35f / 0.6f);

        if (deathEffect != null)
            Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
