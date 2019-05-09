using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    public bool unlockAll;
    public bool Game;
    float timer;
    public bool StartTimer;
    public bool LockTimer;
    public int Level;
    public Text TimerText;
    public Text LevelText;
    public GameObject Player;
    public MenuGame menuGame;
    string Name;
    string Record;
    GameObject[] Bullet;
    public int MaxBullet = 100;
    int bulletDeleted = 0;
    private GameObject[] Turret;
    string  name;

    void Awake () {
		if(PlayerPrefs.GetInt("Level") == 0 && !Game)
        {
            PlayerPrefs.SetInt("Level", 1);
        }

        if(menuGame != null)
            menuGame.gameObject.SetActive(true);

        if (unlockAll && !Game)
        {
            PlayerPrefs.SetInt("Level", 9);
            if (PlayerPrefs.GetInt("unlockAll") == 0)
            {
                PlayerPrefs.SetInt("Money", 2000);
                PlayerPrefs.SetInt("unlockAll", 1);
            }
                
        }
    }

    void Start()
    {
        if(Level >= 7)
        {
            Turret = GameObject.FindGameObjectsWithTag("Turret");
            for(int i = 0; i < Turret.Length; i++)
            {
                Turret[i].GetComponent<Tourelle>().Explosif = true;
            }
        }

        bulletDeleted -= 1;
        Name = "Record" + Level;
        name = "Level" + Level;

        if (PlayerPrefs.GetInt(Name) == 0)
        {
            Record = "-";
        }
        else
        {
            Record = PlayerPrefs.GetInt(Name).ToString();
        }

        if (menuGame == null && Game)
            menuGame = GameObject.FindGameObjectWithTag("Canvas").GetComponent<MenuGame>();

        if (LevelText == null && Game)
            LevelText = GameObject.FindGameObjectWithTag("Level").GetComponent<Text>();
         
        if (Player == null && Game)
            Player = GameObject.FindGameObjectWithTag("Player");

        if(Game)
            TimerText.text = "Timer: " + Mathf.Round(timer).ToString() + "         " + "record: " + Record;
    }

    void Update()
    {
        Bullet = GameObject.FindGameObjectsWithTag("Bullet");
        bulletDeleted = Bullet.Length - MaxBullet;
        if (MaxBullet < Bullet.Length)
        {          
            for (int i = 0; i < bulletDeleted; i++)
            {
                Destroy(Bullet[i].gameObject);
            }
        }

        if (PlayerPrefs.GetInt(Name) == 0)
        {
            Record = "-";
        }
        else
        {
            Record = PlayerPrefs.GetInt(Name).ToString();
        }

        if (Game)
        {
            if (Player.GetComponent<PlayerMovement>().Jump == true ||
            Player.GetComponent<PlayerMovement>().Left == true ||
            Player.GetComponent<PlayerMovement>().Right == true && !LockTimer)
            {
                StartTimer = true;
            }

            if (StartTimer && !LockTimer)
            {
                timer += Time.deltaTime;
                TimerText.text = "Timer: " + Mathf.Round(timer).ToString() + "         " + "record: " + Record;
            }

            if (LockTimer)
            {              
                if(PlayerPrefs.GetInt(Name) == 0)
                {
                    if (Mathf.Round(timer) > PlayerPrefs.GetFloat(Name))
                    {
                        PlayerPrefs.SetInt(Name, Mathf.RoundToInt(timer));
                    }
                }


                //debloqué le niveux suivant
                if(PlayerPrefs.GetInt("Level") < Level + 1)
                    PlayerPrefs.SetInt("Level", Level + 1);

                LevelText.text = "Level " + Level;

                menuGame.LevelEnd();

                // desactivé les touche
                Player.GetComponent<PlayerMovement>().Left = false;
                Player.GetComponent<PlayerMovement>().Right = false;
                Player.GetComponent<PlayerMovement>().Jump = false;

                // affiché le menuEnt;
                LevelText.transform.parent.gameObject.SetActive(true);

                switch (Level)
                {
                    case 9:
                        SetStar(53, 57, 62);
                        break;
                    case 8:
                        SetStar(42, 48, 53);
                        break;
                    case 7:
                        SetStar(37, 41, 44);
                        break;
                    case 6:
                        SetStar(45, 50, 55);
                        break;
                    case 5:
                        SetStar(49, 54, 59);
                        break;
                    case 4:
                        SetStar(37, 40, 43);
                        break;
                    case 3:
                        SetStar(29, 34, 39);
                        break;
                    case 2:
                        SetStar(32, 37, 41);
                        break;
                    case 1:
                        SetStar(18, 21, 24);
                        break;
                    default:
                        Debug.LogError("not Level referenced");
                        break;
                }

                if (Mathf.RoundToInt(timer) < PlayerPrefs.GetInt(Name))
                {
                    Debug.Log("2");
                    PlayerPrefs.SetInt(Name, Mathf.RoundToInt(timer));
                }
                TimerText.text = "Timer: " + Mathf.Round(timer).ToString() + "         " + "record: " + Record;
            }
        }
    }

    

    public void ResetTimer()
    {
        if (!LockTimer)
        {
            StartTimer = false;
            timer = 0;
            TimerText.text = "Timer: " + Mathf.Round(timer).ToString() + "         " + "record: " + Record;
        }
        else
        {
            ShowAd();
            SceneManager.LoadScene(Level);
        }
    }

    public void Respawn()
    {
        ResetTimer();
        for (int i = 0; i < Bullet.Length; i++)
        {
            if (Bullet[i] != null)
            {
                if (Bullet[i].GetComponent<Projectille>().speed > 0)
                {
                    Destroy(Bullet[i]);
                }
            }
        }
    }

    public void NextLevel()
    {
        ShowAd();
        SceneManager.LoadScene(Level + 1);
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public void SetStar(int x, int y, int z)
    {
        
        if (Mathf.RoundToInt(timer) <= x)
        {
            SaveLevelAndStar(3);
        }
        else if (Mathf.RoundToInt(timer) <= y)
        {
            SaveLevelAndStar(2);
        }
        else if (Mathf.RoundToInt(timer) <= z)
        {
            SaveLevelAndStar(1);
        }
    }

    public void SaveLevelAndStar(int Star)
    {
        Debug.Log(name + " : " + Star);
        if (PlayerPrefs.GetInt(name) < Star)
        {
            PlayerPrefs.SetInt(name, Star);
            Debug.Log(Star);
        }
        
        LevelText.transform.parent.gameObject.GetComponent<MenuLevel>().Refrech(Star);
    }
}
