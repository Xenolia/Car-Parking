using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if GAME_MONOTIZE
public class GameMonatizeInterstatialAdManager : IInterstatialAdManager
{
    public Action<IronSourceAdInfo> OnInterstatialAdOpend;
    public Action<IronSourceAdInfo> OnInterstatialAdClosed;

    private float _lastTimeScale;

    private GameMonetize _instance;

    public GameMonatizeInterstatialAdManager()
    {
        _instance = GameMonetize.Instance;
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
        GameMonetize.OnPauseGame += OnAdOpened;
        GameMonetize.OnResumeGame += OnAdClosed;
    }

    private void UnRegisterIronSourceInterstatialEvents()
    {
        GameMonetize.OnPauseGame -= OnAdOpened;
        GameMonetize.OnResumeGame -= OnAdClosed;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
   
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdClosed += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {

    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdOpend += method;
    }

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        throw new NotImplementedException();
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {

    }

    public void RegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void ShowAd()
    {

    }

    public void TerminateAd()
    {
        UnRegisterIronSourceInterstatialEvents();
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdClosed -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {

    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        OnInterstatialAdOpend -= method;
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
        //_lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
        AudioListener.volume = 0f;
        OnInterstatialAdOpend?.Invoke(null);
    }

    private void OnAdClosed()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        OnInterstatialAdClosed?.Invoke(null);   
    }
}
#endif