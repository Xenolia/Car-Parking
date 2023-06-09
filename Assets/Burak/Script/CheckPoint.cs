using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameController gameController;
    AudioSource audioSource;
    private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
        audioSource = GetComponent<AudioSource>();
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

        audioSource.Play();
        Debug.Log("Checkpoint");
        gameObject.SetActive(false);
        GetComponentInParent<Level>().CheckPointPassed(gameObject);
    }
}
