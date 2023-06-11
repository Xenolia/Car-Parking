using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.InteropServices;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] int activeCarIndex;
 
    [SerializeField] GameObject[] disableButtons;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject buyButton;
    [SerializeField] GameObject rewardedButton;
    [SerializeField] GameObject RaceButton;

    [SerializeField] GameObject DifficultyButtonObj;

#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern bool IsMobileBrowser();
#endif

    [SerializeField] AdManager adManager;
    
    CoinController coinController;

   [SerializeField] int difficulty;
    private void Awake()
    {
        if(IsMobileBrowser())
                 Screen.orientation = ScreenOrientation.LandscapeRight;


        coinController = GetComponent<CoinController>();
         CheckButtons();
        UpdateBuyButton();

       if(PlayerPrefs.HasKey("Difficulty"))
        {
           difficulty= PlayerPrefs.GetInt("Difficulty");
        }
        else
        {
            difficulty = 1;
            PlayerPrefs.SetInt("Difficulty",1);
        }
        SetDifficultyButton();
     }
    public void DifficultyButton()
    {
        if (difficulty == 3)
        {
            difficulty = 0;
            PlayerPrefs.SetInt("Difficulty", 0);

        }

        difficulty = (PlayerPrefs.GetInt("Difficulty")) + 1 ;

        SetDifficultyButton();

    }
    void SetDifficultyButton()
    {
        if(difficulty==1)
        {
            EasyDifficulty();
        }
        if (difficulty == 2)
        {
            MediumDifficulty();
        }
        if (difficulty == 3)
        {
            HardDifficulty();
        }
    }
    void EasyDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        DifficultyButtonObj.GetComponentInChildren<TextMeshProUGUI>().text = "EASY";
        DifficultyButtonObj.GetComponent<Image>().color = Color.blue;
    }
    void MediumDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        DifficultyButtonObj.GetComponentInChildren<TextMeshProUGUI>().text = "MEDIUM";
        DifficultyButtonObj.GetComponent<Image>().color = Color.magenta;

    }

    void HardDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
        DifficultyButtonObj.GetComponentInChildren<TextMeshProUGUI>().text = "HARD";
        DifficultyButtonObj.GetComponent<Image>().color = Color.red;

    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("Car",activeCarIndex);


        SceneManager.LoadScene(1);
    }

    public void NextCar()
    {
        foreach (var item in cars)
        {
            item.SetActive(false);
        }
        
        activeCarIndex++;
        cars[activeCarIndex].SetActive(true);

        CheckButtons();
        UpdateBuyButton();

    }

    public void BuyButton()
    {
        Price price = cars[activeCarIndex].GetComponent<Price>();

        coinController.SpendMoney(price.CarPrice);
        price.Unlock();
        UpdateBuyButton();
    }

    public void RewardedButton()
    {
        if( adManager.RewardedAdManager.IsRewardedAdReady())
        {
            adManager.RewardedAdManager.RegisterOnUserEarnedRewarededEvent(UnlockWithRewarded);
            adManager.RewardedAdManager.RegisterOnAdClosedEvent(OnAdClosed);

            adManager.RewardedAdManager.ShowAd();
        }
    }

    private void OnAdClosed(IronSourceAdInfo obj)
    {
        adManager.RewardedAdManager.UnRegisterOnUserEarnedRewarededEvent(UnlockWithRewarded);
        adManager.RewardedAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
    }
     
    private void UnlockWithRewarded(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {
        Price price = cars[activeCarIndex].GetComponent<Price>();

         price.Unlock();
        UpdateBuyButton();
    } 

    void CheckBuyButtonCoin(Price price)
    {
        if(coinController.Coin>=price.CarPrice)
        {
            buyButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            buyButton.GetComponent<Button>().interactable = false;
        }
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = price.CarPrice.ToString();
    }
    void UpdateBuyButton()
    {
        Price price= cars[activeCarIndex].GetComponent<Price>();

        if(price.Locked)
        {
            buyButton.SetActive(true);
            CheckBuyButtonCoin(price);
            DisableRace();
            rewardedButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);
            rewardedButton.SetActive(false);

            EnableRace();
        }
        
    }

    void DisableRace()
    {
        RaceButton.gameObject.SetActive(false);
    }
    void EnableRace()
    {
        RaceButton.gameObject.SetActive(true);
     }
    void CheckButtons()
    {
        nextButton.SetActive(true);
        previousButton.SetActive(true);

        if (activeCarIndex == cars.Length-1)
        {
            nextButton.SetActive(false);
        }

        if (activeCarIndex == 0)
        {
            previousButton.SetActive(false);
        }
    }
    public void PreviousCar()
    {

        foreach (var item in cars)
        {
            item.SetActive(false);
        }

        activeCarIndex--;
        cars[activeCarIndex].SetActive(true);
        CheckButtons();
        UpdateBuyButton();

    }
    void EnableButtons()
    {
        foreach (var item in disableButtons)
        {
            item.SetActive(true);
        }
    }
    void DisableButtons()
    {
        foreach (var item in disableButtons)
        {
            item.SetActive(false);
        }
    }

    
}
