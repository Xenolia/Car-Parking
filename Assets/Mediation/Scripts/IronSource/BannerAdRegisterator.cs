using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAdRegisterator
{
    public  Action<IronSourceAdInfo> OnAdLoadedEvent;
    public  Action<IronSourceAdInfo> OnAdLeftApplicationEvent;
    public  Action<IronSourceAdInfo> OnAdScreenDismissedEvent;
    public  Action<IronSourceAdInfo> OnAdScreenPresentedEvent;
    public  Action<IronSourceAdInfo> OnAdClickedEvent;
    public  Action<IronSourceError> OnAdLoadFailedEvent;

    public BannerAdRegisterator()
    {
        OnAdLoadedEvent += Empty;
        OnAdLeftApplicationEvent += Empty;
        OnAdScreenDismissedEvent += Empty;
        OnAdScreenPresentedEvent += Empty;
        OnAdClickedEvent += Empty;
        OnAdLoadFailedEvent += Empty;
    }

    private void Empty(IronSourceAdInfo info) { }
    private void Empty(IronSourceError error) { }
    private void Empty(IronSourceError error, IronSourceAdInfo info) { }

    #region INVOKES
    public void FireOnAdLoadedEvent(IronSourceAdInfo info) => OnAdLoadedEvent?.Invoke(info);
    public void FireOnAdLeftApplicationEvent(IronSourceAdInfo info) => OnAdLeftApplicationEvent?.Invoke(info);
    public void FireOnAdScreenDismissedEvent(IronSourceAdInfo info) => OnAdScreenDismissedEvent?.Invoke(info);
    public void FireOnAdScreenPresentedEvent(IronSourceAdInfo info) => OnAdScreenPresentedEvent?.Invoke(info);
    public void FireOnAdClickedEvent(IronSourceAdInfo info) => OnAdClickedEvent?.Invoke(info);
    public void FireOnAdLoadFailedEvent(IronSourceError error) => OnAdLoadFailedEvent?.Invoke(error);
    #endregion
}
