using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class GhostClone : Boss
{
    [SerializeField] Boss mainBoss;

    private void Update()
    {
        health = mainBoss.health - 1;
    }

    public override void DamageEnemy(int damage)
    {
        if(canTakeDamage)
            mainBoss.DamageEnemy(damage);
    }

    private void OnEnable()
    {
        detected = true;
    }
}
