using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePhases : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Sprite[] phases;
    [HideInInspector] public int currentPhase = 0;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPhase >= phases.Length)
        {
            Destroy(gameObject);
        }
        else
        {
            sr.sprite = phases[currentPhase];
        }
    }
}
