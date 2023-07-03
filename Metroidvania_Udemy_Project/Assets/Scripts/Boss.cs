using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Boss : Enemy
{
    [HideInInspector] public bool detected = false;

    protected override void KillEnemy()
    {
        Destroy(gameObject);
    }


}
