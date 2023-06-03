
using System;
//using static CrazyGames.CrazyBanner;

public interface IRewardedAdManager
{
    #region REGISTER
    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method);

    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdUnavailableEvent(Action method);

    public void RegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method);

    public void RegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method);

    public void RegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method);
    #endregion

    #region UNREGISTER
    public void UnRegisterOnAdClickedEvent(Action<IronSourcePlacement, IronSourceAdInfo> method);

    public void UnRegisterOnUserEarnedRewarededEvent(Action<IronSourcePlacement, IronSourceAdInfo> method);

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method);


    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method);
    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method);

    public void UnRegisterOnAdUnavailableEvent(Action method);

    public void UnRegisteOnAdAvailableEvent(Action<IronSourceAdInfo> method);

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method);
    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method);
    #endregion

    #region PUBLIC METHODS
    public void TerminateAd();

    public bool IsRewardedAdReady();

    public void ShowAd();
    public void LoadAds();
    public void RegisterIronSourceEvents();

    #endregion
}

public interface IInterstatialAdManager
{
    #region REGISTER
    public void RegisterOnAdReadyEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method);

    public void RegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method);

    public void RegisterOnAdClosedEvent(Action<IronSourceAdInfo> method);

    public void RegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method);
    #endregion

    #region UNREGISTER
    public void UnRegisterOnAdReadyEvent(Action<IronSourceAdInfo> method);

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method);

    public void UnRegisterOnAdShowSucceededEvent(Action<IronSourceAdInfo> method);

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method);

    public void UnRegisterOnAdShowFailedEvent(Action<IronSourceError, IronSourceAdInfo> method);

    public void UnRegisterOnAdClosedEvent(Action<IronSourceAdInfo> method);

    public void UnRegisterOnAdOpenedEvent(Action<IronSourceAdInfo> method);
    #endregion

    #region PUBLIC METHODS
    public void LoadAds();
    public void TerminateAd();
    public bool IsInterstatialAdReady();
    public void ShowAd();
    public void RegisterIronSourceInterstatialEvents();
    #endregion
}

public interface IBannerAdManager
{
    #region REGISTER
    public void LoadFromAnotherInstance();
    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method);
    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method);
    public void RegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method);
    public void RegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method);
    public void RegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method);
    public void RegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method);
    #endregion

    #region UNREGISTER
    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method);
    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method);
    public void UnRegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method);
    public void UnRegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method);
    public void UnRegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method);
    public void UnRegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method);

    #endregion
    #region PUBLIC METHODS
    public void TerminateAd();
    public void HideBanner();
    public void DisplayBanner();
    public void LoadAds(IronSourceBannerSizeEnum bannerSize, BannerRect bannerRect, IronSourceBannerPosition bannerPosition);
    public void RegisterIronsSourceBannerEvents();
    #endregion
}
