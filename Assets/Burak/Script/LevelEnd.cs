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
     MeshRenderer changeMaterial2;
    bool gameEnd;
    Color oldColor;
    Color oldColor2;
     private void Awake()
    {
        gameController = GetComponentInParent<GameController>();

       ParkingArea area= FindObjectOfType<ParkingArea>();
        changeMaterial = area.ChangeMaterial1().GetComponent<MeshRenderer>();
        changeMaterial2 = area.ChangeMaterial2().GetComponent<MeshRenderer>();

        oldColor = changeMaterial.sharedMaterial.color;
        oldColor2 = changeMaterial2.sharedMaterial.color;

        rotationWarningText = GameObject.FindGameObjectWithTag("WarningText");
        rotationWarningText.SetActive(false);
    }
    private void OnEnable()
    {
        gameController.OnGameEnd += GameEnd;
    }
    private void OnDisable()
    {
        changeMaterial.sharedMaterial.color = oldColor;
        changeMaterial2.sharedMaterial.color = oldColor2;
        gameController.OnGameEnd -= GameEnd;

    }
    void GameEnd()
    {
        gameEnd = true;
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

            if (difference > 4 )
            {
                
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
        changeMaterial2.sharedMaterial.color = Color.green;

        countdown = countdown - (Time.deltaTime);
            UpdateText();
 
       
    }
    void ResetTimer()
    {
        gameController.DisableCountDown();
        changeMaterial.sharedMaterial.color =oldColor;
        changeMaterial2.sharedMaterial.color = oldColor2;

        rotationWarningText.SetActive(false);

    }
    private void OnTriggerExit(Collider other)
    {
        countdown = 4f;
        changeMaterial.sharedMaterial.color = oldColor;
        changeMaterial2.sharedMaterial.color = oldColor2;

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
