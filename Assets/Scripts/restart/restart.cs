using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class restart : MonoBehaviour
{
    public Text messageText; 
    public string messageToShow = "Has Ganado";

    // Start is called before the first frame update
    void Start()
    {
        print("aa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("floor"))
        {
            // Reinicia la partida cargando la escena actual.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
           messageText.text = messageToShow;
          
        }
    }

}
