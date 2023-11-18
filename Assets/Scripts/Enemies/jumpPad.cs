using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    public float speed = 20f; // Velocidad de movimiento hacia adelante
    public float jumpForce = 20f; // Fuerza de salto
    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb = collision.transform.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Anade la vertical
            rb.velocity = new Vector2(rb.velocity.x, transform.up.y * speed); //Mantiene la horizontal y cambia la vertical
        }
        else
        {
            Debug.Log("He collisionado con otra cosa...");
        }
    }

}
