using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static CrazyGames.CrazyBanner;

public class IronSourceBannerAdManager : IBannerAdManager
{
    private float _reLoadDuration = 5f;
    private BannerAdRegisterator _bannerAdRegisterator;
    IronSourceBannerSizeEnum _bannnerSize;
    IronSourceBannerPosition _bannerPosition;
    private int _width;
    private int _height;
    public IronSourceBannerAdManager()
	{
        _bannerAdRegisterator = new BannerAdRegisterator();
       // RegisterIronsSourceBannerEvents();
        RegisterOnAdLoadFailedEvent(OnLoadFailedEvent);
        RegisterOnAdLoadedEvent(TestDebug);
        RegisterOnAdScreenDismissedEvent(TestDebug);
        RegisterOnAdScreenPresentedEvent(TestDebug);
    }

	private IronSourceBannerSize GetBannerSize(IronSourceBannerSizeEnum bannerSize, int height, int width )
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

    public void HideBanner()
    {
        IronSource.Agent.hideBanner();
    }

    public void DisplayBanner()
    {
        IronSource.Agent.displayBanner();
    }


    public void LoadAds(IronSourceBannerSizeEnum bannerSize, BannerRect bannerRect, IronSourceBannerPosition bannerPosition)
    {
        _bannerPosition = bannerPosition;
        IronSource.Agent.loadBanner(GetBannerSize(bannerSize, bannerRect.Width, bannerRect.Height), bannerPosition);

    }
    private void OnLoadFailedEvent(IronSourceError error)
    {
        Debug.Log("From Manager script");
        Debug.LogError("Banner ad has failed to load with error code : " + error.getErrorCode());

        float value = 0;

        DOTween.To(() => value, newValue => value = newValue, 1f, _reLoadDuration).OnComplete(Restart);

        void Restart()
        {
            IronSource.Agent.loadBanner(GetBannerSize(_bannnerSize, _width, _height), _bannerPosition);
        }
    }

    #region REGISTER
    public void LoadFromAnotherInstance()
    {
        IronSource.Agent.loadBanner(GetBannerSize(_bannnerSize, _width, _height), _bannerPosition);
    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
       _bannerAdRegisterator.OnAdLoadFailedEvent += method;
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdClickedEvent += method;
    }

    public void RegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLoadedEvent += method;
    }

    public void RegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenPresentedEvent += method;
    }

    public void RegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenDismissedEvent += method;
    }
    public void RegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLeftApplicationEvent += method;
    }
    #endregion

    #region UNREGISTER
    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
        _bannerAdRegisterator.OnAdLoadFailedEvent -= method;
    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdClickedEvent -= method;
    }

    public void UnRegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLoadedEvent -= method;
    }

    public void UnRegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenPresentedEvent -= method;
    }

    public void UnRegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdScreenDismissedEvent += method;
    }
    public void UnRegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method)
    {
        _bannerAdRegisterator.OnAdLeftApplicationEvent += method;
    }
    #endregion
    public void TerminateAd()
    {
        //IronSourceBannerEvents.ResetEvents();
        UnRegisterIronsSourceBannerEvents();
        IronSource.Agent.destroyBanner();
    }

    public void RegisterIronsSourceBannerEvents()
    {
        Debug.Log("Registering iron source banner events");
        IronSourceBannerEvents.onAdClickedEvent += _bannerAdRegisterator.FireOnAdClickedEvent;
        IronSourceBannerEvents.onAdLeftApplicationEvent += _bannerAdRegisterator.FireOnAdLeftApplicationEvent;
        IronSourceBannerEvents.onAdLoadedEvent += _bannerAdRegisterator.FireOnAdLoadedEvent;
        IronSourceBannerEvents.onAdLoadFailedEvent += _bannerAdRegisterator.FireOnAdLoadFailedEvent;
        IronSourceBannerEvents.onAdScreenDismissedEvent += _bannerAdRegisterator.FireOnAdScreenDismissedEvent;
        IronSourceBannerEvents.onAdScreenPresentedEvent += _bannerAdRegisterator.FireOnAdScreenPresentedEvent;
    }

    private void UnRegisterIronsSourceBannerEvents()
    {
        IronSourceBannerEvents.onAdClickedEvent -= _bannerAdRegisterator.FireOnAdClickedEvent;
        IronSourceBannerEvents.onAdLeftApplicationEvent -= _bannerAdRegisterator.FireOnAdLeftApplicationEvent;
        IronSourceBannerEvents.onAdLoadedEvent -= _bannerAdRegisterator.FireOnAdLoadedEvent;
        IronSourceBannerEvents.onAdLoadFailedEvent -= _bannerAdRegisterator.FireOnAdLoadFailedEvent;
        IronSourceBannerEvents.onAdScreenDismissedEvent -= _bannerAdRegisterator.FireOnAdScreenDismissedEvent;
        IronSourceBannerEvents.onAdScreenPresentedEvent -= _bannerAdRegisterator.FireOnAdScreenPresentedEvent;
    }

    private void TestDebug(IronSourceAdInfo adInfo) {
        Debug.LogError("netw0rk name "+ adInfo.adNetwork);
    }
        
}

public enum IronSourceBannerSizeEnum
{
	BANNER,
	LARGE,
	RECTANGLE,
	SMART,
	COSTUM
}
[System.Serializable]
public struct BannerRect
{
	[field : SerializeField] public int Width { get; private set; }
	[field : SerializeField] public int Height { get; private set; }

    public BannerRect(int height, int width)
    {
        Height = height;
        Width = width;
    }
}
