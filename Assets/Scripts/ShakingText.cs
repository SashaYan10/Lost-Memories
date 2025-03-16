using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakingText : MonoBehaviour
{
    public float shakeAmount = 0.05f;
    public float shakeSpeed = 10f;
    private Vector3 originalPosition;
    private Text textMesh;

    void Start()
    {
        originalPosition = transform.localPosition;
        textMesh = GetComponent<Text>();
    }

    
    void Update()
    {
        float shakeX = Random.Range(-shakeAmount, shakeAmount);
        float shakeY = Random.Range(-shakeAmount, shakeAmount);

        transform.localPosition = new Vector3(originalPosition.x + shakeX, originalPosition.y + shakeY, originalPosition.z);
    }
}
