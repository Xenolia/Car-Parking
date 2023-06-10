using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
     GameObject checkPoint;

    public float Timer=300000f;
    public float TimerMedium = 300000f;
    public float TimerHard = 300000f;
    GameController gameController;
    private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
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
            return TimerMedium;
        }
        if (diff == 3)
        {
            return TimerHard;
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
