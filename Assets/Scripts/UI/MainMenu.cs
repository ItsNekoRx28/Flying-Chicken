using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static int canon = 0;
    public static int flap = 0;
    public static int life = 0;
    public static int fall = 0;

    public Sprite circLleno;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("cannon1") != null)
        {
            for (int i = 1; i <= canon; i++)
            {

                GameObject.Find("cannon" + i).GetComponent<Image>().sprite = circLleno;
            }
            for (int i = 1; i <= flap; i++)
            {

                GameObject.Find("flaps" + i).GetComponent<Image>().sprite = circLleno;
            }
            for (int i = 1; i <= life; i++)
            {

                GameObject.Find("life" + i).GetComponent<Image>().sprite = circLleno;
            }
            for (int i = 1; i <= fall; i++)
            {

                GameObject.Find("fall" + i).GetComponent<Image>().sprite = circLleno;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("WinLose");
    }
    public void LoadStart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevelUi()
    {
        SceneManager.LoadScene("uiNivel");
    }
    public void LoadShop()
    {
        SceneManager.LoadScene("ShopMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void mejoraCanon()
    {
        if (canon < 5) {
            canon++;
            GameObject.Find("cannon" + canon).GetComponent<Image>().sprite = circLleno;
        }
    }
    public void mejoraFlap()
    {
        if (flap < 5)
        {
            flap++;
            GameObject.Find("flaps" + flap).GetComponent<Image>().sprite = circLleno;
        }
    }
    public void mejoraLife()
    {
        if (life < 4)
        {
            life++;
            GameObject.Find("life" + life).GetComponent<Image>().sprite = circLleno;
        }
    }
    public void mejoraFall()
    {
        if (fall < 5)
        {
            fall++;
            GameObject.Find("fall" + fall).GetComponent<Image>().sprite = circLleno;
        }
    }

}
