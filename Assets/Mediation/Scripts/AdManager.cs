using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if CRAZY_LABS
using Tabtale.TTPlugins;
#endif

public class AdManager : MonoBehaviour
{
    [SerializeField] private InAppPurchase _inAppPurchase;
    [SerializeField] private IronSourceMediationSettings _ironSourceMediationSettings;
    [SerializeField] private bool _isUnderThirteen;
    [SerializeField] private IronSourceBannerPosition _bannerPosition = IronSourceBannerPosition.BOTTOM;
    [SerializeField] private IronSourceBannerSizeEnum _bannerSize;
    [Header("CUSTOM banner size secilmedigi surece veru girmeye ihtiyac yoktur")]
    [SerializeField] private BannerRect _customBannerRect;
    // +[SerializeField] private GameDistribution _gameDistribution;
    [SerializeField] private GDFacade _gDFacade;
    [SerializeField] private bool _isNoAdd = false;

    private string _apKey = string.Empty;

    private IInterstatialAdManager _interstatialAdManager;
    private IBannerAdManager _bannerAdManager;
    private IRewardedAdManager _rewardedAdManager;
    private static bool _isIronSourceInitialized;


    public IInterstatialAdManager InterstatialAdManager => _interstatialAdManager;
    public IBannerAdManager BannerAdManager => _bannerAdManager;
    public IRewardedAdManager RewardedAdManager => _rewardedAdManager;

    public Action OnBeforeLoadingAds;
    private void Awake()
    {
        //Init();
    }

 

    private void OnDisable()
    {
        _interstatialAdManager.TerminateAd();
        _bannerAdManager.TerminateAd();
        _rewardedAdManager.TerminateAd();

        IronSourceEvents.onSdkInitializationCompletedEvent -= OnSdkInitializationComplateEvent;
        Debug.Log("Ads are terminated");
    }

    private void RemoveAdsByNoAdPurchase()
    {
        //NoAdsleri newle
        _bannerAdManager.HideBanner();
        _bannerAdManager.TerminateAd();
        _interstatialAdManager.TerminateAd();
        _interstatialAdManager = new NoAdsInterstatialAdManager();
        _bannerAdManager = new NoAdBannerAdManager();
    }

    public void  Init()
    {
        if(_inAppPurchase != null)
        {
            _inAppPurchase.RemoveAds += RemoveAdsByNoAdPurchase;
        }

#if UNITY_ANDROID && IRON_SOURCE
        _apKey = _ironSourceMediationSettings.AndroidAppKey;
#elif UNITY_IOS && IRON_SOURCE
        _apKey = _ironSourceMediationSettings.IOSAppKey;
#endif

#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR

#if !CRAZY_LABS
        IronSourceEvents.onSdkInitializationCompletedEvent += OnSdkInitializationComplateEvent;
        IronSource.Agent.init(_apKey);


        //Debug.Log("Initialization is done");

        CreateIronSourceAdManagers();

        if(_isIronSourceInitialized)
        {
            OnBeforeLoadingAds?.Invoke();
            _interstatialAdManager.RegisterIronSourceInterstatialEvents();
            _rewardedAdManager.RegisterIronSourceEvents();
            _bannerAdManager.RegisterIronsSourceBannerEvents();

            var adRemove = PlayerPrefs.GetInt("NoAds");

            if (adRemove == 1)
            {
                RemoveAdsByNoAdPurchase();
            }

          
            LoadAds();
        }
#endif
#endif

#if UNITY_ANDROID && CRAZY_LABS

#endif

#if UNITY_IOS && CRAZY_LABS

#endif

#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
#if CRAZY_LABS
        TTPCore.Setup();

        CreateIronSourceAdManagers();
#endif
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
        //_gameDistribution.Init();

        //_rewardedAdManager = new GameDistrubutionRewardedAdManager();
        //_interstatialAdManager = new GameDistrubutionInterstatialAdManager();
        //_bannerAdManager = new GameDistrubutionBannerAdManager();

        _gDFacade.Init();

        
        _rewardedAdManager = _gDFacade._rewardedAdManager;
        _interstatialAdManager = _gDFacade._interstatialAdManager;
        _bannerAdManager = _gDFacade._bannerAdManager;


        _interstatialAdManager.RegisterIronSourceInterstatialEvents();
        _rewardedAdManager.RegisterIronSourceEvents();
        _bannerAdManager.RegisterIronsSourceBannerEvents();

        LoadAds();
#endif

        if (_isNoAdd == true)
        {
            _rewardedAdManager = new NoAdRewardedAdManager();
            _interstatialAdManager = new NoAdsInterstatialAdManager();
            _bannerAdManager = new NoAdBannerAdManager();
        }
    }


#region MOBILE
    private void LoadAds()
    {

        _bannerAdManager.LoadAds(_bannerSize, _customBannerRect, _bannerPosition);
        _rewardedAdManager.LoadAds();
        _interstatialAdManager.LoadAds();
    }

