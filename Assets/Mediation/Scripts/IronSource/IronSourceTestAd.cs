using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IronSourceTestAd : MonoBehaviour
{
    [SerializeField] private AdManager _adManager;
    [SerializeField] private Button _rewardedAdButton;
    [SerializeField] private Button _intersatialAdButton;
    [SerializeField] private Button _restartButton;
    private void Awake()
    {
        _adManager.OnBeforeLoadingAds += OnBeforeLoadingAds;
        _adManager.Init();
        _restartButton.onClick.AddListener(() => { SceneManager.LoadScene(0); });
    }


    
    public void TestLoadRewarded()
    {
        IronSource.Agent.loadRewardedVideo();
    }

    public void TestShowLoadRewardedVideo()
    {
        IronSource.Agent.showRewardedVideo();
    }

    private void OnBeforeLoadingAds()
    {
        //INTERSTATIAL
        Debug.Log("Registering Interstatial from TestClass");
        _adManager.InterstatialAdManager.RegisterOnAdReadyEvent(OnInterstatialAdReady);
        _adManager.InterstatialAdManager.RegisterOnAdClickedEvent(OnInterstatialAdClickedEvent);
        _adManager.InterstatialAdManager.RegisterOnAdClosedEvent(OnInterstatialAdCLosed);
        _adManager.InterstatialAdManager.RegisterOnAdLoadFailedEvent(OnInterstatialLoadFailed);
        _adManager.InterstatialAdManager.RegisterOnAdOpenedEvent(OnInterstatialAdOpened);
        _adManager.InterstatialAdManager.RegisterOnAdShowFailedEvent(OnInterstatialAdFailedToShow);
        _adManager.InterstatialAdManager.RegisterOnAdShowSucceededEvent(OnInterstatialAdShowSucceed);

        //REWARDED
        Debug.Log("Registering Rewareded from TestClass");
        _adManager.RewardedAdManager.RegisterOnAdReadyEvent(OnRewarededAdReady);
        _adManager.RewardedAdManager.RegisterOnAdUnavailableEvent(OnRewardedAdUnAvailable);
        _adManager.RewardedAdManager.RegisterOnAdClickedEvent(OnRewardedAdClicked);
        _adManager.RewardedAdManager.RegisteOnAdAvailableEvent(OnRewardedAdAvailable);
        _adManager.RewardedAdManager.RegisterOnAdOpenedEvent(OnRewardedAdOpened);
        _adManager.RewardedAdManager.RegisterOnAdClosedEvent(OnRewardedAdClosed);
        _adManager.RewardedAdManager.RegisterOnAdLoadFailedEvent(OnRewarededAdFailedToLoad);
        _adManager.RewardedAdManager.RegisterOnAdShowFailedEvent(OnRewarededAdFailedToShow);
        _adManager.RewardedAdManager.RegisterOnUserEarnedRewarededEvent(OnUserEarnedReward);

        StartCoroutine(SetRewardedAdReady());
    }

    public void OnClickRewardedAdButton()
    {
        Debug.Log("Clicked Rewarded");

        if (_adManager.RewardedAdManager.IsRewardedAdReady())
        {
            Debug.Log("Clicked Rewarded and its ready");
            _adManager.RewardedAdManager.ShowAd();
        }
    }

    private IEnumerator SetRewardedAdReady()
    {
        while(!_adManager.RewardedAdManager.IsRewardedAdReady())
        {
            yield return null;
        }

        _rewardedAdButton.interactable = true;
    }

    public void OnCilickInterstatialAdButton()
    {
        Debug.Log("Clicked Interstatial");

        if (_adManager.InterstatialAdManager.IsInterstatialAdReady())
        {
            Debug.Log("Clicked Interstatial and its ready");
            _adManager.InterstatialAdManager.ShowAd();
        }
    }

    #region INTERSTATIAL

    private void OnInterstatialAdReady(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Interstatial ad is ready from the network  : " + info.adNetwork);
        _intersatialAdButton.interactable = true;
    }

    private void OnInterstatialAdClickedEvent(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Interstatial ad is clicked from the network  : " + info.adNetwork);
    }

    private void OnInterstatialAdCLosed(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Interstatial ad is closed from the network  : " + info.adNetwork);
    }

    private void OnInterstatialLoadFailed(IronSourceError error)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Interstatial ad has failed to load, the error is  : " + error.getErrorCode());
    }

    private void OnInterstatialAdOpened(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Interstatial ad is opened from the network  : " + info.adNetwork);
    }

    private void OnInterstatialAdFailedToShow(IronSourceError error, IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Interstatial ad has failed to show from the network  : " + info.adNetwork + " with the error code : " + error.getCode());
    }

    private void OnInterstatialAdShowSucceed(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Interstatial ad has shown succeed from the network  : " + info.adNetwork);
    }

    #endregion
    //REWARDED

    #region REWARDED
    private void OnRewarededAdReady(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad is ready from the network  : " + info.adNetwork);
        _rewardedAdButton.interactable = true;
    }

    private void OnRewardedAdUnAvailable()
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad is not available right now");
    }

    private void OnRewardedAdClicked(IronSourcePlacement placement, IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad is clicked from the ad network : " + info.adNetwork + " Rewarded amount : " + placement.getRewardAmount() +" Rewarded placement name:" +placement.getPlacementName());
    }

    private void OnRewardedAdAvailable(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad is available from the ad network : " + info.adNetwork);
        _rewardedAdButton.interactable = true;

    }

    private void OnRewardedAdOpened(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad has opened from the ad network : " + info.adNetwork);
    }

    private void OnRewardedAdClosed(IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad has closed from the ad network : " + info.adNetwork);
    }

    private void OnRewarededAdFailedToLoad(IronSourceError error)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad has failed to load with error code  : " + error.getErrorCode());

    }

    private void OnRewarededAdFailedToShow(IronSourceError error, IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("Rewarded ad has failed to show with error code  : " + error.getErrorCode() + " from ad network : " + info.adNetwork);
    }

    private void OnUserEarnedReward(IronSourcePlacement placement, IronSourceAdInfo info)
    {
        Debug.Log("From Test Ad");
        Debug.Log("User earned reward from ad network : " +info.adNetwork + " with reward amount :" + placement.getRewardAmount() + " with the placement name :  " +placement.getPlacementName());
    }
    #endregion
}