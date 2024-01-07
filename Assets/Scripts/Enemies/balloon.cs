using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloon : MonoBehaviour
{
    // Referencia al primer collider
    private Collider2D primerCollider;

    // Referencia al segundo collider
    private Collider2D segundoCollider;
    void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisión es con un objeto que tenga la etiqueta "Suelo" (etiqueta asignada al objeto del suelo)
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Pipo 1");
            // Reinicia la partida cargando la escena actual
            GameManager.instance.GameOver();
        }
        else
        {
            Debug.Log("He collisionado con otra cosa...");
        }
    }


}
