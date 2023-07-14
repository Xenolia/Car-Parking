using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
#if YANDEX_GAMES
public class YandexRewardedAdManager : IRewardedAdManager
{
 
    private Action<IronSourceAdInfo> OnAdClosedEvent;
    private Action<IronSourceAdInfo> OnAdOpenedEvent;
    private Action<IronSourcePlacement, IronSourceAdInfo> OnRewardEarnedEvent;
    private Action<IronSourceError> OnAdFailedEvent;

    public YandexRewardedAdManager()
    {
      //  _yandexSDK = YandexSDK.instance;
    }
    public bool IsRewardedAdReady()
    {
        return true;
    }

    public void LoadAds()
    {
      
    }

    public void RegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
      
    }

    public void RegisterIronSourceEvents()
    {
        YandexGame.CloseVideoEvent += OnAdClosed;
        YandexGame.OpenVideoEvent += OnAdOpened;
        YandexGame.RewardVideoEvent += OnRewardEarned;
        YandexGame.ErrorVideoEvent += OnAdFailed;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
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

    public void RegisterOnAdUnavailableEvent(Action method)
    {
       
    }

    public void RegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        OnRewardEarnedEvent += method;
    }

    public void ShowAd()
    {
        YandexGame.Instance._RewardedShow(1);
    }

    public void TerminateAd()
    {
        YandexGame.CloseVideoEvent -= OnAdClosed;
        YandexGame.OpenVideoEvent -= OnAdOpened;
        YandexGame.RewardVideoEvent -= OnRewardEarned;
        YandexGame.ErrorVideoEvent -= OnAdFailed;
    }

    public void UnRegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
       
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
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

    public void UnRegisterOnAdUnavailableEvent(Action method)
    {
    
    }

    public void UnRegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        OnRewardEarnedEvent -= method;
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

    private void OnRewardEarned(int a)
    {
        OnRewardEarnedEvent?.Invoke(null, null);
    }

    private void OnAdFailed()
    {
        OnAdFailedEvent?.Invoke(null);
    }
}

#endif