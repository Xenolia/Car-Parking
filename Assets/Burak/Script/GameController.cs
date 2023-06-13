using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    using System.Runtime.InteropServices;
using System;
using UnityEngine.Experimental.GlobalIllumination;

public class GameController : MonoBehaviour
{
    [SerializeField] Light dayLight;
    [SerializeField] Light nightLight;

    bool nightMode = false;

    [SerializeField] AudioClip winSound, LoseSound;
    [SerializeField] AudioClip CheckPointSound;
    AudioSource audioSource;

    [SerializeField] bool useMobileControls=false;
    [SerializeField] PrometeoCarController carController;
    [SerializeField] GameObject[] mobileButtons;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] Text countDownText;
   public  bool gameFinished = false;

    LevelController levelController;

    public Action OnRevive;
    public Action OnGameEnd;

    CoinController coinController;
    CarManager carManager;

    [SerializeField] Text timerText;
    float targetTime;
   [SerializeField] AdManager adManager;


    bool stopTimer = false;
    int carIndex;
     public void CheckPointPassed()
    {
        audioSource.PlayOneShot(CheckPointSound);
    }
    private void Awake()
    {
        
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
         carManager = FindObjectOfType<CarManager>();
        EnableCar();
        coinController = GetComponent<CoinController>();
        levelController = GetComponent<LevelController>();
  
        
        GameStart();
        if(PlayerPrefs.HasKey("NightMode"))
        {
          var   a = PlayerPrefs.GetInt("NightMode",0);

            if (a == 1)
                nightMode = true;
        }
    
        if (nightMode)
            SwitchLight();
    }
     public void SwitchLight()
    {
        if (!nightLight.gameObject.activeSelf)
        {
            nightLight.gameObject.SetActive(true);
            dayLight.gameObject.SetActive(false);
            nightMode = true;
            PlayerPrefs.SetInt("NightMode",1);
        }
        else
        {
            nightLight.gameObject.SetActive(false);
            dayLight.gameObject.SetActive(true);
            nightMode = false;
            PlayerPrefs.SetInt("NightMode",0);
        }
    }
    void EnableCar()
    {
      carIndex = PlayerPrefs.GetInt("Car",1);
        FindObjectOfType<CarManager>().ActivateCar(carIndex);
    }
    void GameStart()
    {
        Time.timeScale = 1f;
    }
    void SetMobileButtons(bool useMobile)
    {
        if(useMobile)
        {
            foreach (var item in mobileButtons)
            {
                item.SetActive(true);
            }
        }
        carController.useTouchControls = useMobile;

    }
    private void Start()
    {
        carController = FindObjectOfType<PrometeoCarController>();
        SetMobileButtons(useMobileControls);
        targetTime = levelController.GetActiveLevel().gameObject.GetComponent<Level>().GetTime();
        targetTime++;
    }
    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
         if (Input.GetKeyDown(KeyCode.T))
        {
            ReviveButton(null,null);
        }
        */
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeCameraAngle();
        }
       

        if (!stopTimer)
        UpdateTimer();

    }
   public void StopTimer(bool shouldStop)
    {
        if(shouldStop)
        {
            stopTimer = true;
        }
        else
        {
            stopTimer = false;
        }

    }
    void UpdateTimer()
    {
         
            if (targetTime > 0)
            {
            targetTime -= Time.deltaTime;
            }
            else
        {
            targetTime = 0f;
            LevelLoseByTime();
        }
        timerText.text = ((int)targetTime).ToString()+" s";
         
    }
    void LevelLoseByTime()
    {
        if (gameFinished)
            return;
        GameEnd();

        LevelLoseDelay();
     }
    void ChangeCameraAngle()
    {
        carManager.ChangeCamera();
    }
    void Restart()
    {
        levelController.Restart();
    }

    void RestartWithCheckPoint()
    {
        GameObject checkPoint = FindObjectOfType<Level>().LastCheckPoint();
        if (checkPoint != null)
        {
            // carController.transform.position = checkPoint.transform.position;
            var revivePos = checkPoint.transform.position;
            revivePos.y = revivePos.y+1;
            var reviveRot= checkPoint.transform.localEulerAngles;
            reviveRot.y = reviveRot.y-90;
            reviveRot.z = 0;
            carController.Revive(revivePos, reviveRot);

            OnRevive?.Invoke();
        }
        else
        {
            //carController.transform.position = Vector3.zero;
            carController.Revive(Vector3.zero,Vector3.zero);
            OnRevive?.Invoke();
        }
        
    }

 
   public void Revive()
    {
      if(adManager.RewardedAdManager.IsRewardedAdReady())
        {
            adManager.RewardedAdManager.RegisterOnUserEarnedRewarededEvent(ReviveButton);
            adManager.RewardedAdManager.RegisterOnAdShowFailedEvent(RewardedEnd);
            adManager.RewardedAdManager.RegisterOnAdClosedEvent(RewardedEnd);

            adManager.RewardedAdManager.ShowAd();
        } 
    }

    private void RewardedEnd(IronSourceError arg1, IronSourceAdInfo arg2)
    {
        adManager.RewardedAdManager.UnRegisterOnUserEarnedRewarededEvent(ReviveButton);
        adManager.RewardedAdManager.UnRegisterOnAdShowFailedEvent(RewardedEnd);
        adManager.RewardedAdManager.UnRegisterOnAdClosedEvent(RewardedEnd);
    }

    private void RewardedEnd(IronSourceAdInfo obj)
    {
        adManager.RewardedAdManager.UnRegisterOnUserEarnedRewarededEvent(ReviveButton);
        adManager.RewardedAdManager.UnRegisterOnAdShowFailedEvent(RewardedEnd);
        adManager.RewardedAdManager.UnRegisterOnAdClosedEvent(RewardedEnd);
    }

    private void ReviveButton(IronSourcePlacement arg1, IronSourceAdInfo arg2)
    {

        losePanel.SetActive(false);
        gameFinished = false;
       
        targetTime = levelController.GetActiveLevel().gameObject.GetComponent<Level>().GetTime();
        targetTime++;
        timerText.gameObject.SetActive(true);

        RestartWithCheckPoint();
        GameStart();
    }

    public void WinCountDown(int countDown)
    {
        countDownText.gameObject.SetActive(true);
        countDownText.text = countDown.ToString();

        if (countDown == 0)
        {
            LevelWin();
        }
    }
    public void DisableCountDown()
    {
        countDownText.gameObject.SetActive(false);
        countDownText.text = 3.ToString(); ;

    }

    public void LevelWin()
    {
        if (gameFinished)
            return;
        GameEnd();
        winPanel.SetActive(true);
        coinController.MakeMoney();
        audioSource.PlayOneShot(winSound);
        OnGameEnd?.Invoke();
     }
    public void LevelLose()
    {
          if (gameFinished)
            return;
        GameEnd();
         
        Invoke("LevelLoseDelay",0.1f);
    }
    void LevelLoseDelay()
    {
         audioSource.PlayOneShot(LoseSound);
         losePanel.SetActive(true);
        OnGameEnd?.Invoke();

    }
    void GameEnd()
    {
        
        timerText.gameObject.SetActive(false);
        gameFinished = true;
       // Time.timeScale = 0f;
    }
}
