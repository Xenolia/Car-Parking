using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameController gameController;
    private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PrometeoCarController>() != null)
        {
            CheckPointPassed();
        }
    }

    void CheckPointPassed()
    {
        if (gameController.gameFinished)
            return;

        Debug.Log("Checkpoint");
        gameObject.SetActive(false);
        GetComponentInParent<Level>().CheckPointPassed(gameObject);
    }
}
