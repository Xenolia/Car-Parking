using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeRewardedAdManager : IRewardedAdManager
{
    private RewardedAdRegisterator _rewardedAdRegisterator;
    private float _lastTimeScale = 1f;
    public FakeRewardedAdManager()
    {
        _rewardedAdRegisterator = new RewardedAdRegisterator();

        RegisterOnAdOpenedEvent(OnAdOpened);
        RegisterOnAdClosedEvent(OnAdClosed);
    }
    public bool IsRewardedAdReady()
    {
        return IronSource.Agent.isRewardedVideoAvailable();
    }

    public void LoadAds()
    {
        IronSource.Agent.loadRewardedVideo();
    }

    public void RegisterIronSourceEvents()
    {
        FakeRewardedEvents.OnRewardedAdAvailableEvent += _rewardedAdRegisterator.FireOnAdAvailableEvent;
        FakeRewardedEvents.OnRewardedAdClickedEvent += _rewardedAdRegisterator.FireOnAdClickedEvent;
        FakeRewardedEvents.OnRewardedAdClosedEvent += _rewardedAdRegisterator.FireOnAdClosedEvent;
        FakeRewardedEvents.OnRewardedAdUnavailable += _rewardedAdRegisterator.FireOnAdUnavailable;
        FakeRewardedEvents.OnAdRewardedUserEvent += _rewardedAdRegisterator.FireOnAdRewardedEvent; // _rewardAdRegisterator.FireoNAdRewarded;
        FakeRewardedEvents.OnRewardedAdReadyEvent += _rewardedAdRegisterator.FireOnAdReadyEvent;
        FakeRewardedEvents.OnRewardedAdLoadFailedEvent += _rewardedAdRegisterator.FireOnAdLoadFailedEvent;
        FakeRewardedEvents.ORewardednAdOpenedEvent += _rewardedAdRegisterator.FireOnAdOpenedEvent;
        FakeRewardedEvents.OnRewardedAdShowFailedEvent += _rewardedAdRegisterator.FireOnAdShowFailedEvent;
    }

    private void UnRegisterIronSourceEvents()
    {
        FakeRewardedEvents.OnRewardedAdAvailableEvent -= _rewardedAdRegisterator.FireOnAdAvailableEvent;
        FakeRewardedEvents.OnRewardedAdClickedEvent -= _rewardedAdRegisterator.FireOnAdClickedEvent;
        FakeRewardedEvents.OnRewardedAdClosedEvent -= _rewardedAdRegisterator.FireOnAdClosedEvent;
        FakeRewardedEvents.OnRewardedAdUnavailable -= _rewardedAdRegisterator.FireOnAdUnavailable;
        FakeRewardedEvents.OnAdRewardedUserEvent -= _rewardedAdRegisterator.FireOnAdRewardedEvent; // _rewardAdRegisterator.FireoNAdRewarded;
        FakeRewardedEvents.OnRewardedAdReadyEvent -= _rewardedAdRegisterator.FireOnAdReadyEvent;
        FakeRewardedEvents.OnRewardedAdLoadFailedEvent -= _rewardedAdRegisterator.FireOnAdLoadFailedEvent;
        FakeRewardedEvents.ORewardednAdOpenedEvent -= _rewardedAdRegisterator.FireOnAdOpenedEvent;
        FakeRewardedEvents.OnRewardedAdShowFailedEvent -= _rewardedAdRegisterator.FireOnAdShowFailedEvent;

    }

    public void RegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdAvailableEvent += method;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClickedEvent += method;
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClosedEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _rewardedAdRegisterator.OnAdLoadFailedEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdOpenedEvent += method;
    }

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdReadyEvent += method;
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdShowFailedEvent += method;
    }

    public void RegisterOnAdUnavailableEvent(Action method)
    {
        _rewardedAdRegisterator.OnAdUnavailable += method;
    }

    public void RegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdRewardedEvent += method;
    }

    public void ShowAd()
    {
        IronSource.Agent.showRewardedVideo();
    }

    public void TerminateAd()
    {
        UnRegisterIronSourceEvents();
    }

    

    public void UnRegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClickedEvent -= method;
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClosedEvent -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _rewardedAdRegisterator.OnAdLoadFailedEvent -= method;
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdOpenedEvent -= method;
    }

    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdReadyEvent -= method;
    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdShowFailedEvent -= method;
    }

    public void UnRegisterOnAdUnavailableEvent(Action method)
    {
        _rewardedAdRegisterator.OnAdUnavailable -= method;
    }

    public void UnRegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdRewardedEvent -= method;
    }

    public void UnRegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdAvailableEvent -= method;
    }

    private void OnAdClosed(IronSourceAdInfo info)
    {
        LoadAds();
        Debug.LogError("OnAdClosed");
        Time.timeScale = _lastTimeScale;
        AudioListener.volume = 1f;
    }

    private void OnAdOpened(IronSourceAdInfo info)
    {
        _lastTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }
}
