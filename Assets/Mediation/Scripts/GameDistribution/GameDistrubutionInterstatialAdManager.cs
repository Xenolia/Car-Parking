using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if EN_GDAD
public class GameDistrubutionInterstatialAdManager : IInterstatialAdManager
{
    private GameDistribution _instance;

    private Action<IronSourceAdInfo> OnAdOpenedEvent;
    private Action<IronSourceAdInfo> OnAdClosedEvent;

    private float _lastTimeScale;
    public GameDistrubutionInterstatialAdManager()
    {
        _instance = GameDistribution.Instance;
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
        GameDistribution.OnResumeGame += OnGameResume;
        GameDistribution.OnPauseGame += OnGamePaused;
    }

    private void UnregisterEvents()
    {
        GameDistribution.OnResumeGame -= OnGameResume;
        GameDistribution.OnPauseGame -= OnGamePaused;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        Debug.Log("Registered intersatatial on ad closed event");
        OnAdClosedEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        Debug.Log("Registered intersatatial on ad opened event");

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
        _instance.ShowAd();
    }

    public void TerminateAd()
    {
        UnregisterEvents();
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

    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdClosedEvent -= method;
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


    #region GAMEDISTRUBUTION
    
    private void OnGamePaused()
    {
        Debug.Log("Game has been stopped by Game Distrubution");

        AudioListener.volume = 0f;
        //_lastTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        OnAdOpenedEvent?.Invoke(null);

    }

    private void OnGameResume()
    {
        Debug.Log("Interstatial Ad Game has been resumed by Game Distrubution");


        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        OnAdClosedEvent?.Invoke(null);
    }

    #endregion
}

#endif