using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddCoin(1);
            gameObject.SetActive(false);
            // Ignora la colisión entre el jugador y la moneda
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>(), true);
        }
    }
}