using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdHelper : MonoBehaviour
{
    [SerializeField] bool preRoll;
    AdManager adManager;
    private void Awake()
    {
        adManager = GetComponent<AdManager>();
        adManager.Init();

        adManager.InterstatialAdManager.LoadAds();
    }
    private void Start()
    {
        if (preRoll)
            ShowIntersitial();
    }
    public void ShowIntersitial()
    {
        if(adManager.InterstatialAdManager.IsInterstatialAdReady())
        adManager.InterstatialAdManager.ShowAd();
    }
}
