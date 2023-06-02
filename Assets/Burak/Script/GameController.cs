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

#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern bool IsMobileBrowser();
#endif

    private void Awake()
    {
        levelController = GetComponent<LevelController>();

#if UNITY_WEBGL && !UNITY_EDITOR
        useMobileControls = IsMobileBrowser();
       
#endif

        SetMobileButtons(useMobileControls);
        GameStart();
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
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
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
    }
    public void LevelLose()
    {
        Debug.Log("111");
         if (gameFinished)
            return;
        GameEnd();

 
        Invoke("LevelLoseDelay",1f);
    }
    void LevelLoseDelay()
    {
        losePanel.SetActive(true);
        OnGameEnd?.Invoke();

    }
    void GameEnd()
    {
         gameFinished = true;
       // Time.timeScale = 0f;
    }
}
