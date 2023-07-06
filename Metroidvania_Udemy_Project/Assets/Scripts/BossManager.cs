using BehaviorDesigner.Runtime.Tasks.Unity.UnityVector2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] GameObject[] gates;
    [SerializeField] UnityEngine.Transform camPoint;
    [SerializeField] GameObject boss;
    [SerializeField] float cinematicTime = 5f;
    private CameraController levelCam;
    private bool entered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player" && !boss.GetComponent<Boss>().detected)
        {
            foreach (GameObject gate in gates)
            {
                gate.SetActive(true);
            }

            entered = true;

            levelCam = FindObjectOfType<CameraController>();
            levelCam.enabled = false;

            UIController.instance.Cinematic(cinematicTime);
            boss.GetComponent<Boss>().Spawn(cinematicTime);
            AudioManager.instance.PlayBossMusic();
        }
    }

    private void Update()
    {
        if (boss != null)
        {
            if (entered)
            {
                levelCam.transform.position = Vector3.MoveTowards(levelCam.transform.position, camPoint.position, 30f * Time.deltaTime);
            }
        }
        else
        {
            StartCoroutine(DestroyDelay());
        }
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlayLevelMusic();
        Destroy(gameObject);
    }
}
