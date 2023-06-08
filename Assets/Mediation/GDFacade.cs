using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GDFacade : MonoBehaviour
{

    public IInterstatialAdManager _interstatialAdManager;
    public IBannerAdManager _bannerAdManager;
    public IRewardedAdManager _rewardedAdManager;

    //[SerializeField] private string _key;
    private bool _isCreated = false;
#if EN_GDAD
    [SerializeField] private GameDistribution _gameDistribution;
#endif

#if GAME_MONOTIZE
    [SerializeField] private GameMonetize _gameMonetize;
#endif

#if LAGGED
    [SerializeField] private LaggedAPIUnity _laggedAPIUnity;
#endif

#if YANDEX_GAMES
    [SerializeField] private YandexSDK _yandexSDK;
#endif
    public void Init()
    {
        Debug.Log("Facade Init 1");

#if GAME_MONOTIZE
        _gameMonetize.Init();

        _rewardedAdManager = new GameMonatizeRewardedAdManager();
        _interstatialAdManager = new GameMonatizeInterstatialAdManager();
        _bannerAdManager = new GameMonotizeBannerAdManager();

        return;
#endif
#if CRAZY_GSDK
        _rewardedAdManager = new CrazyGamesRewardedAdManager();
        _interstatialAdManager = new CrazyGamesInterstitialAdManager();
        _bannerAdManager = new CrazyGamesBannerAdManager();

        return;
#endif

#if EN_GDAD
        //GameObject _gameDist = new GameObject("GameDist");
        //var  _gameDistribution = _gameDist.AddComponent<GameDistribution>();
        //_gameDistribution.GAME_KEY = _key;
        //Debug.Log("Facade Init");
        //        if( _isCreated == false )
        //        {
        //            var gd = Instantiate(_gameDistribution);
        //            _isCreated = true;
        //            gd.Init();
        //        }
        //;
        _gameDistribution.Init();

        _rewardedAdManager = new GameDistrubutionRewardedAdManager();
        _interstatialAdManager = new GameDistrubutionInterstatialAdManager();
        _bannerAdManager = new GameDistrubutionBannerAdManager();
#endif

#if LAGGED
        _laggedAPIUnity.Init();

        _rewardedAdManager = new LaggedRewardedAdManager();
        _interstatialAdManager = new LaggedInterstatialAdManager();
        _bannerAdManager = new LaggedBannerAdManager();

        return;
#endif

#if YANDEX_GAMES
        _yandexSDK.Init();

        _rewardedAdManager = new YandexRewardedAdManager();
        _interstatialAdManager = new YandexInterstatialAdManager();
        _bannerAdManager = new YandexBannerAdManager();
#endif
    }

}
