using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class AdHelper : MonoBehaviour
{
    [SerializeField] bool preRoll;
    AdManager adManager;
    private void Awake()
    {
        adManager = FindObjectOfType<AdManager>();
        adManager.Init();

        // adManager.InterstatialAdManager.LoadAds();
    }
    private void Start()
    {

        if (preRoll)
            ShowIntersitial();
    }
    public void ShowIntersitial()
    { 

        if (adManager.InterstatialAdManager.IsInterstatialAdReady())
            adManager.InterstatialAdManager.ShowAd();
    }
}
