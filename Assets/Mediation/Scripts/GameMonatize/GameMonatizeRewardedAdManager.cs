using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if GAME_MONOTIZE
public class GameMonatizeRewardedAdManager : IRewardedAdManager
{
    private Action<IronSourceAdInfo> OnRewardedAdOpened;
    private Action<IronSourceAdInfo> OnRewardedAdClosed;

    private float _lastTimeScale;
    public GameMonatizeRewardedAdManager()
    {

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
        GameMonetize.OnResumeGame += OnAdClosed;
        GameMonetize.OnPauseGame += OnAdOpened;
    }
    private void UnRegisterIronSourceEvents()
    {
        GameMonetize.OnResumeGame -= OnAdClosed;
        GameMonetize.OnPauseGame -= OnAdOpened;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
       
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdClosed+= method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
       
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdOpened += method;
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
        
    }

    public void ShowAd()
    {

    }

    public void TerminateAd()
    {
        UnRegisterIronSourceEvents();
    }

    public void UnRegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
  
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdClosed -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {

    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdOpened -= method;
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
   
    }

    private void OnAdOpened()
    {
        OnRewardedAdOpened?.Invoke(null);
        AudioListener.volume = 0f;
        Time.timeScale = 0;
    }

    private void OnAdClosed()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        OnRewardedAdClosed?.Invoke(null);
    }
}
#endif