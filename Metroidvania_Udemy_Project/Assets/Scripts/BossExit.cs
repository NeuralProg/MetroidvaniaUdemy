using BehaviorDesigner.Runtime.Tasks.Unity.UnityVector2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExit : MonoBehaviour
{
    [SerializeField] GameObject boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player" && boss == null)
        {
            FindObjectOfType<CameraController>().enabled = true;
            AudioManager.instance.PlayLevelMusic();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
