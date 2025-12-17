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
   [SerializeField] LevelController levelController;
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
       if(gameController)
        gameController.OnGameEnd += GameEnd;
    }
    private void OnDisable()
    {
               if (gameController)
            gameController.OnGameEnd -= GameEnd;
    }
    public void MakeMoney()
    {
        int earnings = 100; // Default (Normal Level)

        if (levelController != null && levelController.isDailyLevel)
        {
            earnings = 200; // Daily Level Bonus
        }

        Coin += earnings;
        PlayerPrefs.SetInt("Coin", Coin);
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
