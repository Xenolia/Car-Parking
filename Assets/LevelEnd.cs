using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    float countdown=4f;
    GameController gameController;
    private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }
    private void OnTriggerStay(Collider other)
    {
       if(other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
            Debug.Log("Count down");
            countdown = countdown-(Time.deltaTime/2);
            UpdateText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        countdown = 4f;
    }

    void UpdateText()
    {
        gameController.WinCountDown((int)countdown);
    }
}
