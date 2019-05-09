using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPerso : MonoBehaviour {

    public bool resetAchat;

    public Image PreviewPerso;

    public GameObject buttonBuy;

    public money Money;

    int Skins;

    public Sprite[] Skin;

	void Start () {

        if (PlayerPrefs.GetInt("Skin0") == 0)
            PlayerPrefs.SetInt("Skin0", 1);


        if (Money == null)
            Money = GameObject.FindGameObjectWithTag("MoneyUI").GetComponent<money>();

        int skin = PlayerPrefs.GetInt("Skin");

        if(skin > -1)
                PreviewPerso.sprite = Skin[skin];

        int color = PlayerPrefs.GetInt("Color");

        if (color == 1)
            PreviewPerso.color = new Color(1, 1, 0, 1);
        if (color == 2)
            PreviewPerso.color = new Color(1, 0.6987091f, 0, 1);
        if (color == 3)
            PreviewPerso.color = new Color(1, 0, 0, 1);
        if (color == 4)
            PreviewPerso.color = new Color(1, 0, 1, 1);
        if (color == 5)
            PreviewPerso.color = new Color(0, 0, 1, 1);
        if (color == 6)
            PreviewPerso.color = new Color(0, 1, 1, 1);
        if (color == 7)
            PreviewPerso.color = new Color(0, 1, 0, 1);
        if (color == 8)
            PreviewPerso.color = new Color(0.45f, 0.35f, 0, 1);

        string name = "Skin" + (skin);

        if (PlayerPrefs.GetInt(name) == 1)
        {
            buttonBuy.SetActive(false);
        }
        else
        {
            buttonBuy.SetActive(true);
        }
    }
	
	void Update () {
		if(resetAchat == true)
        {
            for(int i = 1; i < Skin.Length; i++)
            {
                string name = "Skin" + (i);

                PlayerPrefs.SetInt(name, 0);
                
            }
            if (PlayerPrefs.GetInt(name) == 1)
            {
                buttonBuy.SetActive(false);
            }
            resetAchat = false;
        }
	}

    public void SetColor(int color)
    {
        PlayerPrefs.SetInt("Color", color);

        if (color == 1)
            PreviewPerso.color = new Color(1, 1, 0, 1);
        if (color == 2)
            PreviewPerso.color = new Color(1, 0.6987091f, 0, 1);
        if (color == 3)
            PreviewPerso.color = new Color(1, 0, 0, 1);
        if (color == 4)
            PreviewPerso.color = new Color(1, 0, 1, 1);
        if (color == 5)
            PreviewPerso.color = new Color(0, 0, 1, 1);
        if (color == 6)
            PreviewPerso.color = new Color(0, 1, 1, 1);
        if (color == 7)
            PreviewPerso.color = new Color(0, 1, 0, 1);
        if (color == 8)
            PreviewPerso.color = new Color(0.45f, 0.35f, 0, 1);
    }

    public void SetSkin(int value)
    {
        Skins = value;

        string name = "Skin" + (value - 1);

        if(PlayerPrefs.GetInt(name) == 1)
        {
            PlayerPrefs.SetInt("Skin", value - 1);
            buttonBuy.SetActive(false);
        }
        else
        {
            buttonBuy.SetActive(true);
        }
            

        PreviewPerso.sprite = Skin[value - 1];

    }

    public void Buy()
    {
        if(Money.Money >= 100)
        {
            string name = "Skin" + (Skins - 1);

            PlayerPrefs.SetInt(name, 1);

            PlayerPrefs.SetInt("Skin", Skins - 1);

            buttonBuy.SetActive(false);

            Money.RemoveMoney(100);
            Debug.Log("-100");
        }
        
    }
}
