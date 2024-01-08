using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddCoin(1);
            gameObject.SetActive(false);
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>(), true);
        }
    }
}