using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeInterstatialAdManager : IInterstatialAdManager
{
    private InterstatialAdRegisterator _interstatialAdRegisterator;
    public FakeInterstatialAdManager()
    {
        _interstatialAdRegisterator = new InterstatialAdRegisterator();
    }

    public bool IsInterstatialAdReady()
    {
        return IronSource.Agent.isInterstitialReady();
    }

    public void LoadAds()
    {
        IronSource.Agent.loadInterstitial();
    }

    public void RegisterIronSourceInterstatialEvents()
    {
        FakeInterstatialEvents.OnInterstatialAdClicked += _interstatialAdRegisterator.FireOnAdClickedEvent;
        FakeInterstatialEvents.OnInterstatialAdClosed += _interstatialAdRegisterator.FireOnAdClosedEvent;
        FakeInterstatialEvents.OnInterstatialAdOpened += _interstatialAdRegisterator.FireOnAdOpenedEvent;
        FakeInterstatialEvents.OnInterstailAdReady += _interstatialAdRegisterator.FireOnAdReadyEvent;
        FakeInterstatialEvents.OnInterstatialAdFailedToLoad += _interstatialAdRegisterator.FireOnAdLoadFailedEvent;
        FakeInterstatialEvents.OnInterstatialAdShownFailed += _interstatialAdRegisterator.FireOnAdShowFailedEvent;
        FakeInterstatialEvents.OnInterstatialAdSuccesed += _interstatialAdRegisterator.FireOnAdShowSucceededEvent;
    }

    private void UnRegisterIronSourceInterstatialEvents()
    {
        FakeInterstatialEvents.OnInterstatialAdClicked -= _interstatialAdRegisterator.FireOnAdClickedEvent;
        FakeInterstatialEvents.OnInterstatialAdClosed -= _interstatialAdRegisterator.FireOnAdClosedEvent;
        FakeInterstatialEvents.OnInterstatialAdOpened -= _interstatialAdRegisterator.FireOnAdOpenedEvent;
        FakeInterstatialEvents.OnInterstailAdReady -= _interstatialAdRegisterator.FireOnAdReadyEvent;
        FakeInterstatialEvents.OnInterstatialAdFailedToLoad -= _interstatialAdRegisterator.FireOnAdLoadFailedEvent;
        FakeInterstatialEvents.OnInterstatialAdShownFailed -= _interstatialAdRegisterator.FireOnAdShowFailedEvent;
        FakeInterstatialEvents.OnInterstatialAdSuccesed -= _interstatialAdRegisterator.FireOnAdShowSucceededEvent;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClickedEvent += method;
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClosedEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _interstatialAdRegisterator.OnAdLoadFailedEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdOpenedEvent += method;
    }

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdReadyEvent += method;
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowFailedEvent += method;
    }

    public void RegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowSucceededEvent += method;
    }

    public void ShowAd()
    {
        IronSource.Agent.showInterstitial();
    }

    public void TerminateAd()
    {
        UnRegisterIronSourceInterstatialEvents();
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClickedEvent -= method;
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClosedEvent -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _interstatialAdRegisterator.OnAdLoadFailedEvent -= method;
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdOpenedEvent -= method;
    }

    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdReadyEvent -= method;
    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowFailedEvent -= method;
    }

    public void UnRegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowSucceededEvent -= method;
    }
}
