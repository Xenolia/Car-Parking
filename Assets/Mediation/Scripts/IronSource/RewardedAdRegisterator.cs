using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedAdRegisterator
{
    public Action<IronSourceError> OnAdLoadFailedEvent;
    public Action<IronSourceAdInfo> OnAdReadyEvent;
    public Action OnAdUnavailable;
    public Action<IronSourceAdInfo> OnAdAvailableEvent;
    public Action<IronSourceAdInfo> OnAdOpenedEvent;
    public Action<IronSourceAdInfo> OnAdClosedEvent;
    public Action<IronSourceError, IronSourceAdInfo> OnAdShowFailedEvent;
    public Action<IronSourcePlacement, IronSourceAdInfo> OnAdClickedEvent;
    public Action<IronSourcePlacement, IronSourceAdInfo> OnAdRewardedEvent;

    public RewardedAdRegisterator()
    {
        OnAdLoadFailedEvent += Empty;
        OnAdReadyEvent += Empty;
        OnAdUnavailable += Empty;
        OnAdAvailableEvent += Empty;
        OnAdOpenedEvent += Empty;
        OnAdClosedEvent += Empty;
        OnAdShowFailedEvent += Empty;
        OnAdClickedEvent += Empty;
        OnAdRewardedEvent += Empty;
    }

    private void Empty() { }
    private void Empty(IronSourceAdInfo info) { }
    private void Empty(IronSourceError error) { }
    private void Empty(IronSourceError error, IronSourceAdInfo info) { }
    private void Empty(IronSourcePlacement placement, IronSourceAdInfo info) { }

    #region INVOKES

    public void FireOnAdLoadFailedEvent(IronSourceError error) => OnAdLoadFailedEvent?.Invoke(error);

    public void FireOnAdReadyEvent(IronSourceAdInfo info) => OnAdReadyEvent?.Invoke(info);
    public void FireOnAdUnavailable() => OnAdUnavailable?.Invoke();
    public void FireOnAdAvailableEvent(IronSourceAdInfo info) => OnAdAvailableEvent?.Invoke(info);
    public void FireOnAdOpenedEvent(IronSourceAdInfo info) => OnAdOpenedEvent?.Invoke(info);
    public void FireOnAdClosedEvent(IronSourceAdInfo info) => OnAdClosedEvent?.Invoke(info);
    public void FireOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo info) => OnAdShowFailedEvent?.Invoke(error, info);
    public void FireOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo info) => OnAdClickedEvent?.Invoke(placement, info);
    public void FireOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo info) => OnAdRewardedEvent?.Invoke(placement, info);

    #endregion
}
