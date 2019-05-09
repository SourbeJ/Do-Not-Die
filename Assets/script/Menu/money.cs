using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip audioClip;

    public int CheckMoney;
    Text MoneyText;
    public int Money;

    public bool Give_100;
    public bool Reset;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        MoneyText = GetComponent<Text>();
        Money = PlayerPrefs.GetInt("Money");
        MoneyText.text = Money.ToString();

        CheckMoney = Money;
	}

    private void Update()
    {
        if (Give_100 != false)
            GetMoney(100);
        Give_100 = false;

        if (Reset != false)
            GetMoney(-CheckMoney);
        Reset = false;
    }

    public void GetMoney(int value)
    {
        audioSource.PlayOneShot(audioClip);
        Money += value;
        PlayerPrefs.SetInt("Money",Money);
        MoneyText.text = Money.ToString();
        CheckMoney = Money;
    }

    public void RemoveMoney(int value)
    {
        Money -= value;
        PlayerPrefs.SetInt("Money", Money);
        MoneyText.text = Money.ToString();
        CheckMoney = Money;
    }


}
