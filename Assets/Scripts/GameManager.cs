using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public Player player;
    public FloatingTextManager floatingTextManager;
    

    public int pesos;
    public int experiense;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duraion)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duraion);
    }
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experiense.ToString() + "|";
        s += "0";
        
        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {

        Debug.Log("LoadState");
        
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        pesos = int.Parse(data[1]);
        experiense = int.Parse(data[2]);
    }
}
