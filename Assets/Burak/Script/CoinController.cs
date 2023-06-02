using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinController : MonoBehaviour
{
    public int Coin;

    public Text coinText;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("Coin"))
        {
            Coin = PlayerPrefs.GetInt("Coin",0);
        }
        else
        {
            Coin = 0;
        }
        UpdateCoin();

    }
    public void MakeMoney()
    {
        Coin = Coin + 100;
        PlayerPrefs.SetInt("Coin",Coin);
        UpdateCoin();

    }

    public void SpendMoney(int amount)
    {
        Coin = Coin - amount;
        PlayerPrefs.SetInt("Coin", Coin);
        UpdateCoin();

    }

   void UpdateCoin()
    {
        coinText.text = Coin.ToString();
    }
}
