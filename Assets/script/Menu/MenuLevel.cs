using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour {

    public Image[] Etoile;
    public int Level;
    public GameManager gameManager;

	void Start () {
        if(gameObject.GetComponentInChildren<Text>().text != Level.ToString())
        {
            gameObject.GetComponentInChildren<Text>().text = Level.ToString();
        }
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if(gameManager != null && gameManager.Game)
        {
            Level = gameManager.Level;
        }
        string name = "Level" + Level;
        int value = PlayerPrefs.GetInt(name);
        if (Level <= PlayerPrefs.GetInt("Level"))
        {
            if(GetComponent<Button>() != null)
                GetComponent<Button>().interactable = true;
        }
        else
        {
            if (GetComponent<Button>() != null)
                GetComponent<Button>().interactable = false;
        }
        for(int i = 0; i < value; i++)
        {
            Etoile[i].color = new Color(255, 255, 0, 255);
        }

	}

    public void OpenLevel()
    {
        Debug.Log("Load Scene " + name);
        SceneManager.LoadScene(name);
    }

    public void Refrech(int value)
    {

        for (int i = 0; i < Etoile.Length; i++)
        {
            Etoile[i].color = new Color(0.4156863f, 0.4156863f, 0.4156863f, 1);
        }

        for (int i = 0; i < value; i++)
        {
            Etoile[i].color = new Color(1, 1, 0, 1);
        }
        Debug.Log(value);
    }

    
}
