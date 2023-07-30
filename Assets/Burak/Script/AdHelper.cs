using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
 public class AdHelper : MonoBehaviour
{
     [SerializeField] bool preRoll;
   [SerializeField] AdManager adManager;
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
        /*
        YG.YandexGame.FullscreenShow();
        return;
        */
        if (adManager.InterstatialAdManager.IsInterstatialAdReady())
        {
            adManager.InterstatialAdManager.ShowAd();
            Time.timeScale = 0f;
        }
       
    }
}
