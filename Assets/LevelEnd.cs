using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    float countdown=3f;
    GameController gameController;
    private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }
    private void OnTriggerStay(Collider other)
    {
       if(other.gameObject.GetComponent<PrometeoCarController>()!=null)
        {

            countdown = countdown-(Time.deltaTime/2);
            UpdateText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        countdown = 3f;
    }

    void UpdateText()
    {
        gameController.WinCountDown((int)countdown);
    }
}
