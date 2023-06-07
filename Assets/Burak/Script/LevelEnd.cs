using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    float countdown=4f;
    PrometeoCarController CarController;
    GameController gameController;

    [SerializeField] GameObject rotationWarningText;
    [SerializeField] float targetAngleY;

    [SerializeField] MeshRenderer changeMaterial;
    Color oldColor;
     private void Awake()
    {
        gameController = GetComponentInParent<GameController>();
        oldColor = changeMaterial.sharedMaterial.color;
       rotationWarningText = GameObject.FindGameObjectWithTag("WarningText");
        rotationWarningText.SetActive(false);
    }
    private void OnDisable()
    {
        changeMaterial.sharedMaterial.color = oldColor;
    }
    private void OnTriggerStay(Collider other)
    {
       
       if(other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
           
            CarController = other.gameObject.GetComponentInParent<PrometeoCarController>();
           // if(CarController.transform.rotation)
             CountDown();
        }
    }
    void CountDown()
    {

         float absoluteCarSpeed = Mathf.Abs(CarController.carSpeed);

        if (Mathf.RoundToInt(absoluteCarSpeed) != 0)
        {
            countdown = 4f;
            ResetTimer();
             return;

        }

        if (Mathf.Abs(CarController.transform.rotation.eulerAngles.y - targetAngleY) > 15)
        {
           rotationWarningText.SetActive(true);
             return;
        }
        else if(Mathf.RoundToInt(absoluteCarSpeed)== 0)
        {
             rotationWarningText.SetActive(false);
            changeMaterial.sharedMaterial.color = Color.green;

            countdown = countdown - (Time.deltaTime);
            UpdateText();
        }

       
    }
    void ResetTimer()
    {
        gameController.DisableCountDown();
    }
    private void OnTriggerExit(Collider other)
    {
        countdown = 4f;
        changeMaterial.sharedMaterial.color = oldColor;

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
