using BehaviorDesigner.Runtime.Tasks.Unity.UnityVector2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] GameObject[] gates;
    [SerializeField] UnityEngine.Transform camPoint;
    [SerializeField] GameObject boss;
    private CameraController levelCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player" && !boss.GetComponent<Boss>().detected)
        {
            boss.GetComponent<Boss>().detected = true;

            foreach (GameObject gate in gates)
            {
                gate.SetActive(true);

                levelCam = FindObjectOfType<CameraController>();
                levelCam.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (boss != null)
        {
            if (boss.GetComponent<Boss>().detected)
                levelCam.transform.position = Vector3.MoveTowards(levelCam.transform.position, camPoint.position, 30f * Time.deltaTime);
        }
        else
        {
            StartCoroutine(DestroyDelay());
        }
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
