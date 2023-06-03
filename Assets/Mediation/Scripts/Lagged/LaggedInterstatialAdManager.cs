using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if LAGGED
public class LaggedInterstatialAdManager : IInterstatialAdManager
{
    private LaggedAPIUnity _laggedAPI;

    private Action<IronSourceAdInfo> OnAdClosedEvent;
    private Action<IronSourceAdInfo> OnAdOpenedEvent;
    public LaggedInterstatialAdManager()
    {
        _laggedAPI = LaggedAPIUnity.Instance;
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
        LaggedAPIUnity.OnResumeGame += OnAdClosed;
        LaggedAPIUnity.OnPauseGame += OnAdOpened;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
   
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        OnAdClosedEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {

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

    public void RegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void ShowAd()
    {
        _laggedAPI.ShowAd();
    }

    public void TerminateAd()
    {
        LaggedAPIUnity.OnResumeGame -= OnAdClosed;
        LaggedAPIUnity.OnPauseGame -= OnAdOpened;
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
       OnAdOpenedEvent -= method;
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

    private void OnAdClosed()
    {
        Debug.Log("Interstatial ad is closed");
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        OnAdClosedEvent?.Invoke(null);
    }

    private void OnAdOpened()
    {
        Debug.Log("Interstatial ad is opened");  
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        OnAdOpenedEvent?.Invoke(null);
    }
    
}
#endif