using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PrometeoCarController>()!=null)
        {
            StartCoroutine(LevelLose());
        }
    }

    IEnumerator LevelLose()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<GameController>().LevelLose();

    }
}
