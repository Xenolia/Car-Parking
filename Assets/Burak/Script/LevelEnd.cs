using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    float countdown=4f;
    PrometeoCarController CarController;
    GameController gameController;

    GameObject rotationWarningText;
    [SerializeField] float targetAngleY;
    [SerializeField] bool doNotCheckRotation=false;
   MeshRenderer changeMaterial;
     
    bool gameEnd;
    Color oldColor;
    
     private void Awake()
    {
        gameController = FindObjectOfType<GameController>();

       ParkingArea area= FindObjectOfType<ParkingArea>();
        changeMaterial = area.ChangeMaterial1().GetComponent<MeshRenderer>();
        //changeMaterial2 = area.ChangeMaterial2().GetComponent<MeshRenderer>();

        oldColor = changeMaterial.sharedMaterial.color;
        //oldColor2 = changeMaterial2.sharedMaterial.color;

        rotationWarningText = GameObject.FindGameObjectWithTag("WarningText");
        rotationWarningText.SetActive(false);
    }
    private void OnEnable()
    {
        gameController.OnGameEnd += GameEnd;

        gameController.OnRevive += Revive;

    }
    private void OnDisable()
    {
        changeMaterial.sharedMaterial.color = oldColor;
       
        gameController.OnGameEnd -= GameEnd;
        gameController.OnRevive -= Revive;


    }
    void GameEnd()
    {
        gameEnd = true;
    }
    void Revive()
    {
        gameEnd = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameEnd)
        {
            ResetTimer();
            return;

        }
        if (other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
            if (gameEnd)
            {
                ResetTimer();
                return;

            }
            CarController = other.gameObject.GetComponentInParent<PrometeoCarController>();
           // if(CarController.transform.rotation)
             CountDown();
        }
    }
    float temp;
     void CountDown()
    {


        if (gameEnd)
        {
            ResetTimer();
            return;

        }

        float absoluteCarSpeed = Mathf.Abs(CarController.carSpeed);
        if(!doNotCheckRotation)
        {
              temp = targetAngleY;

            float carRotationY = CarController.transform.rotation.eulerAngles.y;

            float difference = Mathf.DeltaAngle(carRotationY, targetAngleY);

            difference= Mathf.Abs(difference);

            if (difference > 2 )
            {
                ResetTimer();
             rotationWarningText.SetActive(true);
                return;
            }

        }
        if (Mathf.RoundToInt(absoluteCarSpeed) != 0)
        {
            countdown = 4f;
            ResetTimer();
             return;

        }
      
        
             changeMaterial.sharedMaterial.color = Color.green;
        
        StopTimer();


        countdown = countdown - (Time.deltaTime);
            UpdateText();
 
       
    }
    void StopTimer()
    {
        gameController.StopTimer(true);
    }
    void ResumeTimer()
    {
        gameController.StopTimer(false);
     }
    void ResetTimer()
    {
        gameController.DisableCountDown();
        changeMaterial.sharedMaterial.color =oldColor;
        
        ResumeTimer();
        rotationWarningText.SetActive(false);

    }
    private void OnTriggerExit(Collider other)
    {
        countdown = 4f;
        changeMaterial.sharedMaterial.color = oldColor;
        
        ResumeTimer();

        rotationWarningText.SetActive(false);


    }

    void UpdateText()
    {
        rotationWarningText.SetActive(false);
        if (countdown<0)
        {
            return;

        }

        gameController.WinCountDown((int)countdown);
    }
}
