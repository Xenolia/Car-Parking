using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class TrafficController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
     [SerializeField] GameObject carInstantiatePos;
    [SerializeField] GameObject redLight,GreenLight;
    [SerializeField]  float lightDuration=4f;

    CrashController crashController;
    private void Awake()
    {
        crashController = GetComponentInChildren<CrashController>();
    } 
    public void Init()
    {
        StartCoroutine(LightController());

    }
    IEnumerator LightController()
    {
        yield return new WaitForSeconds(0.5f);
        EnableRedLight();
        while (true)
        { 
            yield return new WaitForSeconds(lightDuration);
            EnableGreenLight();
            yield return new WaitForSeconds(lightDuration);
            EnableRedLight();
        }
    }
    void EnableRedLight()
    {
        redLight.SetActive(true);
        GreenLight.SetActive(false);
         StartCoroutine(TrafficRunner());

        crashController.EnableCrash();
    }
    void EnableGreenLight()
    {
        redLight.SetActive(false);
        GreenLight.SetActive(true);
        crashController.DisableCrash();
     }


    IEnumerator TrafficRunner()
    {
        int a = 0;
        while (a<2)
        {
            yield return new WaitForSeconds(lightDuration/2);
            var go = Instantiate(cars[Random.Range(0, cars.Length - 1)], carInstantiatePos.transform.position, Quaternion.Euler(new Vector3(0,90,0)));
            a++;
            go.AddComponent<TrafficCar>().Move(lightDuration);
        } 
    }
    public void Crash()
    {
        Debug.Log("Crahs");
        var go = Instantiate(cars[Random.Range(0, cars.Length - 1)], carInstantiatePos.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
        go.AddComponent<TrafficCar>().Crash();

    }
}
