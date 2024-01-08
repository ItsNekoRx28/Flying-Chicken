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

    private static int cost = 3;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("persistencia") != 1){
            PlayerPrefs.SetInt("persistencia", 0);
        }
        bool isShopMenu = SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("ShopMenu"));
        bool isMainMenu = SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("MainMenu"));
        bool isTutorialMenu = SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("TutorialMenu"));

        //if (GameObject.Find("cannon1") != null)
        if (isShopMenu)
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

        if (!isMainMenu && !isTutorialMenu)
        {
            coinCount = PlayerPrefs.GetInt("Coins");
            coinText.text = coinCount.ToString();
        }
    }

    public void LoadLevel1()
    {
        PlayerPrefs.SetInt("levelLife", PlayerPrefs.GetInt("life"));
        SceneManager.LoadScene("Main_V0.2.3");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("persistencia", 1);

    }

    public void LoadLevelMenu()
    {
        bool isMainMenu = SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("MainMenu"));
        bool tutorialCompleted = PlayerPrefs.GetInt("tutorial") == 1? true : false;
        if (isMainMenu && !tutorialCompleted)
        {
            LoadTutorialMenu();
        }
        else
        {
            SceneManager.LoadScene("LevelMenu");
        }
    }

    public void LoadShopMenu()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void LoadTutorialMenu()
    {
        SceneManager.LoadScene("TutorialMenu");
        PlayerPrefs.SetInt("tutorial", 1);
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("persistencia", 0);
        Application.Quit();
    }

    public void MejoraCanon()
    {
        if (canon < 5 && transaccion()) {
            canon++;
            GameObject.Find("cannon" + canon).GetComponent<Image>().sprite = circLleno;
            PlayerPrefs.SetInt("cannon", canon);
        }
    }

    public void MejoraFlap()
    {
        if (flap < 5 && transaccion())
        {
            flap++;
            GameObject.Find("flaps" + flap).GetComponent<Image>().sprite = circLleno;
            PlayerPrefs.SetInt("flap", flap);
        }
    }

    public void MejoraLife()
    {
        if (life < 4 && transaccion())
        {  
            life++;
            GameObject.Find("life" + life).GetComponent<Image>().sprite = circLleno;
            PlayerPrefs.SetInt("life", life);
        }
    }
    public void MejoraFall()
    {
        if (fall < 5 && transaccion())
        {
            fall++;
            GameObject.Find("fall" + fall).GetComponent<Image>().sprite = circLleno;
            PlayerPrefs.SetInt("fall", fall);
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
