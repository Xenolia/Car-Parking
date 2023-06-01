using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    [SerializeField] bool useMobileControls=false;
    [SerializeField] PrometeoCarController carController;
    [SerializeField] GameObject[] mobileButtons;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;


    LevelController levelController;
    private void Awake()
    {
        levelController = GetComponent<LevelController>();
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

    public void LevelWin()
    {
        winPanel.SetActive(true);
    }
    public void LevelLose()
    {
        losePanel.SetActive(true);
    }
}
