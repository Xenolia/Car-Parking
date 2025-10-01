using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyGames;

public class AdHelper : MonoBehaviour
{
    [SerializeField] bool preRoll;
    public bool isSdkInitialized = false;   
    //  AdManager adManager;
    private void Awake()
    {
        CrazySDK.Init(() => { isSdkInitialized = true; });

        /*
        adManager = GetComponent<AdManager>();
        adManager.Init();

        adManager.InterstatialAdManager.LoadAds();
        */
    }

    private void Start()
    {
        if (preRoll)
            ShowIntersitial();
    }
    public void ShowIntersitial()
    {
        /*
        if(adManager.InterstatialAdManager.IsInterstatialAdReady())
        adManager.InterstatialAdManager.ShowAd();
        */
    }
}
