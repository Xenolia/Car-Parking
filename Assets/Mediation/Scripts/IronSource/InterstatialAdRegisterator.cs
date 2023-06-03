using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterstatialAdRegisterator 
{
    public  Action<IronSourceAdInfo> OnAdReadyEvent;
    public  Action<IronSourceError> OnAdLoadFailedEvent;
    public  Action<IronSourceAdInfo> OnAdOpenedEvent;
    public  Action<IronSourceAdInfo> OnAdClosedEvent;
    public  Action<IronSourceAdInfo> OnAdShowSucceededEvent;
    public  Action<IronSourceError, IronSourceAdInfo> OnAdShowFailedEvent;
    public  Action<IronSourceAdInfo> OnAdClickedEvent;

    public InterstatialAdRegisterator()
    {
        OnAdReadyEvent += Empty;
        OnAdLoadFailedEvent += Empty;
        OnAdOpenedEvent += Empty;
        OnAdClosedEvent += Empty;
        OnAdShowSucceededEvent += Empty;
        OnAdShowFailedEvent += Empty;
        OnAdClickedEvent += Empty;
    }

    private void Empty(IronSourceAdInfo info) { }
    private void Empty(IronSourceError error) { }
    private void Empty(IronSourceError error, IronSourceAdInfo info) { }

    #region INVOKES
    public void FireOnAdReadyEvent(IronSourceAdInfo info) => OnAdReadyEvent?.Invoke(info);
    public void FireOnAdLoadFailedEvent(IronSourceError error) => OnAdLoadFailedEvent?.Invoke(error);
    public void FireOnAdOpenedEvent(IronSourceAdInfo info) => OnAdOpenedEvent?.Invoke(info);
    public void FireOnAdClosedEvent(IronSourceAdInfo info) => OnAdClosedEvent?.Invoke(info);
    public void FireOnAdShowSucceededEvent(IronSourceAdInfo info) => OnAdShowSucceededEvent?.Invoke(info);
    public void FireOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo info) => OnAdShowFailedEvent?.Invoke(error, info);
    public void FireOnAdClickedEvent(IronSourceAdInfo info) => OnAdClickedEvent?.Invoke(info);


    #endregion
}
