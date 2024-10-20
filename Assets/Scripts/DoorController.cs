using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    private SpriteRenderer doorRenderer;
    [SerializeField] private int keysCount;
    [SerializeField] private GameObject keys;
    void Awake()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorRenderer = GetComponent<SpriteRenderer>();

    }

    void LateUpdate()
    {
        keysCount = keys.transform.childCount;
        if (keysCount == 0)
        {
            doorCollider.enabled = false;
            doorRenderer.enabled = false;
            
        }
    }
}
