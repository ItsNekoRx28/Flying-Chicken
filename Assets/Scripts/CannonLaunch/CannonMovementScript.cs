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
    public AudioSource cannonSoundSource;
    public AudioClip cannonSoundClip;


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
                float bulletSpeedAux = improve*7 + bulletSpeed;
                rb.velocity = transform.up * bulletSpeedAux;
                chickenLaunched = true;
                cannonSoundSource.PlayOneShot(cannonSoundClip);
            }
        }
    }
}
