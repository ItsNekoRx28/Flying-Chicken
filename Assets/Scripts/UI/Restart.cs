using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public GameUtils gameUtils;

    public float jumpForce = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        // Asegúrate de que el objeto tiene un componente Rigidbody2D adjunto
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("El objeto necesita tener un componente Rigidbody2D adjunto.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            if (!isFallProtectionOn())
            {
                gameUtils.GameOver();
            }
            else
            {
                // Aplicar fuerza hacia la derecha para simular el rebote
                
            }
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            gameUtils.Win();
        }
    }

    private bool isFallProtectionOn()
    {
        return PlayerPrefs.GetInt("ProteccionCaidaActivada", 0) == 1;
    }

}
