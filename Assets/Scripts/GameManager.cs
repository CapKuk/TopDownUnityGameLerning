using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resorses
    public List<Sprite> playerSprite;
    public List<Sprite> weponSprite;
    public List<int> weponPrises;
    public List<int> xpTable;

    //Referenses
    public Player player;
    //public Wepon wepon

    public FloatingTextManager floatingTextManager;

    public int pesos;
    public int experience;


    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    //Save state
    /*
     INT preferedSkin
     INT pesos
     INT xp
     INT weapon lvl
     */
    public void SaveState()
    {
        string saving = "";

        saving += "0" + "|"; // preferedSkin
        saving += pesos.ToString() + "|"; // pesos
        saving += experience.ToString() + "|"; // xp
        saving += "0"; // weaponLvl

        PlayerPrefs.SetString("SaveState", saving);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin

        //Change pesos
        pesos = int.Parse(data[1]);

        //Chadge xp
        experience = int.Parse(data[2]);

        //Change wepon lvl

    }
}
