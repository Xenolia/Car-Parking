using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
     GameObject checkPoint;

    public float Timer=300000f; 
    GameController gameController;

     private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        Timer = Timer - 3f;
        
    }
    public float GetTime()
    {
        var diff = PlayerPrefs.GetInt("Difficulty",1);
        if (diff == 1)
        {
            return Timer;
        }
        if (diff == 2)
        {
            return Timer-5;
        }
        if (diff == 3)
        {
            return Timer-10;
        }
        return 0;
    }
    public void CheckPointPassed(GameObject lastCheckPoint)
    {
        checkPoint = lastCheckPoint;
        gameController.CheckPointPassed();
    }

    public GameObject LastCheckPoint()
    {
        return checkPoint;
    }
}
