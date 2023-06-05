//using CrazyGames;
 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if CRAZY_GSDK
public class CrazyGamesBannerAdManager : IBannerAdManager
{
	//private CrazyBanner _crazyBanner1;
	//private CrazyBanner _crazyBanner2;
 //   private CrazyAds _adInstance;
	public CrazyGamesBannerAdManager()
	{
        /*
		var bannerPrefab = Resources.Load<CrazyBanner>("CrazyBanner");
		_crazyBanner1 = GameObject.Instantiate(bannerPrefab);
        _crazyBanner2 = GameObject.Instantiate(bannerPrefab);

        _adInstance = CrazyAds.Instance;

		RectTransform rect1 = _crazyBanner1.GetComponentInChildren<Image>().GetComponent<RectTransform>();
		RectTransform rect2 = _crazyBanner2.GetComponentInChildren<Image>().GetComponent<RectTransform>();

        SetToBottomLeft(rect1);
		SetToBottomRight(rect2);
        RequestBanner();
        */
	}

	private void SetToBottomLeft(RectTransform rectTransform)
	{
        rectTransform.SetAnchor(AnchorPresets.BottomLeft, 160, 30);
    }

	private void SetToBottomRight(RectTransform rectTransform)
	{
        rectTransform.SetAnchor(AnchorPresets.BottomRight, -160, 30);
    }


	public void RequestBanner()
	{
		//_crazyBanner1.MarkVisible(true);
		//_crazyBanner2.MarkVisible(true);	
		//_adInstance.updateBannersDisplay();
	}

	public void TerminateCurrentAd()
	{
  //      _crazyBanner1.MarkVisible(false);
		//_crazyBanner2.MarkVisible(false);
  //      _adInstance.updateBannersDisplay();
    }

    public void LoadFromAnotherInstance()
    {

    }

    public void RegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {
  
    }

    public void RegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {
  
    }

    public void RegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method)
    {
 
    }

    public void RegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void RegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void RegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdLoadFailedEvent(Action<IronSourceError> method)
    {

    }

    public void UnRegisterOnAdClickedEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdLoadedEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdScreenPresentedEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdScreenDismissedEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void UnRegisterOnAdKLeftApplicationEvent(Action<IronSourceAdInfo> method)
    {

    }

    public void TerminateAd()
    {

    }

    public void HideBanner()
    {

    }

    public void DisplayBanner()
    {

    }

    public void LoadAds(IronSourceBannerSizeEnum bannerSize, BannerRect bannerRect, IronSourceBannerPosition bannerPosition)
    {
    
    }

    public void RegisterIronsSourceBannerEvents()
    {
    
    }
}

public enum AnchorPresets
{
    TopLeft,
    TopCenter,
    TopRight,

    MiddleLeft,
    MiddleCenter,
    MiddleRight,

    BottomLeft,
    BottonCenter,
    BottomRight,
    BottomStretch,

    VertStretchLeft,
    VertStretchRight,
    VertStretchCenter,

    HorStretchTop,
    HorStretchMiddle,
    HorStretchBottom,

    StretchAll
}

public enum PivotPresets
{
    TopLeft,
    TopCenter,
    TopRight,

    MiddleLeft,
    MiddleCenter,
    MiddleRight,

    BottomLeft,
    BottomCenter,
    BottomRight,
}

public static class RectTransformExtensions
{
    public static void SetAnchor(this RectTransform source, AnchorPresets allign, int offsetX = 0, int offsetY = 0)
    {
        source.anchoredPosition = new Vector3(offsetX, offsetY, 0);

        switch (allign)
        {
            case (AnchorPresets.TopLeft):
                {
                    source.anchorMin = new Vector2(0, 1);
                    source.anchorMax = new Vector2(0, 1);
                    break;
                }
            case (AnchorPresets.TopCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 1);
                    source.anchorMax = new Vector2(0.5f, 1);
                    break;
                }
            case (AnchorPresets.TopRight):
                {
                    source.anchorMin = new Vector2(1, 1);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }

            case (AnchorPresets.MiddleLeft):
                {
                    source.anchorMin = new Vector2(0, 0.5f);
                    source.anchorMax = new Vector2(0, 0.5f);
                    break;
                }
            case (AnchorPresets.MiddleCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 0.5f);
                    source.anchorMax = new Vector2(0.5f, 0.5f);
                    break;
                }
            case (AnchorPresets.MiddleRight):
                {
                    source.anchorMin = new Vector2(1, 0.5f);
                    source.anchorMax = new Vector2(1, 0.5f);
                    break;
                }

            case (AnchorPresets.BottomLeft):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(0, 0);
                    break;
                }
            case (AnchorPresets.BottonCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 0);
                    source.anchorMax = new Vector2(0.5f, 0);
                    break;
                }
            case (AnchorPresets.BottomRight):
                {
                    source.anchorMin = new Vector2(1, 0);
                    source.anchorMax = new Vector2(1, 0);
                    break;
                }

            case (AnchorPresets.HorStretchTop):
                {
                    source.anchorMin = new Vector2(0, 1);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }
            case (AnchorPresets.HorStretchMiddle):
                {
                    source.anchorMin = new Vector2(0, 0.5f);
                    source.anchorMax = new Vector2(1, 0.5f);
                    break;
                }
            case (AnchorPresets.HorStretchBottom):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(1, 0);
                    break;
                }

            case (AnchorPresets.VertStretchLeft):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(0, 1);
                    break;
                }
            case (AnchorPresets.VertStretchCenter):
                {
                    source.anchorMin = new Vector2(0.5f, 0);
                    source.anchorMax = new Vector2(0.5f, 1);
                    break;
                }
            case (AnchorPresets.VertStretchRight):
                {
                    source.anchorMin = new Vector2(1, 0);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }

            case (AnchorPresets.StretchAll):
                {
                    source.anchorMin = new Vector2(0, 0);
                    source.anchorMax = new Vector2(1, 1);
                    break;
                }
        }
    }

    public static void SetPivot(this RectTransform source, PivotPresets preset)
    {

        switch (preset)
        {
            case (PivotPresets.TopLeft):
                {
                    source.pivot = new Vector2(0, 1);
                    break;
                }
            case (PivotPresets.TopCenter):
                {
                    source.pivot = new Vector2(0.5f, 1);
                    break;
                }
            case (PivotPresets.TopRight):
                {
                    source.pivot = new Vector2(1, 1);
                    break;
                }

            case (PivotPresets.MiddleLeft):
                {
                    source.pivot = new Vector2(0, 0.5f);
                    break;
                }
            case (PivotPresets.MiddleCenter):
                {
                    source.pivot = new Vector2(0.5f, 0.5f);
                    break;
                }
            case (PivotPresets.MiddleRight):
                {
                    source.pivot = new Vector2(1, 0.5f);
                    break;
                }

            case (PivotPresets.BottomLeft):
                {
                    source.pivot = new Vector2(0, 0);
                    break;
                }
            case (PivotPresets.BottomCenter):
                {
                    source.pivot = new Vector2(0.5f, 0);
                    break;
                }
            case (PivotPresets.BottomRight):
                {
                    source.pivot = new Vector2(1, 0);
                    break;
                }
        }
    }
}
#endif