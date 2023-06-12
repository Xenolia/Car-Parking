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
    GameObject activeLevel;
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
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            NextLevel();
        }
    }
   public int levelIndex;
    void ActivateLevel()
    {

        Leveltext.text = "LEVEL  " + Level.ToString();

       levelIndex = Level % (levels.Length+1);

       
        if (Level <= levels.Length)
        {
         var go=   Instantiate(levels[levelIndex - 1]);
            go.transform.parent = transform;
            go.SetActive(true);
           //  levels[levelIndex - 1].SetActive(true);
            activeLevel = go;


        }

        else
        {
            var go = Instantiate(levels[levelIndex]);
            go.transform.parent = transform;

            go.SetActive(true);
            activeLevel = go;

        }
     }
    public GameObject GetActiveLevel()
    {
        return activeLevel;
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
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);

    }

}
