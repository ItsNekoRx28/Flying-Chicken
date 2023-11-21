using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Debug.Log("Intento borrar cosa");
        if (collision.gameObject.CompareTag("Enemies") || collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Borrado cosa");
            // Reinicia la partida cargando la escena actual
            Destroy(obj: collision.gameObject);
        }
    }
}
