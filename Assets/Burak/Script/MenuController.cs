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
    [SerializeField] GameObject driftButton;
  [SerializeField]  bool isSoftPublish = false;

    [SerializeField] GameObject DifficultyButtonObj;
    [SerializeField] GameObject chaseModeButton;
    [SerializeField] string chaseSceneName = "Chase";

 

    //[SerializeField] AdManager adManager;
    
    CoinController coinController;

   [SerializeField] int difficulty;
    private void Awake()
    { 
        if (PlayerPrefs.GetInt("IsDailyLevel", 0) == 1)
        {
             PlayerPrefs.SetInt("IsDailyLevel", 0);
        }
        
        try {
            CheckDailyMapStatus();
        } catch (System.Exception e) {
            Debug.LogError("Error checking daily map status: " + e.Message);
        }
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
        CheckChaseButton();
     }
     
     void CheckChaseButton()
    {
        if (chaseModeButton == null) return;

        // Ensure we are checking the progressed level, not just the selected one
        int unlockedLevel = PlayerPrefs.GetInt("CPLevel", 1);
        
        // Check if player has passed level 7 (meaning they are at least on level 8 or completed 7)
        // Adjust logic if "CPLevel" represents the *current* level to play. 
        // If CPLevel is 8, it means 7 is finished.
        if (unlockedLevel > 7)
        {
            chaseModeButton.SetActive(true);

            // Animation Logic for first time
            if (PlayerPrefs.GetInt("ChaseButtonShown", 0) == 0)
            {
                chaseModeButton.transform.localScale = Vector3.zero;
                chaseModeButton.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
                PlayerPrefs.SetInt("ChaseButtonShown", 1);
            }
            else
            {
                chaseModeButton.transform.localScale = Vector3.one;
            }
        }
        else
        {
            chaseModeButton.SetActive(false);
        }
    }

    public void LoadChaseScene()
    {
        SceneManager.LoadScene(chaseSceneName);
    }
     public void MapOfTheDay()
     {
 PlayerPrefs.SetInt("IsDailyLevel", 1);
        PlayerPrefs.SetInt("Car", activeCarIndex);
        SceneManager.LoadScene("Game"); // Yüklenecek sahnenin adı
     }
     public void ButtonMapOfTheDay()
     {
       MapOfTheDay();
     }
    public void LoadDrift()
    {
    
        PlayerPrefs.SetInt("Car", activeCarIndex);


        SceneManager.LoadScene("Drift"); // Yüklenecek sahnenin adı
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


        SceneManager.LoadScene("Game"); // Yüklenecek sahnenin adı
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
        /*
        if( adManager.RewardedAdManager.IsRewardedAdReady())
        {
            adManager.RewardedAdManager.RegisterOnUserEarnedRewarededEvent(UnlockWithRewarded);
            adManager.RewardedAdManager.RegisterOnAdClosedEvent(OnAdClosed);

            adManager.RewardedAdManager.ShowAd();
        }
        */
    }

    private void OnAdClosed()
    {
        /*
        adManager.RewardedAdManager.UnRegisterOnUserEarnedRewarededEvent(UnlockWithRewarded);
        adManager.RewardedAdManager.UnRegisterOnAdClosedEvent(OnAdClosed);
        */
    }
     
    private void UnlockWithRewarded()
    {
        Price price = cars[activeCarIndex].GetComponent<Price>();

         price.Unlock();
        UpdateBuyButton();
    }
public   void UnlockWithParts()
    {
        Price price = cars[4].GetComponent<Price>();

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
            RewardedButtonSetactive(true);
        }
        else
        {
            
            buyButton.SetActive(false);
           RewardedButtonSetactive(false);

            EnableRace();
        }
        
    }
    private void RewardedButtonSetactive(bool setActive)
    {
        if(setActive)
        {
            if (isSoftPublish)
                return;

                rewardedButton.SetActive(true);

        }
        else
            rewardedButton.SetActive(false);

    }
    void DisableRace()
    {
        RaceButton.gameObject.SetActive(false);
        driftButton.gameObject.SetActive(false);
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

   [SerializeField] TextMeshProUGUI dailyMapStatusText;
   [SerializeField] Button dailyMapButton;
    public void CheckDailyMapStatus()
    {
        // Defensive check: If UI references are missing, exit to avoid crashing Awake()
        if (dailyMapStatusText == null || dailyMapButton == null)
        {
            Debug.LogError("Daily Map UI references are NULL in MenuController! Check Inspector.");
            return;
        }

        string savedDate = PlayerPrefs.GetString("DailyLevelDate", "");
        string today = System.DateTime.Now.ToString("yyyy-MM-dd");

        if (savedDate != today)
        {
            // New day detected, reset status
            PlayerPrefs.SetInt("IsDailyLevel", 0);
            PlayerPrefs.SetString("DailyLevelDate", today);
        }

        if (PlayerPrefs.GetInt("IsDailyLevel", 0) == 2)
        {
             // Map of the day completed
             Debug.Log("Daily Map Completed");
             dailyMapStatusText.text = "Come Again Tomorrow";
             dailyMapButton.interactable=false;
        }
        else
        {
             // Map of the day not played yet
             Debug.Log("Daily Map Not Played");
             dailyMapStatusText.text = "Play Map Of The Day";
             dailyMapButton.interactable = true;   
 
         }
    }
}
