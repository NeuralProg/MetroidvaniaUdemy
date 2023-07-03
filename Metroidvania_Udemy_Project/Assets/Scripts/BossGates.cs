using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGates : MonoBehaviour
{
    [SerializeField] GameObject[] gates;
    [SerializeField] GameObject boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            boss.GetComponent<Boss>().detected = true;

            foreach (GameObject gate in gates)
            {
                gate.SetActive(true);
            }
        }
    }
}
