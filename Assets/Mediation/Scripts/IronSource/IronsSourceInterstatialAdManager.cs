using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronsSourceInterstatialAdManager : IInterstatialAdManager
{
    private float _reLoadDuration = 5f;
    private InterstatialAdRegisterator _interstatialAdRegisterator;
    public IronsSourceInterstatialAdManager()
	{
        _interstatialAdRegisterator = new InterstatialAdRegisterator();
        IronSource.Agent.loadInterstitial();
      //  RegisterIronSourceInterstatialEvents();
        RegisterOnAdLoadFailedEvent(OnAdLoadFailed);
    }

    public bool IsInterstatialAdReady()
    {
        return IronSource.Agent.isInterstitialReady();
    }

    public void ShowAd()
    {
        IronSource.Agent.showInterstitial();
    }

    private void OnAdLoadFailed(IronSourceError error)
    {
        Debug.LogError("Interstatial ad has failed to load  with error code : " + error.getErrorCode());

        float value = 0;

        DOTween.To(() => value, newValue => value = newValue, 1f, _reLoadDuration).OnComplete(Restart);

        void Restart()
        {
            LoadAds();
        }
    }

    public void LoadAds()
    {
        IronSource.Agent.loadInterstitial();

    }

    #region REGISTER
    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        Debug.Log("Registering interstatial OnAdReadyEvent");
        _interstatialAdRegisterator.OnAdReadyEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _interstatialAdRegisterator.OnAdLoadFailedEvent += method;
    }

    public void RegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowSucceededEvent += method;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClickedEvent += method;
    }

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError,IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowFailedEvent += method;
    }

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClosedEvent += method;
    }

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdOpenedEvent += method;
    }
    #endregion

    #region UNREGISTER
    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdReadyEvent -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _interstatialAdRegisterator.OnAdLoadFailedEvent -= method;
    }

    public void UnRegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowSucceededEvent -= method;
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClickedEvent -= method;
    }

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdShowFailedEvent -= method;
    }

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdClosedEvent -= method;
    }

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method)
    {
        _interstatialAdRegisterator.OnAdOpenedEvent -= method;
    }
    #endregion
    public void TerminateAd()
    {
        // IronSourceInterstitialEvents.ResetEvents();
        UnRegisterIronSourceInterstatialEvents();
    }

    public void RegisterIronSourceInterstatialEvents()
    {
        Debug.Log("Registering iron source interstatial events");
        IronSourceInterstitialEvents.onAdClickedEvent += _interstatialAdRegisterator.FireOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += _interstatialAdRegisterator.FireOnAdClosedEvent;
        IronSourceInterstitialEvents.onAdOpenedEvent += _interstatialAdRegisterator.FireOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdReadyEvent += _interstatialAdRegisterator.FireOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += _interstatialAdRegisterator.FireOnAdLoadFailedEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += _interstatialAdRegisterator.FireOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += _interstatialAdRegisterator.FireOnAdShowSucceededEvent;
    }

    private void UnRegisterIronSourceInterstatialEvents()
    {
        IronSourceInterstitialEvents.onAdClickedEvent -= _interstatialAdRegisterator.FireOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent -= _interstatialAdRegisterator.FireOnAdClosedEvent;
        IronSourceInterstitialEvents.onAdOpenedEvent -= _interstatialAdRegisterator.FireOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdReadyEvent -= _interstatialAdRegisterator.FireOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent -= _interstatialAdRegisterator.FireOnAdLoadFailedEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent -= _interstatialAdRegisterator.FireOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent -= _interstatialAdRegisterator.FireOnAdShowSucceededEvent;
    }
}
