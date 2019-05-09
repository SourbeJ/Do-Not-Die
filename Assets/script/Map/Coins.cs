using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class Coins : MonoBehaviour {



    public money MoneyText;

    int Money;

    private void Start()
    {

        MoneyText = GameObject.FindGameObjectWithTag("MoneyUI").GetComponent<money>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MoneyText.GetMoney(1);
            Destroy(gameObject);
        }

    }
}
