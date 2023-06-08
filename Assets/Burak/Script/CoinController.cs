using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinController : MonoBehaviour
{
    public int Coin;

    public Text coinText;
    GameController gameController;
   [SerializeField] int GodMode = 0;
    private void Awake()
    {
        gameController = GetComponent<GameController>();
         
            for (int i = 0; i < GodMode; i++)
            {
            MakeMoney();
            }

        
            

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
    private void OnEnable()
    {
        gameController.OnGameEnd += GameEnd;
    }
    private void OnDisable()
    {
        gameController.OnGameEnd -= GameEnd;

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

    void GameEnd()
    {
        coinText.gameObject.SetActive(true);
    }
}
