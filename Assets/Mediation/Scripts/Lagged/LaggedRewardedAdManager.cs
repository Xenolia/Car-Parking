using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if LAGGED
public class LaggedRewardedAdManager : IRewardedAdManager
{
    private LaggedAPIUnity _laggedAPI;
    private bool _isRewardedAdReady;

    private Action<IronSourcePlacement, IronSourceAdInfo> OnRewardEarnedEvent;
    private Action<IronSourceAdInfo> OnAdOpenedEvent;
    private Action<IronSourceAdInfo> OnAdClosedEvent;
    private Action<IronSourceError> OnRewardedAddFailedEvent;
    private Action<IronSourceAdInfo> OnRewardSuccessEvent;
    private Action<IronSourceAdInfo> OnRewardedAdReadyEvent;
    public LaggedRewardedAdManager()
    {
        _laggedAPI = LaggedAPIUnity.Instance;
    }

    public bool IsRewardedAdReady()
    {
        return _isRewardedAdReady;
    }

    public void LoadAds()
    {
        if(_laggedAPI == null)
        {
            Debug.Log("Lagged API is null");
        }

        float x = 0;

        DOTween.To(() => x = 0, newValue => x = newValue, 1f, 2f).OnComplete(Execute);

        void Execute()
        {
            _laggedAPI.CheckRewardAd();
        }
    }

    public void RegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
     
    }

    public void RegisterIronSourceEvents()
    {
        Debug.Log("Registering events for rewarded ad");

        LaggedAPIUnity.OnPauseGame += OnAdOpen;
        LaggedAPIUnity.OnResumeGame += OnAdClosed;
        LaggedAPIUnity.onRewardAdSuccess += OnRewardEarned;
        LaggedAPIUnity.onRewardAdReady += OnRewarededAdReady;
        LaggedAPIUnity.onRewardAdFailure += OnRewardedAdFailure;
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
        OnRewardedAddFailedEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdOpenedEvent += method;
    }

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdReadyEvent += method;
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
        Debug.Log("Rewarded ad is showing");
        _laggedAPI.PlayRewardAd();
    }

    public void TerminateAd()
    {
        LaggedAPIUnity.OnPauseGame -= OnAdOpen;
        LaggedAPIUnity.OnResumeGame -= OnAdClosed;
        LaggedAPIUnity.onRewardAdSuccess -= OnRewardEarned;
        LaggedAPIUnity.onRewardAdReady -= OnRewarededAdReady;
        LaggedAPIUnity.onRewardAdFailure -= OnRewardedAdFailure;
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
        OnRewardedAddFailedEvent -= method;
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdOpenedEvent -= method;
    }

    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        OnRewardedAdReadyEvent -= method;
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

    private void OnAdOpen()
    {
        Debug.Log("Rewarded ad is opened");
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        OnAdOpenedEvent?.Invoke(null);
    }

    private void OnAdClosed()
    {
        Debug.Log("Rewarded ad is closed");
        OnAdClosedEvent?.Invoke(null);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }

    private void OnRewardEarned()
    {
        Debug.Log("Rewarded ad is earned");
        OnRewardEarnedEvent?.Invoke(null, null);
    }

    private void OnRewarededAdReady()
    {
        _isRewardedAdReady = true; 
        Debug.Log("Rewarded ad is ready : " +_isRewardedAdReady);
        OnRewardedAdReadyEvent?.Invoke(null);
    }

    private void OnRewardedAdFailure()
    {
        Debug.Log("Rewarded ad is failed");
        OnRewardedAddFailedEvent?.Invoke(null);
    }
}
#endif