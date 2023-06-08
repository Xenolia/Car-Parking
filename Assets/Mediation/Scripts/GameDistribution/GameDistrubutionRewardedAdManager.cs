using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if EN_GDAD
public class GameDistrubutionRewardedAdManager : IRewardedAdManager
{
    private GameDistribution _instance;
    private float _lastTimeScale;
    private float _adReloadDuration = 5f;

    private Action<IronSourceAdInfo> OnRewardedVideoSucess;
    private Action<IronSourcePlacement, IronSourceAdInfo> OnUserEarnedReward;
    private Action<IronSourceAdInfo> OnAdOpnedEvent;
    private Action<IronSourceAdInfo> OnAdClosedEvent;
    private Action<IronSourceError> OnAdFailedToLoadEvent;

    private bool _isAdReady = false;
    public GameDistrubutionRewardedAdManager()
    {
        _instance = GameDistribution.Instance;
    }
    public bool IsRewardedAdReady()
    {
        Debug.Log("IsRewardedAdReady :" + _instance.IsRewardedVideoLoaded());
        return _isAdReady;
    }

    public void LoadAds()
    {
        float x = 0f;
        _instance.PreloadRewardedAd();

        if(_isAdReady == false)
        {
            DOTween.To(() => x, newValue => x = newValue, 1f, 1f).OnComplete(LoadAds);
        }
        else
        {
            return;
        }
    }

    public void RegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method)
    {
    
    }

    public void RegisterIronSourceEvents()
    {
        GameDistribution.OnResumeGame += OnResumeGame;
        GameDistribution.OnPauseGame += OnPauseGame;
        GameDistribution.OnPreloadRewardedVideo += OnPreLoadRewardedVideo;
        GameDistribution.OnRewardedVideoSuccess += OnRewardedVideoSuccess;// This doesnt count it
        GameDistribution.OnRewardGame += OnUserEarnedRewardMethod;
        GameDistribution.OnRewardedVideoFailure += OnAdFailedToLoad;
    }

    private void UnRegisterEvents()
    {
        GameDistribution.OnResumeGame -= OnResumeGame;
        GameDistribution.OnPauseGame -= OnPauseGame;
        GameDistribution.OnPreloadRewardedVideo -= OnPreLoadRewardedVideo;
        GameDistribution.OnRewardedVideoSuccess -= OnRewardedVideoSuccess;
        GameDistribution.OnRewardGame -= OnUserEarnedRewardMethod;
        GameDistribution.OnRewardedVideoFailure -= OnAdFailedToLoad;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {

    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        Debug.Log("Registered rewarded ad on closed");
        OnAdClosedEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        Debug.Log("Registered rewarded ad on load failed");
        OnAdFailedToLoadEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        Debug.Log("Registered rewarded ad  on opened");
        OnAdOpnedEvent += method;
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
        OnUserEarnedReward += method;
    }

    public void ShowAd()
    {
        _instance.ShowRewardedAd();
    }

    public void TerminateAd()
    {
        UnRegisterEvents();
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

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdOpnedEvent -= method;
    }

    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        OnAdFailedToLoadEvent -= method;
    }
    public void UnRegisterOnAdUnavailableEvent(Action method)
    {

    }

    public void UnRegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method)
    {
        OnUserEarnedReward -= method;
    }

    #region GAMEDISTRIBUTIONSPECIAL
    private void OnResumeGame()
    {
        Debug.Log("Rewarded add game resume");

        //  Time.timeScale = _lastTimeScale;
        Time.timeScale = 1f;
        AudioListener.volume = 1f;

        OnAdClosedEvent?.Invoke(null);
    }

    private void OnPauseGame()
    {
        Debug.Log("Rewarded add game pause");


        //_lastTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        AudioListener.volume = 0f;

        OnAdOpnedEvent?.Invoke(null);
    }

    private void OnPreLoadRewardedVideo(int index)
    {
        Debug.Log("On pre load result");

        if(index == 0)
        {
            float x = 0f;

            DOTween.To(() => x, newValue => x = newValue, 1, _adReloadDuration).OnComplete(ReloadAd);
        }
        else if(index == 1)
        {
            _isAdReady = true;
            return; 
        }

        void ReloadAd()
        {
            Debug.Log("Pre loading again");
            _instance.PreloadRewardedAd();
        }
    }

    private void OnRewardedVideoSuccess()
    {
        OnRewardedVideoSucess?.Invoke(null);
        _instance.PreloadRewardedAd();
    }

    private void OnUserEarnedRewardMethod()
    {
        OnUserEarnedReward?.Invoke(null, null);
        _instance.PreloadRewardedAd();
    }

    private void OnAdFailedToLoad()
    {
        OnAdFailedToLoadEvent?.Invoke(null);
    }
    #endregion
}
#endif