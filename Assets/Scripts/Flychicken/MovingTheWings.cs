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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.Jump();
            }
            // Calcula el ángulo de la velocidad en radianes
            float angulo = Mathf.Atan2(rb.velocity.y, rb.velocity.x);

            // Convierte el ángulo a grados
            angulo = angulo * Mathf.Rad2Deg;

            // Rota el objeto para que apunte en la dirección de la velocidad
            rb.MoveRotation(angulo);
        } 
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Anade la vertical
        rb.velocity = new Vector2(rb.velocity.x, transform.up.y * speed); //Mantiene la horizontal y cambia la vertical

    }

    public bool getIsLaunched(){
        return isLaunched;
    }
    
}
