using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform pollo;
    public Vector3 offset;
    public float upperLimit;

    private float halfInitialCameraWidth;
    private float halfInitialCameraHeight;

    void Start()
    {
        halfInitialCameraWidth = transform.position.x + offset.x;
        halfInitialCameraHeight = transform.position.y;
    }

    void Update()
    {
        if (pollo.position.x >= halfInitialCameraWidth)
        {
            float x = Mathf.Clamp(pollo.position.x - offset.x, halfInitialCameraWidth, float.MaxValue);
            float y = Mathf.Clamp(pollo.position.y - offset.y, halfInitialCameraHeight, upperLimit);
            transform.position = new Vector3(x, y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
