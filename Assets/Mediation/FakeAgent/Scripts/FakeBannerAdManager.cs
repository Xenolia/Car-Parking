using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBannerAdManager : IBannerAdManager
{
    private IronSourceBannerSizeEnum _bannnerSize;
    private float _width;
    private float _height;

    private BannerAdRegisterator _bannerAdRegisterator;

    public FakeBannerAdManager()
    {
        _bannerAdRegisterator = new BannerAdRegisterator();
    }

    public void DisplayBanner()
    {
        IronSource.Agent.displayBanner();
    }

    public void HideBanner()
    {
        IronSource.Agent.hideBanner();
    }

    public void LoadAds(IronSourceBannerSizeEnum bannerSize, BannerRect bannerRect, IronSourceBannerPosition bannerPosition)
    {
        IronSource.Agent.loadBanner(GetBannerSize(bannerSize, bannerRect.Width, bannerRect.Height), bannerPosition);
    }

    public void LoadFromAnotherInstance()
    {
     
    }

    public void RegisterIronsSourceBannerEvents()
    {
        FakeBannerEvents.OnBannerAdClickedEvent += _bannerAdRegisterator.FireOnAdClickedEvent;
        FakeBannerEvents.OnBannerAdLeftApplicationEvent += _bannerAdRegisterator.FireOnAdLeftApplicationEvent;
        FakeBannerEvents.OnBannerAdLoadedEvent += _bannerAdRegisterator.FireOnAdLoadedEvent;
        FakeBannerEvents.OnBannerAdLoadFailedEvent += _bannerAdRegisterator.FireOnAdLoadFailedEvent;
        FakeBannerEvents.OnBannerAdScreenDismissedEvent += _bannerAdRegisterator.FireOnAdScreenDismissedEvent;
        FakeBannerEvents.OnBannerAdScreenPresentedEvent += _bannerAdRegisterator.FireOnAdScreenPresentedEvent;
    }

    private void UnRegisterIronsSourceBannerEvents()
    {
        FakeBannerEvents.OnBannerAdClickedEvent -= _bannerAdRegisterator.FireOnAdClickedEvent;
        FakeBannerEvents.OnBannerAdLeftApplicationEvent -= _bannerAdRegisterator.FireOnAdLeftApplicationEvent;
        FakeBannerEvents.OnBannerAdLoadedEvent -= _bannerAdRegisterator.FireOnAdLoadedEvent;
        FakeBannerEvents.OnBannerAdLoadFailedEvent -= _bannerAdRegisterator.FireOnAdLoadFailedEvent;
        FakeBannerEvents.OnBannerAdScreenDismissedEvent -= _bannerAdRegisterator.FireOnAdScreenDismissedEvent;
        FakeBannerEvents.OnBannerAdScreenPresentedEvent -= _bannerAdRegisterator.FireOnAdScreenPresentedEvent;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdClickedEvent += method;
    }

    public void RegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLeftApplicationEvent += method;
    }

    public void RegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLoadedEvent += method;
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _bannerAdRegisterator.OnAdLoadFailedEvent += method;
    }

    public void RegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenDismissedEvent += method;
    }

    public void RegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenPresentedEvent += method;
    }

    public void TerminateAd()
    {
        UnRegisterIronsSourceBannerEvents();
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdClickedEvent -= method;
    }

    public void UnRegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLeftApplicationEvent -= method;
    }

    public void UnRegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLoadedEvent -= method;
    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _bannerAdRegisterator.OnAdLoadFailedEvent -= method;
    }

    public void UnRegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenDismissedEvent -= method;
    }

    public void UnRegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenPresentedEvent -= method;
    }

    private IronSourceBannerSize GetBannerSize(IronSourceBannerSizeEnum bannerSize, int height, int width)
    {
        _bannnerSize = bannerSize;
        _width = width;
        _height = height;
        switch (bannerSize)
        {
            case IronSourceBannerSizeEnum.BANNER:
                return IronSourceBannerSize.BANNER;
                break;
            case IronSourceBannerSizeEnum.LARGE:
                return IronSourceBannerSize.LARGE;
                break;
            case IronSourceBannerSizeEnum.RECTANGLE:
                return IronSourceBannerSize.RECTANGLE;
                break;
            case IronSourceBannerSizeEnum.SMART:
                return IronSourceBannerSize.SMART;
                break;
            case IronSourceBannerSizeEnum.COSTUM:
                return new IronSourceBannerSize(width, height);
                break;
            default:
                return IronSourceBannerSize.SMART;
                break;
        }
    }
}
