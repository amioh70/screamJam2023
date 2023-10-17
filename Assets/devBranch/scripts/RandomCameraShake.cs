using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomCameraShake : MonoBehaviour
{
    public float bounceHeight = 0.1f;
    public float bounceSpeed = 1.0f;

    private Transform cameraTransform;
    private Vector3 originalPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        originalPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        cameraTransform.localPosition = new Vector3(originalPosition.x, newY, originalPosition.z);
    }
}

