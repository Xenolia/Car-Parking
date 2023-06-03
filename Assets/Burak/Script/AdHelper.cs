using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdHelper : MonoBehaviour
{
    AdManager adManager;
    private void Awake()
    {
        adManager = GetComponent<AdManager>();
        adManager.Init();

        adManager.InterstatialAdManager.LoadAds();
    }
    public void ShowIntersitial()
    {
        if(adManager.InterstatialAdManager.IsInterstatialAdReady())
        adManager.InterstatialAdManager.ShowAd();
    }
}
