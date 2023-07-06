using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    public BoxCollider2D boundsBox;
    private bool shouldReturnToPlayer = false;

    private float halfHeight, halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        AudioManager.instance.PlayLevelMusic();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerController>();

        if (player != null)
        {
            Vector3 camPos = new Vector3(Mathf.Clamp(player.transform.position.x, boundsBox.bounds.min.x + halfWidth, boundsBox.bounds.max.x - halfWidth), Mathf.Clamp(player.transform.position.y, boundsBox.bounds.min.y + halfHeight, boundsBox.bounds.max.y - halfHeight), transform.position.z);

            if (Vector3.Distance(transform.position, camPos) < 0.2f)
                shouldReturnToPlayer = false;

            if (shouldReturnToPlayer)
                transform.position = Vector3.MoveTowards(transform.position, camPos, 30f * Time.deltaTime);
            else
                transform.position = camPos;
        }
        else
        {
            player = FindObjectOfType<PlayerController>();
        }
    }

    private void OnEnable()
    {
        shouldReturnToPlayer = true;
    }
}
