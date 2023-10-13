using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
