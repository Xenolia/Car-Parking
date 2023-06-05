using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeAgent : IronSourceIAgent
{
    private bool _isInterstatialLoaded = false;
    private bool _isRewardedLoaded = false;
    private float _lastTimeScale;

    private static FakeAgentCanvas _fakeAgentCanvas;

    public FakeAgentCanvas FakeAgentCanvas => _fakeAgentCanvas;
    public FakeAgent()
    {
        if (_fakeAgentCanvas != null) return;

        var canvas = Resources.Load<FakeAgentCanvas>("FakeAgentCanvas");

        _fakeAgentCanvas = GameObject.Instantiate(canvas);
    }

    public void clearRewardedVideoServerParams()
    {
        
    }

    public void destroyBanner()
    {
        _fakeAgentCanvas.DestroyBanner();
    }

    public void displayBanner()
    {
        _fakeAgentCanvas.DisplayBanner();
    }

    public string getAdvertiserId()
    {
        return "Fake Agent has no id";
    }

    public int? getConversionValue()
    {
        return 0;
    }

    public void getOfferwallCredits()
    {
      
    }

    public IronSourcePlacement getPlacementInfo(string name)
    {
        throw new System.NotImplementedException();
    }

    public void hideBanner()
    {
        _fakeAgentCanvas.HideBanner();
    }

    public void init(string appKey)
    {
        Debug.Log("Fake Agent doesnt need any application key");
    }

    public void init(string appKey, params string[] adUnits)
    {
        Debug.Log("Fake agent doesnt need any app key");
    }

    public void initISDemandOnly(string appKey, params string[] adUnits)
    {
        Debug.Log("Fake agent doesnt need any app key");

    }

    public bool isBannerPlacementCapped(string placementName)
    {
        return true;
    }

    public bool isInterstitialPlacementCapped(string placementName)
    {
        return true;
    }

    public bool isInterstitialReady()
    {
       return true;
    }

    public bool isISDemandOnlyInterstitialReady(string instanceId)
    {
        return true;
    }

    public bool isISDemandOnlyRewardedVideoAvailable(string instanceId)
    {
        return true;
    }

    public bool isOfferwallAvailable()
    {
        return true;
    }

    public bool isRewardedVideoAvailable()
    {
        return true;
    }

    public bool isRewardedVideoPlacementCapped(string placementName)
    {
        return true;
    }

    public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position)
    {
        _fakeAgentCanvas.CreateBanner(size, position);
    }

    public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position, string placementName)
    {
        _fakeAgentCanvas.CreateBanner(size, position);
    }

    public void loadConsentViewWithType(string consentViewType)
    {
        
    }

    public void loadInterstitial()
    {
        _isInterstatialLoaded = true;
    }

    public void loadISDemandOnlyInterstitial(string instanceId)
    {
        
    }

    public void loadISDemandOnlyRewardedVideo(string instanceId)
    {
        
    }

    public void loadRewardedVideo()
    {
        _isRewardedLoaded = true;        
    }

    public void onApplicationPause(bool pause)
    {
        if(pause)
        {
            _lastTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void setAdaptersDebug(bool enabled)
    {
       
    }

    public void setAdRevenueData(string dataSource, Dictionary<string, string> impressionData)
    {
        
    }

    public void setConsent(bool consent)
    {

    }

    public bool setDynamicUserId(string dynamicUserId)
    {
        return true;
    }

    public void setManualLoadRewardedVideo(bool isOn)
    {
        
    }

    public void setMediationSegment(string segment)
    {
        
    }

    public void setMetaData(string key, string value)
    {
 
    }

    public void setMetaData(string key, params string[] values)
    {

    }

    public void setNetworkData(string networkKey, string networkData)
    {

    }

    public void SetPauseGame(bool pause)
    {
        if (pause)
        {
            _lastTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void setRewardedVideoServerParams(Dictionary<string, string> parameters)
    {

    }

    public void setSegment(IronSourceSegment segment)
    {
  
    }

    public void setUserId(string userId)
    {
     
    }

    public void shouldTrackNetworkState(bool track)
    {
    
    }

    public void showConsentViewWithType(string consentViewType)
    {
 
    }

    public void showInterstitial()
    {
        if(_isInterstatialLoaded)
        {
            _isInterstatialLoaded = false;
            _fakeAgentCanvas.ShowInterstatialAd();
        }
    }

    public void showInterstitial(string placementName)
    {
        if (_isInterstatialLoaded)
        {
            _isInterstatialLoaded = false;
            _fakeAgentCanvas.ShowInterstatialAd();

        }
    }

    public void showISDemandOnlyInterstitial(string instanceId)
    {
        if (_isInterstatialLoaded)
        {
            _isInterstatialLoaded = false;
            _fakeAgentCanvas.ShowInterstatialAd();

        }
    }

    public void showISDemandOnlyRewardedVideo(string instanceId)
    {
        if (_isRewardedLoaded)
        {
            _isRewardedLoaded = false;
            _fakeAgentCanvas.ShowRewardedAd();
        }
    }

    public void showOfferwall()
    {
     
    }

    public void showOfferwall(string placementName)
    {
 
    }

    public void showRewardedVideo()
    {
        if (_isRewardedLoaded)
        {
            _isRewardedLoaded = false;
            _fakeAgentCanvas.ShowRewardedAd();
        }
    }

    public void showRewardedVideo(string placementName)
    {
        if (_isRewardedLoaded)
        {
            _isRewardedLoaded = false;
            _fakeAgentCanvas.ShowRewardedAd();
        }
    }

    public void validateIntegration()
    {
        Debug.Log("Fake agent complated the validation");
    }

    public void launchTestSuite()
    {
        throw new System.NotImplementedException();
    }
}

public static class Extension
{
    public static T GetRandomElement<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

    public static T GetRandomElement<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static Queue<T> ConverToQueue<T>(this List<T> list)
    {
        Queue<T> queue = new Queue<T>();

        foreach (var element in list)
        {
            queue.Enqueue(element);
        }

        return queue;
    }
    public static Queue<T> ConverToQueue<T>(this T[] array)
    {
        Queue<T> queue = new Queue<T>();

        foreach (var element in array)
        {
            queue.Enqueue(element);
        }

        return queue;
    }
}