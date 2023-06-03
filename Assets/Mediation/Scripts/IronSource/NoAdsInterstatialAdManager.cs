using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAdsInterstatialAdManager : IInterstatialAdManager
{
    public bool IsInterstatialAdReady()
    {
        return false;
    }

    public void LoadAds()
    {
     
    }

    public void RegisterIronSourceInterstatialEvents()
    {
      
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
   
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
      
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
      
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
     
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
 
    }

    public void TerminateAd()
    {
      
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
      
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
      
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
      
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
       
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
}
