using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MenuGame : MonoBehaviour {

    public GameManager gameManager;

    public GameObject Player;

    public GameObject[] MenuPause;

    public GameObject[] touch;

	void Start () {

        if(gameManager == null)
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (Player == null)
            Player = GameObject.FindGameObjectWithTag("Player");
        
        for (int i = 0; i < MenuPause.Length; i++)
        {
            MenuPause[i].SetActive(false);
        }
    }
	
	void Update () {
		
	}

    public void Pause()
    {
        if (MenuPause[0].activeSelf == true)
        {
            for(int i = 0; i < MenuPause.Length; i++)
            {
                MenuPause[i].SetActive(false);
            }

            Time.timeScale = 1;

        }
        else
        {
            for (int i = 0; i < MenuPause.Length; i++)
            {
                MenuPause[i].SetActive(true);
            }

            Time.timeScale = 0;
        }

    }

    public void RetourMenu()
    {
        Time.timeScale = 1;
        ShowAd();
        SceneManager.LoadScene(0);
    }

    public void Relancer()
    {
        gameManager.ResetTimer();
        Player.GetComponent<PlayerMovement>().respawn = true;

        for (int i = 0; i < MenuPause.Length; i++)
        {
            MenuPause[i].SetActive(false);
        }

        Time.timeScale = 1;

    }

    public void NextLevel()
    {
        gameManager.NextLevel();
    }

    public void LevelEnd()
    {
        for (int i = 0; i < MenuPause.Length; i++)
        {
            MenuPause[i].SetActive(false);
        }

        for (int i = 0; i < touch.Length; i++)
        {
            touch[i].SetActive(false);
        }
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
