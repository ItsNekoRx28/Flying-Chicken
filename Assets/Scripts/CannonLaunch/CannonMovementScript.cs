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
    private bool chickenLaunched = false;


    void Update()
    {
        if(!chickenLaunched){
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

            if (Input.GetKeyDown(KeyCode.Space) && !chickenLaunched)
            {
                Rigidbody2D rb = Pollo.GetComponent<Rigidbody2D>();
                int improve = PlayerPrefs.GetInt("cannon");
                print(improve);
                float bulletSpeedAux = improve*100 + bulletSpeed;
                rb.velocity = transform.up * bulletSpeedAux;
                chickenLaunched = true;
            }
        }
    }
}
