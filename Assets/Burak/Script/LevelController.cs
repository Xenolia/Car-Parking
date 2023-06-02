using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    GameController gameController;
    [SerializeField] GameObject[] levels;
    [SerializeField] bool playSpecificLevel = false;
    public int Level;

    public TextMeshProUGUI Leveltext;
    private void Awake()
    {
        gameController = GetComponent<GameController>();
        if (playSpecificLevel)
        {
            ActivateLevel();
            return;
        }
           

        if (PlayerPrefs.HasKey("Level"))
        {
            Level = PlayerPrefs.GetInt("Level", 1);
        }
        else
            Level = 1;

        ActivateLevel();
    }

    void ActivateLevel()
    {

        Leveltext.text = "LEVEL  " + Level.ToString() ;
        levels[Level - 1].SetActive(true);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level",Level+1);
        SceneManager.LoadScene(1);

    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
   
}
