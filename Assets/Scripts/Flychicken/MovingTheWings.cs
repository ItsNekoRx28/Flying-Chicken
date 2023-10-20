using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingTheWings : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento hacia adelante
    public float jumpForce = 10f; // Fuerza de salto
    private Rigidbody rb; // Referencia al componente Rigidbody
    private bool isLaunched = false; // Bandera para verificar si el personaje está en el suelo
    private Vector3 _position;
    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        

        // Lanzar el proyectil cuando se presiona la tecla de espacio por primera vez
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isLaunched = true;
        }

        if (isLaunched) {
            // Mover el personaje hacia adelante
            //rb.AddForce(transform.forward * speed);
            Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
            rb.MovePosition(rb.position + forwardMovement);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isLaunched){

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
             
        }
    }

}
