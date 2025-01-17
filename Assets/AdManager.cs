using CrazyGames;
using UnityEngine;
using System;
 
public class AdManager : MonoBehaviour
{
    Action callBack;
  public  bool sdkinitsucces=false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        callBack = OnSDKInitiliazed;
        Init();
    } 
    public void ShowRewarded()
    {
        CrazySDK.Ad.RequestAd(CrazyAdType.Rewarded, () =>
        {
            /** ad started */
        }, (error) =>
        {
            /** ad error */
        }, () =>
        {
            /** ad finished, rewarded players here for CrazyAdType.Rewarded */
        });
    }
    public void Init()
    {
        CrazySDK.Init(callBack);
    }
    void OnSDKInitiliazed()
    {
       sdkinitsucces = true;
    }
}
