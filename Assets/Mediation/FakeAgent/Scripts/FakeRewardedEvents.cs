using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeRewardedEvents : MonoBehaviour
{
    public static Action<IronSourceError> OnRewardedAdLoadFailedEvent;
    public static Action<IronSourceAdInfo> OnRewardedAdReadyEvent;
    public static Action OnRewardedAdUnavailable;
    public static Action<IronSourceAdInfo> OnRewardedAdAvailableEvent;
    public static Action<IronSourceAdInfo> ORewardednAdOpenedEvent;
    public static Action<IronSourceAdInfo> OnRewardedAdClosedEvent;
    public static Action<IronSourceError, IronSourceAdInfo> OnRewardedAdShowFailedEvent;
    public static Action<IronSourcePlacement, IronSourceAdInfo> OnRewardedAdClickedEvent;
    public static Action<IronSourcePlacement, IronSourceAdInfo> OnAdRewardedUserEvent;
}
