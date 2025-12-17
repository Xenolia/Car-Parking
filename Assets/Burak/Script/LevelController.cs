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
    public Level levelScript;
    GameObject activeLevel;
    public TextMeshProUGUI Leveltext,partUnlockedText;
    [SerializeField] GameObject driftSceneMap;
   public bool isDailyLevel = false;
    private void Awake()
    {
  

        gameController = GetComponent<GameController>();

         // Daily Level Logic
        if (PlayerPrefs.GetInt("IsDailyLevel", 0) == 1)
        {
            // Use current date as seed
            int seed = System.DateTime.Now.Date.GetHashCode();
            Debug.Log($"Daily Seed: {seed}, Date: {System.DateTime.Now.Date}");
            
            System.Random dailyRandom = new System.Random(seed);
            
            Debug.Log($"Total Levels Available: {levels.Length}");

            // Select random level from available levels
            // Level is 1-based index for display, and logic below uses it for index calc
            int minLevel = 19;
            if (levels.Length < minLevel)
            {
                minLevel = 10; 
                Debug.LogWarning($"Total levels ({levels.Length}) is less than 17. Defaulting daily map start to 1.");
            }
            Level = dailyRandom.Next(minLevel, levels.Length + 1);
            Debug.Log($"Daily Level Selected: {Level}");
            isDailyLevel = true;
            Leveltext.text = "DAILY MAP";
            // Override the standard level text set in ActivateLevel, or handle it there
            playSpecificLevel = true; // reusing this flag or just letting ActivateLevel handle it might be safer, 
                                      // but ActivateLevel sets text too. Let's adjust ActivateLevel logic implicitly by setting Level.
        }


        if (playSpecificLevel)
        {
            ActivateLevel();
            return;
        }
      if (PlayerPrefs.HasKey("CPLevel"))
        {
            Level = PlayerPrefs.GetInt("CPLevel", 1);
        }
        else
            Level = 1;

       
        ActivateLevel();
    }
    public int levelIndex;
    public void DriftSceneSettings()
    {
        GameObject ads = activeLevel;
        Destroy(ads);
        Instantiate(driftSceneMap);
    }
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
    levelScript=activeLevel.GetComponent<Level>();
     }
    public GameObject GetActiveLevel()
    {
        return activeLevel;
    }
    public void NextLevelPrefSet()
    {
        if(PartUnlockManager.instance!=null)
    {
 if(levelScript.partUnlocked == 1) 
       {
    PartUnlockManager.instance.UnlockPart(0); // Unlocks Part 1 (Index 0)
    partUnlockedText.gameObject.SetActive(true);
partUnlockedText.text = "Part 1 Unlocked!!";
       }
if(levelScript.partUnlocked == 2) 
{
    PartUnlockManager.instance.UnlockPart(1); // Unlocks Part 2 (Index 1)
partUnlockedText.gameObject.SetActive(true);
partUnlockedText.text = "Part 2 Unlocked!!";
}
if(levelScript.partUnlocked == 3) 
{
    PartUnlockManager.instance.UnlockPart(2); // Unlocks Part 3 (Index 2)
partUnlockedText.gameObject.SetActive(true);
partUnlockedText.text = "Part 3 Unlocked!!";
}
    }
      
    
        if (PlayerPrefs.GetInt("IsDailyLevel", 0) == 1)
        {
        PlayerPrefs.SetInt("IsDailyLevel", 2);
            return;
        }
    
        PlayerPrefs.SetInt("CPLevel", Level + 1);
  
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Game"); // Yüklenecek sahnenin adı

    }
    public void Restart()
    {
        SceneManager.LoadScene("Game"); // Yüklenecek sahnenin adı
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); // Yüklenecek sahnenin adı
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            NextLevelPrefSet();
            NextLevel();
        }
    }
#endif

}
