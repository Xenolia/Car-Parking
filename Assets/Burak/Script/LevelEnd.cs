using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    float countdown=4f;
    PrometeoCarController CarController;
    GameController gameController;

     private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }
    private void OnTriggerStay(Collider other)
    {
       
       if(other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
           
            CarController = other.gameObject.GetComponentInParent<PrometeoCarController>();
           // if(CarController.transform.rotation)
            Debug.Log("Count down");
            CountDown();
        }
    }
    void CountDown()
    {
        float absoluteCarSpeed = Mathf.Abs(CarController.carSpeed);
         if ( Mathf.RoundToInt(absoluteCarSpeed)!=0)
        {
            countdown = 4f;
            ResetTimer();
            Debug.Log("Reset timer");
            return;

        }
            
        

         countdown = countdown - (Time.deltaTime);
        UpdateText();
    }
    void ResetTimer()
    {
        gameController.DisableCountDown();

    }
    private void OnTriggerExit(Collider other)
    {
        countdown = 4f;
    }

    void UpdateText()
    {
        if(countdown<0)
        {
            return;

        }

        gameController.WinCountDown((int)countdown);
    }
}
