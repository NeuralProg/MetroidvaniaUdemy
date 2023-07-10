using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActivator : MonoBehaviour
{
    [SerializeField] private string mapToActivate;

    void Start()
    {
        MapController.instance.ActivateMap(mapToActivate);
    }
}
