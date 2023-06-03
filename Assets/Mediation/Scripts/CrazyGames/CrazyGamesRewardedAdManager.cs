 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if CRAZY_GSDK
using CrazyGames;
//using static CrazyGames.CrazySDK;


public class CrazyGamesRewardedAdManager : IRewardedAdManager
{
    private CrazyAds _adInstance;
    private CrazySDK _sdkInstance;

    public Action<IronSourceError> OnRewardedAdLoadFailedEvent;
    public Action<IronSourceAdInfo> OnRewardedAdReadyEvent;
    public Action OnRewardedAdUnavailable;
    public Action<IronSourceAdInfo> OnRewardedAdAvailableEvent;
    public Action<IronSourceAdInfo> ORewardednAdOpenedEvent;
    public Action<IronSourceAdInfo> OnRewardedAdClosedEvent;
    public Action<IronSourceError, IronSourceAdInfo> OnRewardedAdShowFailedEvent;
    public Action<IronSourcePlacement, IronSourceAdInfo> OnRewardedAdClickedEvent;
    public Action<IronSourcePlacement, IronSourceAdInfo> OnAdRewardedUserEvent;

    public CrazyGamesRewardedAdManager()
    {
        _adInstance = CrazyAds.Instance;
        _sdkInstance = CrazySDK.Instance;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        OnRewardedAdLoadFailedEvent += method;
    }

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdReadyEvent += method;
    }

    public void RegisterOnAdUnavailableEvent(Action method)
    {
        OnRewardedAdUnavailable += method;
    }

    public void RegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdAvailableEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        ORewardednAdOpenedEvent += method;
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdClosedEvent += method;
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        OnRewardedAdShowFailedEvent += method;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        OnRewardedAdClickedEvent += method;
    }

    public void RegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        OnAdRewardedUserEvent += method;
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        OnRewardedAdClickedEvent -= method;
    }

    public void UnRegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
       OnAdRewardedUserEvent -= method;
    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        OnRewardedAdShowFailedEvent -= method;
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        ORewardednAdOpenedEvent -= method;
    }

    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdReadyEvent -= method;
    }

    public void UnRegisterOnAdUnavailableEvent(Action method)
    {
        OnRewardedAdUnavailable -= method;
    }

    public void UnRegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdAvailableEvent -= method;
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdClosedEvent -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        OnRewardedAdLoadFailedEvent -= method;
    }

    public void TerminateAd()
    {
        UnRegisterEvents();
    }

    public bool IsRewardedAdReady()
    {
        return true;
    }

    public void ShowAd()
    {
        _adInstance.beginAdBreakRewarded();
    }

    public void LoadAds()
    {
       
    }

    public void RegisterIronSourceEvents()
    {
        _adInstance.OnAdComplated += OnUserEernedReward;
        _adInstance.OnAdClosed += OnAdClosed;
        _adInstance.OnAdOpened += OnAdOpened;
    }

    private void UnRegisterEvents()
    {
        _adInstance.OnAdComplated -= OnUserEernedReward;
        _adInstance.OnAdClosed -= OnAdClosed;
        _adInstance.OnAdOpened -= OnAdOpened;
    }

    private void OnAdOpened()
    {
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
        Debug.Log("OnRewardedAdOpened");
        ORewardednAdOpenedEvent?.Invoke(null);
    }

    private void OnAdClosed()
    {
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
        Debug.Log("OnRewardedAdClosed");
        OnRewardedAdClosedEvent?.Invoke(null);
    }

    private void OnUserEernedReward()
    {
        Debug.Log("On User Earned Reward");
        OnAdRewardedUserEvent?.Invoke(null, null);
    }

    private void OnAdError()
    {
        Debug.Log("OnAdError");
    }
}
#endif