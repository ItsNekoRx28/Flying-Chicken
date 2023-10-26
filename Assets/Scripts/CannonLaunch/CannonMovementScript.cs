using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovementScript : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public GameObject Pollo;
    public float bulletSpeed = 20f;
    public float rotationZ;



    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationZ -= rotationSpeed * Time.deltaTime;
            rotationZ = Mathf.Clamp(rotationZ, -80, -20);
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationZ += rotationSpeed * Time.deltaTime;
            rotationZ = Mathf.Clamp(rotationZ, -80, -20);
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        }
    }
}
