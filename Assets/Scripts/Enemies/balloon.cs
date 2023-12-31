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
        if (collision.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("levelLife") == 0)
        {
            Debug.Log("Pipo 1");
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
