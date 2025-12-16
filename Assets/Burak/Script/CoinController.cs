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

        
            

        if(PlayerPrefs.HasKey("CGBCoin"))
        {
            Coin = PlayerPrefs.GetInt("CGBCoin",0);
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
        if(levelController!=null)
        {
            if(levelController.isDailyLevel)
            {
 Coin = Coin + 200;
        PlayerPrefs.SetInt("CGBCoin",Coin);
        UpdateCoin();
            }
 
        }
        else
        {
  Coin = Coin + 100;
        PlayerPrefs.SetInt("CGBCoin",Coin);
        UpdateCoin();
        }
      

    }

    public void SpendMoney(int amount)
    {
        Coin = Coin - amount;
        PlayerPrefs.SetInt("CGBCoin", Coin);
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
