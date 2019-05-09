using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuUI : MonoBehaviour {

    public GameObject Level;
    public GameObject Parametre;
    public Scrollbar scrollbarVolume;
    public GameObject Personnalisation;
    public GameObject MenuCredit;

    public Sprite MutePrefab;
    public Sprite NoMutePrefab;

	void Start () {
        scrollbarVolume.value = PlayerPrefs.GetFloat("Volume");
        Level.SetActive(false);
        Parametre.SetActive(false);
    }

	void Update () {
        if(Parametre.activeSelf)
            PlayerPrefs.SetFloat("Volume", scrollbarVolume.value);
    }

    public void play()
    {
        if (Level.activeSelf == true)
        {
            Level.SetActive(false);
        }
        else
        {
            Level.SetActive(true);
        }

        if (Parametre.activeSelf == true)
        {
            Parametre.SetActive(false);
        }

        if (Personnalisation.activeSelf == true)
        {
            Personnalisation.SetActive(false);
        }

        if (MenuCredit.activeSelf == true)
        {
            MenuCredit.SetActive(false);
        }
    }

    public void Option()
    {
        if (Parametre.activeSelf == true)
        {
            Parametre.SetActive(false);
        }
        else
        {
            Parametre.SetActive(true);
        }

        if (Level.activeSelf == true)
        {
            Level.SetActive(false);
        }

        if (Personnalisation.activeSelf == true)
        {
            Personnalisation.SetActive(false);
        }

        if (MenuCredit.activeSelf == true)
        {
            MenuCredit.SetActive(false);
        }
    }

    public void Credit()
    {
        if (MenuCredit.activeSelf == true)
        {
            MenuCredit.SetActive(false);
        }
        else
        {
            MenuCredit.SetActive(true);
        }

        if (Level.activeSelf == true)
        {
            Level.SetActive(false);
        }

        if (Personnalisation.activeSelf == true)
        {
            Personnalisation.SetActive(false);
        }

        if (Parametre.activeSelf == true)
        {
            Parametre.SetActive(false);
        }
    }

    public void Custom()
    {
        if (Personnalisation.activeSelf == true)
        {
            Personnalisation.SetActive(false);
        }
        else
        {
            Personnalisation.SetActive(true);
        }

        if (Level.activeSelf == true)
        {
            Level.SetActive(false);
        }

        if (Parametre.activeSelf == true)
        {
            Parametre.SetActive(false);
        }

        if (MenuCredit.activeSelf == true)
        {
            MenuCredit.SetActive(false);
        }
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Urlbrowser(string Url)
    {
        Application.OpenURL(Url);
    }
}



