using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    using System.Runtime.InteropServices;
using System;
public class GameController : MonoBehaviour
{

    [SerializeField] bool useMobileControls=false;
    [SerializeField] PrometeoCarController carController;
    [SerializeField] GameObject[] mobileButtons;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] Text countDownText;
   public  bool gameFinished = false;

    LevelController levelController;

    public Action<Vector3> OnRevive;
    public Action OnGameEnd;

    CoinController coinController;
    CarManager carManager;

    AudioSource audioSource;
    [SerializeField] Text timerText;
    float targetTime;
   [SerializeField] AdManager adManager;
    int carIndex;
 #if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern bool IsMobileBrowser();
#endif

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.LogError("do sounds win lose ");
        carManager = FindObjectOfType<CarManager>();
        EnableCar();
        coinController = GetComponent<CoinController>();
        levelController = GetComponent<LevelController>();
#if UNITY_WEBGL && !UNITY_EDITOR
        useMobileControls = IsMobileBrowser();
       
#endif

        GameStart();


       
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
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            ChangeCameraAngle();
        }
        UpdateTimer();
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
            carController.transform.position = checkPoint.transform.position;
            OnRevive?.Invoke(checkPoint.transform.position);
        }
        else
        {
            carController.transform.position = Vector3.zero;
            OnRevive?.Invoke(Vector3.zero);
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
