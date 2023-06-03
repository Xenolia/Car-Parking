 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#if CRAZY_GSDK
using CrazyGames;
//using static CrazyGames.CrazySDK;

public class CrazyGamesInterstitialAdManager : IInterstatialAdManager
{
    private CrazyAds _adInstance;
    private CrazySDK _sdkInstance;

    public Action<IronSourceAdInfo> OnInterstatialAdOpened;
    public Action<IronSourceAdInfo> OnInterstatialAdClosed;
    public Action<IronSourceError> OnInterstatialAdFailedToLoad;
    public Action<IronSourceError, IronSourceAdInfo> OnInterstatialAdShownFailed;
    public Action<IronSourceAdInfo> OnInterstatialAdSuccesed;
    public Action<IronSourceAdInfo> OnInterstailAdReady;
    public Action<IronSourceAdInfo> OnInterstatialAdClicked;

    private bool _canShowAd = true;

    public CrazyGamesInterstitialAdManager()
    {
        _adInstance = CrazyAds.Instance;
        _sdkInstance = CrazySDK.Instance;

        _sdkInstance.GameplayStart();

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
        _adInstance.OnAdClosed += OnAdClosed;
        _adInstance.OnAdOpened += OnAdOpened;
    }

    private void UnRegisterEvents()
    {
        _adInstance.OnAdClosed -= OnAdClosed;
        _adInstance.OnAdOpened -= OnAdOpened;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdClicked += method;
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdClosed += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        OnInterstatialAdFailedToLoad += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdOpened += method;
    }

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstailAdReady += method;
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        OnInterstatialAdShownFailed += method;  
    }

    public void RegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdSuccesed += method;
    }

    public void ShowAd()
    {
        _adInstance.beginAdBreak();
    }

    public void TerminateAd()
    {
        UnRegisterEvents();
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdClicked -= method;
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdClosed -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        OnInterstatialAdFailedToLoad -= method;
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdOpened -= method;
    }

    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstailAdReady -= method;
    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        OnInterstatialAdShownFailed -= method;
    }

    public void UnRegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdSuccesed -= method;
    }

    private void OnAdOpened()
    {
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
        OnInterstatialAdOpened?.Invoke(null);
    }

    private void OnAdClosed()
    {
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
        OnInterstatialAdClosed?.Invoke(null);
    }
}
#endif