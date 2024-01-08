using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb; // Referencia al componente Rigidbody
    public float jumpForce = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
         int capaEnemigos = LayerMask.NameToLayer("Enemies");
        int capaPollo = LayerMask.NameToLayer("Pollo");
        int vidasAct = PlayerPrefs.GetInt("levelLife");
        if(vidasAct == 0){
            Physics2D.IgnoreLayerCollision(capaPollo, capaEnemigos, false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisi�n es con un objeto que tenga la etiqueta "Suelo" (etiqueta asignada al objeto del suelo)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reinicia la partida cargando la escena actual
            GameManager.instance.GameOver();
        }
        else
        {
            int capaEnemigos = LayerMask.NameToLayer("Enemies");
            int capaPollo = LayerMask.NameToLayer("Pollo");
            Physics2D.IgnoreLayerCollision(capaPollo, capaEnemigos,true);
            int vidasAct = PlayerPrefs.GetInt("levelLife")-1;
            PlayerPrefs.SetInt("levelLife", vidasAct);

        }
    }

}
