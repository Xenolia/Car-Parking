using System.Collections;
using System.Collections.Generic;
using NoCodingEasyLocalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cars;
    [SerializeField] GameObject CurrentCar;
    [SerializeField] Text infoText;
     [SerializeField] LocalizeMaster lm = null;

    SystemLanguage selectedLang;

    private void Awake()
    {

         selectedLang = lm.GetSelectedLang();
        Debug.LogError(selectedLang);
        if (selectedLang == SystemLanguage.English)
        {
            infoText.text = "Wait For Passengers";
        }
        if (selectedLang == SystemLanguage.Russian)
        {
            infoText.text = "Ждите пассажиров";
        }
        if (selectedLang == SystemLanguage.German)
        {
            infoText.text = "Warten auf Passagiere";
        }
        if (selectedLang == SystemLanguage.French)
        {
            infoText.text = "Attendre les passagers";
        }
        if (selectedLang == SystemLanguage.Turkish)
        {
            infoText.text = "Yolcuları Bekle";
        }
    }
 
    public void ActivateCar(int index)
    {
        CurrentCar = Cars[index];
        Cars[index].SetActive(true);
    }
    public void ChangeCamera()
    {
        CurrentCar.GetComponent<CameraSwitch>().ChangeCam();
    }
    public void ActivateMove()
    {
        CurrentCar.GetComponent<Rigidbody>().isKinematic = false;

   
        if (selectedLang == SystemLanguage.English)
        {
                infoText.text = "Watch Out For Arrival Time";
            }
        if (selectedLang == SystemLanguage.Russian)
        {
            infoText.text = "Следите за временем прибытия";
        }
        if (selectedLang == SystemLanguage.German)
        {
            infoText.text = "Achten Sie auf die Ankunftszeit";
        }
        if (selectedLang == SystemLanguage.French)
        {
            infoText.text = "Attention à l'heure d'arrivée";
        }
        if (selectedLang == SystemLanguage.Turkish)
        {
            infoText.text = "Varış Zamanına Dikkat Et";
        }

        Invoke("DestroyText", 2f);
    }
    void DestroyText()
    {
        infoText.gameObject.SetActive(false);
    }
}
