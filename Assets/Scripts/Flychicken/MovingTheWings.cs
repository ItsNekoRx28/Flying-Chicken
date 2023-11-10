using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingTheWings : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento hacia adelante
    public float jumpForce = 10f; // Fuerza de salto
    public Rigidbody2D rb; // Referencia al componente Rigidbody
    private bool isLaunched = false; // Bandera para verificar si el personaje est� en el suelo
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.Jump();
            }
        }  
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Anade la vertical
        rb.velocity = new Vector2(rb.velocity.x, transform.up.y * speed); //Mantiene la horizontal y cambia la vertical
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisión es con un objeto que tenga la etiqueta "Suelo" (etiqueta asignada al objeto del suelo)
        if (collision.gameObject.CompareTag("floor"))
        {
            // Reinicia la partida cargando la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public bool getIsLaunched(){
        return isLaunched;
    }
    
}
