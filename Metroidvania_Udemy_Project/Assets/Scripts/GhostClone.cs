using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class GhostClone : Boss
{
    [SerializeField] Boss mainBoss;

    protected override void Update()
    {
        health = mainBoss.health - 2;

        base.Update();
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

    private void OnEnable()
    {
        detected = true;
    }
}
