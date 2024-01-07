using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUtils : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject winUI;
    private bool isPaused = false;
    private bool isGameOver = false;
    private bool isGameWin = false;

    public AudioSource SoundSource;
    public AudioSource BackgroundSoundSource;
    public AudioClip deathSoundClip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else if (isGameOver)
            {
                Restart();
            }
            else if (isGameWin){
                //ir al menu principal
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        BackgroundSoundSource.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        BackgroundSoundSource.Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void GameOver()
    {
        BackgroundSoundSource.Stop();
        SoundSource.PlayOneShot(deathSoundClip);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void Win()
    {
        BackgroundSoundSource.Stop();
        winUI.SetActive(true);
        Time.timeScale = 0f;
        isGameWin = true;
    }

    public void Restart()
    {
        // Carga la escena actual de nuevo
        PlayerPrefs.SetInt("levelLife", PlayerPrefs.GetInt("life"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    public void QuitGame()
    {
        // Cierra la aplicaci�n
        Application.Quit();
    }

    public void BackToMenu()
    {
        // Carga la escena actual de nuevo
        Resume();
        SceneManager.LoadScene("LevelMenu");
        
    }
}