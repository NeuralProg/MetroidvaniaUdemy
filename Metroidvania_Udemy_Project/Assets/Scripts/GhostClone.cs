using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class GhostClone : Boss
{
    [SerializeField] Boss mainBoss;

    private void Update()
    {
        health = mainBoss.health - 2;
    }

    public override void DamageEnemy(int damage)
    {
        if (canTakeDamage)
        {
            mainBoss.DamageEnemy(damage);

            BlinkEffect();
        }
    }
    public void BlinkEffect()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(StopBlinkEffect());
    }
    private IEnumerator StopBlinkEffect()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    protected override void KillEnemy()
    {
        StartCoroutine(KillBoss());
    }
    private IEnumerator KillBoss()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        yield return new WaitForSeconds(0.35f / 0.6f);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        detected = true;
    }
}
