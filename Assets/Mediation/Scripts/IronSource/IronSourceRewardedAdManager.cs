using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IronSourceRewardedAdManager : IRewardedAdManager
{
    private float _reLoadDuration = 5f;
    private RewardedAdRegisterator _rewardedAdRegisterator;
    private AudioListener _audioListener;
    private float _lastTimeScale;
    public IronSourceRewardedAdManager()
    {
        _rewardedAdRegisterator = new RewardedAdRegisterator();
        //LoadRewardedVideo();
        //RegisterIronSourceEvents();
        RegisterOnAdLoadFailedEvent(OnRewardedAdLoadFailed);
        //RegisterOnAdUnavailableEvent(Unavailable);
        RegisterOnAdClosedEvent(OnAdClosed);
        RegisterOnAdOpenedEvent(OnAdOpened);
        //RegisterOnUserEarnedRewarededEvent(OnUserEarnedReward);

        //_audioListener = Camera.main.GetComponent<AudioListener>();
    }

    public bool IsRewardedAdReady()
    {
        return IronSource.Agent.isRewardedVideoAvailable();
    }

    public void ShowAd()
    {
        IronSource.Agent.showRewardedVideo();
    }

    private void OnRewardedAdLoadFailed(IronSourceError error)
    {
        Debug.LogError("Rewarded Error : " +error.ToString());

        float value = 0;

        DOTween.To(()=>  value, newValue => value = newValue, 1f, _reLoadDuration).OnComplete(Restart);

        void Restart()
        {
            LoadAds();
        }
    }

    private void Unavailable()
    {
        Debug.Log("Rewarded ad manager, method name Unavailable");

        float value = 0;

        DOTween.To(() => value, newValue => value = newValue, 1f, _reLoadDuration).OnComplete(Restart);

        void Restart()
        {
            LoadAds();
        }
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

    private void OnUserEarnedReward(IronSourcePlacement placement, IronSourceAdInfo info)
    {
        Time.timeScale = _lastTimeScale;
        _audioListener.enabled = true;
    }

    public void LoadAds()
    {
        IronSourceRewardedVideoEvents.onAdReadyEvent += (i) => Debug.Log("RVE rewarded video ready - before");
        IronSourceRewardedVideoEvents.onAdAvailableEvent += (i) => Debug.Log("RVE rewarded video available - before");

        IronSourceEvents.onRewardedVideoAdReadyEvent += () => Debug.Log("ISE rewarded video ready - before");

        Debug.Log("Loading rewarded video");
        IronSource.Agent.loadRewardedVideo();
        IronSourceEvents.onRewardedVideoAdReadyEvent += () => Debug.Log("ISE rewarded video ready - after");
        IronSourceRewardedVideoEvents.onAdReadyEvent += (i) => Debug.Log("RVE rewarded video ready - after");
        IronSourceRewardedVideoEvents.onAdAvailableEvent += (i) => Debug.Log("RVE rewarded video available - after");

    }
    #region REGISTER
    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _rewardedAdRegisterator.OnAdLoadFailedEvent += method;
    }

	public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
	{
		_rewardedAdRegisterator.OnAdReadyEvent += method;
	}

    public void RegisterOnAdUnavailableEvent(Action method)
    {
        Debug.Log("Rewarded Ad registering on ad available");
        _rewardedAdRegisterator.OnAdUnavailable += method;
    }

    public void RegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdAvailableEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdOpenedEvent += method;
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClosedEvent += method;
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdShowFailedEvent += method;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClickedEvent += method;
    }

    public void RegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdRewardedEvent += method;
    }
    #endregion

    #region UNREGISTER
    public void UnRegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClickedEvent -= method;
    }

    public void UnRegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdRewardedEvent -= method;
    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdShowFailedEvent -= method;
    }


    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdOpenedEvent -= method;
    }
    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdReadyEvent -= method;
    }

    public void UnRegisterOnAdUnavailableEvent(Action method)
    {
        _rewardedAdRegisterator.OnAdUnavailable -= method;
    }

    public void UnRegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdAvailableEvent -= method;
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _rewardedAdRegisterator.OnAdClosedEvent -= method;
    }

    public void TerminateAd()
    {
        //IronSourceRewardedVideoEvents.ResetEvents();
        //IronSource.Agent.clearRewardedVideoServerParams();  
        UnRegisterIronSourceEvents();
    }

    #endregion

    public void RegisterIronSourceEvents()
    {
        _rewardedAdRegisterator.OnAdUnavailable += () => Debug.Log("Test Dol Eventi");
        _rewardedAdRegisterator.OnAdUnavailable?.Invoke();

        Debug.Log("Registering iron source rewarded events");
        IronSourceRewardedVideoEvents.onAdAvailableEvent += _rewardedAdRegisterator.FireOnAdAvailableEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += _rewardedAdRegisterator.FireOnAdClickedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += _rewardedAdRegisterator.FireOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += _rewardedAdRegisterator.FireOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += _rewardedAdRegisterator.FireOnAdRewardedEvent; // _rewardAdRegisterator.FireoNAdRewarded;
        IronSourceRewardedVideoEvents.onAdReadyEvent += _rewardedAdRegisterator.FireOnAdReadyEvent;
        IronSourceRewardedVideoEvents.onAdLoadFailedEvent += _rewardedAdRegisterator.FireOnAdLoadFailedEvent;
        IronSourceRewardedVideoEvents.onAdOpenedEvent += _rewardedAdRegisterator.FireOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += _rewardedAdRegisterator.FireOnAdShowFailedEvent;
    }

    private void UnRegisterIronSourceEvents()
    {
        IronSourceRewardedVideoEvents.onAdAvailableEvent -= _rewardedAdRegisterator.FireOnAdAvailableEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent -= _rewardedAdRegisterator.FireOnAdClickedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent -= _rewardedAdRegisterator.FireOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent -= _rewardedAdRegisterator.FireOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdRewardedEvent -= _rewardedAdRegisterator.FireOnAdRewardedEvent; // _rewardAdRegisterator.FireoNAdRewarded;
        IronSourceRewardedVideoEvents.onAdReadyEvent -= _rewardedAdRegisterator.FireOnAdReadyEvent;
        IronSourceRewardedVideoEvents.onAdLoadFailedEvent -= _rewardedAdRegisterator.FireOnAdLoadFailedEvent;
        IronSourceRewardedVideoEvents.onAdOpenedEvent -= _rewardedAdRegisterator.FireOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent -= _rewardedAdRegisterator.FireOnAdShowFailedEvent;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {

    }
}