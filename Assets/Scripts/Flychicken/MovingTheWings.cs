using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingTheWings : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento hacia adelante
    public float jumpForce = 10f; // Fuerza de salto
    private Rigidbody2D rb; // Referencia al componente Rigidbody
    private bool isLaunched = false; // Bandera para verificar si el personaje está en el suelo
    private Vector2 _position;
    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            //float move = Input.GetAxis("Horizontal");
            //rb.velocity = new Vector2(move * speed, rb.velocity.y);
                //rb.velocity = transform.up * speed;

            if (Input.GetKeyDown(KeyCode.Space) && isLaunched)
            {

                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                rb.velocity = transform.up * speed;

            }
        }

        
    }

}
