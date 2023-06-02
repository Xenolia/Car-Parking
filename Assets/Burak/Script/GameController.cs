using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    using System.Runtime.InteropServices;

public class GameController : MonoBehaviour
{

    [SerializeField] bool useMobileControls=false;
    [SerializeField] PrometeoCarController carController;
    [SerializeField] GameObject[] mobileButtons;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] Text countDownText;
     bool gameFinished = false;

    LevelController levelController;


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
   public void Revive()
    {
        losePanel.SetActive(false);
        gameFinished = false;

        GameObject checkPoint = FindObjectOfType<Level>().LastCheckPoint();
        if(checkPoint!=null)
        {
            carController.transform.position = checkPoint.transform.position;
        }
        else
        {
            carController.transform.position = Vector3.zero;
        }
      
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


    public void LevelWin()
    {
        if (gameFinished)
            return;
        GameEnd();
        winPanel.SetActive(true);
    }
    public void LevelLose()
    {
        if (gameFinished)
            return;
        GameEnd();
        losePanel.SetActive(true);
    }
    void GameEnd()
    {
        carController.GameEnd();
        gameFinished = true;

        Time.timeScale = 0f;
    }
}
