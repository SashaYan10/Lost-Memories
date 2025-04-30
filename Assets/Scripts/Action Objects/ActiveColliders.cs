using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColliders : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private EdgeCollider2D edgeCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void OnEnable()
    {
        if (boxCollider != null) boxCollider.enabled = true;
        if (edgeCollider != null) edgeCollider.enabled = true;
    }
}
