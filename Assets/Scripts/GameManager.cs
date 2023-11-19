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
    public GameObject startPos;
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
 
    }



    public void GameOver() // Añade esta función
    {
        gameUtils.GameOver();
    }
}
