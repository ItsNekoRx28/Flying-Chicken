using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;   
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isPolloLanzado = false;
    private int coinCount;
    public GameUtils gameUtils;
    public Text coinText;
    public AudioSource SoundSource;
    public AudioClip coinSoundClip;

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

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + amount);
        PlayerPrefs.Save();
        SoundSource.PlayOneShot(coinSoundClip);
    }

    public void GameOver() // Añade esta función
    {
        gameUtils.GameOver();
    }
}
