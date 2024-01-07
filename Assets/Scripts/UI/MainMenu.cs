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

    public Text coinText;
    private static int coinCount;

    private static int cost = 10;

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

        coinCount = PlayerPrefs.GetInt("Coins");
        print("MAINMENU");
        print(coinCount);
        coinText.text = coinCount.ToString();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Main_V0.2.1");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void LoadShopMenu()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MejoraCanon()
    {
        if (canon < 5 && transaccion()) {
            canon++;
            GameObject.Find("cannon" + canon).GetComponent<Image>().sprite = circLleno;
        }
    }

    public void MejoraFlap()
    {
        if (flap < 5 && transaccion())
        {
            flap++;
            GameObject.Find("flaps" + flap).GetComponent<Image>().sprite = circLleno;
        }
    }

    public void MejoraLife()
    {
        if (life < 4 && transaccion())
        {
            life++;
            GameObject.Find("life" + life).GetComponent<Image>().sprite = circLleno;
        }
    }
    public void MejoraFall()
    {
        if (fall < 5 && transaccion())
        {
            fall++;
            GameObject.Find("fall" + fall).GetComponent<Image>().sprite = circLleno;
        }
    }

    private bool transaccion()
    {
        int newCoinCount = coinCount - cost;
        if(newCoinCount < 0)
        {
            return false;
        }

        coinCount = newCoinCount;
        coinText.text = coinCount.ToString();

        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.Save();

        return true;
    }

}
