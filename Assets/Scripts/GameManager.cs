using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int coinCount;
    private float distanceTravelled = 0f;
    public GameUtils gameUtils;
    public CannonMovementScript cannon;
    public Text coinText;
    public Text distanceText;
    private Boolean Launched = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        coinText.text = "Coins: " + coinCount.ToString();
    }

    void Update()
    {
        if (!Launched && Input.GetKeyDown(KeyCode.Space))
        {
            Launched = true;
            StartCoroutine(UpdateDistance());
        }
    }

    IEnumerator UpdateDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            distanceTravelled +=  cannon.bulletSpeed * 0.1f; // Asume que la velocidad es constante
            distanceText.text = "DISTANCE: " + distanceTravelled.ToString("0.00") + " m";
        }
    }

    public void GameOver() // Añade esta función
    {
        gameUtils.GameOver();
    }
}
