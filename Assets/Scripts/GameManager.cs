using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Boolean isPolloLanzado = false;
    private int coinCount;
    public GameUtils gameUtils;
    public Text coinText;

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

    public void GameOver() // Añade esta función
    {
        gameUtils.GameOver();
    }
}
