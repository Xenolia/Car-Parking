using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
#if YANDEX_GAMES
public class YandexInterstatialAdManager : IInterstatialAdManager
{

    private Action<IronSourceAdInfo> OnAdOpenedEvent;
    private Action<IronSourceAdInfo> OnAdClosedEvent;
    private Action<IronSourceError> OnAdFailedEvent;

    public YandexInterstatialAdManager()
    {
      //  _yandexSDK = YandexSDK.instance;
    }

    public bool IsInterstatialAdReady()
    {
        return true;
    }

    public void LoadAds()
    {
      
    }

    public void RegisterIronSourceInterstatialEvents()
    {
         YandexGame.CloseFullAdEvent += OnAdClosed;
        YandexGame.OpenFullAdEvent += OnAdOpened;
        YandexGame.ErrorFullAdEvent += OnAdFailed;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
       
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdClosedEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        OnAdFailedEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdOpenedEvent += method;
    }

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
    
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
 
    }

    public void RegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
       
    }

    public void ShowAd()
    {
        YandexGame.Instance._FullscreenShow();
     }

    public void TerminateAd()
    {
        YandexGame.CloseFullAdEvent -= OnAdClosed;
        YandexGame.OpenFullAdEvent -= OnAdOpened;
        YandexGame.ErrorFullAdEvent -= OnAdFailed;
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
         
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdClosedEvent -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        OnAdFailedEvent -= method;
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdOpenedEvent -= method;
    }

    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
     
    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
      
    }

    public void UnRegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
        
    }

    private void OnAdOpened()
    {
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
        OnAdOpenedEvent?.Invoke(null);
    }

    private void OnAdClosed()
    {
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
        OnAdClosedEvent?.Invoke(null);
    }

    private void OnAdFailed()
    {
        OnAdFailedEvent?.Invoke(null);
    }
}
#endif