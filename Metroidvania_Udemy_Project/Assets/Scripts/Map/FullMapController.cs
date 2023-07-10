using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMapController : MonoBehaviour
{
    [SerializeField] private MapCamera mapCam;

    private float zoomSpeed = 75f;
    private float startSize;
    private float maxZoom = 60, minZoom = 15;
    private float moveSpeed = 35f;
    //private float minX = , maxY = 15;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        startSize = cam.orthographicSize;
    }

    void Update()
    {
        transform.position += new Vector3(UserInput.instance.moveInput.x, UserInput.instance.moveInput.y, 0).normalized * moveSpeed *Time.unscaledDeltaTime;

        if (UserInput.instance.controls.Shooting.Shoot.IsPressed() && UIController.instance.mapMenu.activeSelf)
        {
            cam.orthographicSize -= zoomSpeed * Time.unscaledDeltaTime;
        }
        if (UserInput.instance.controls.SwitchingState.Switch.IsPressed() && UIController.instance.mapMenu.activeSelf)
        {
            cam.orthographicSize += zoomSpeed * Time.unscaledDeltaTime; 
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
    }

    private void OnEnable()
    {
        transform.position = mapCam.transform.position;
    }
}