    private void CreateIronSourceAdManagers()
    {
#if !CRAZY_LABS
        _rewardedAdManager = new IronSourceRewardedAdManager();
        _interstatialAdManager = new IronsSourceInterstatialAdManager();
        _bannerAdManager = new IronSourceBannerAdManager();

#endif

#if CRAZY_LABS
        _rewardedAdManager = new CrazyLabsRewardedAdManager();
        _interstatialAdManager = new CrazyLabsInterstatialAdManager();
        _bannerAdManager = new CrazyLabsBannerAdManager();
#endif
#if UNITY_EDITOR
        _rewardedAdManager = new FakeRewardedAdManager();
        _interstatialAdManager = new FakeInterstatialAdManager();
        _bannerAdManager = new FakeBannerAdManager();

        _rewardedAdManager.RegisterIronSourceEvents();
        _interstatialAdManager.RegisterIronSourceInterstatialEvents();
        _bannerAdManager.RegisterIronsSourceBannerEvents();

        LoadAds();
#endif

        Debug.Log("AdManagers are created");
    }

    private void OnSdkInitializationComplateEvent()
    {
        Debug.Log("Iron source initialization complated");
        if (_isUnderThirteen) ApplyCoppaTrue();
        else ApplyCoppaFalse();

        IronSource.Agent.validateIntegration();
        OnBeforeLoadingAds?.Invoke();


        _interstatialAdManager.RegisterIronSourceInterstatialEvents();
        _rewardedAdManager.RegisterIronSourceEvents();
        _bannerAdManager.RegisterIronsSourceBannerEvents();

        var adRemove = PlayerPrefs.GetInt("NoAds");

        if(adRemove == 1)
        {
            RemoveAdsByNoAdPurchase();
        }

        LoadAds();
        _isIronSourceInitialized = true;
    }
#if !UNITY_WEBGL
    private void OnApplicationPause(bool pause)
    {
        IronSource.Agent.onApplicationPause(pause); 
    }

#endif

    private void ApplyCoppaTrue()
    {
        IronSource.Agent.setMetaData("AdColony_COPPA", "true");
        IronSource.Agent.setMetaData("AppLovin_AgeRestrictedUser", "true");
        IronSource.Agent.setMetaData("Chartboost_Coppa", "true");
        IronSource.Agent.setMetaData("Chartboost_Coppa", "true");
        IronSource.Agent.setMetaData("AdColony_APP_Child_Directed", "true");
        IronSource.Agent.setMetaData("UnityAds_coppa", "true");
    }

    private void ApplyCoppaFalse()
    {
        IronSource.Agent.setMetaData("AdColony_COPPA", "false");
        IronSource.Agent.setMetaData("AppLovin_AgeRestrictedUser", "false");
        IronSource.Agent.setMetaData("Chartboost_Coppa", "false");
        IronSource.Agent.setMetaData("Chartboost_Coppa", "false");
        IronSource.Agent.setMetaData("UnityAds_coppa", "false");
    }

    private void EnableLog()
    {
        IronSource.Agent.setAdaptersDebug(true);
        IronSource.Agent.setAdaptersDebug(true);
    }

#endregion
}
