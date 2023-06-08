using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FakeAgentCanvas : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject _bannerFrame;
    [SerializeField] private GameObject _fullScreenFrame;
    [SerializeField] private Image _fullScreenImage;
    [SerializeField] private Button _closeButton;
    [SerializeField] private TextMeshProUGUI _countDownText;
    [SerializeField] private BannerData _bannerData;
    [SerializeField] private FullScreenData _fullScreenData;
    private Tween _countDownTween;
    private AdEnum _currentAdEnum = AdEnum.Default;
    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    #region FullScreenMethods

    [NaughtyAttributes.Button]
    public void ShowInterstatialAd()
    {
        FakeInterstatialEvents.OnInterstatialAdOpened?.Invoke(null);
        _currentAdEnum = AdEnum.Interstatial;
        ShowAd();
    }

    [NaughtyAttributes.Button]
    public void ShowRewardedAd()
    {
        FakeRewardedEvents.ORewardednAdOpenedEvent?.Invoke(null);
        _currentAdEnum = AdEnum.Rewarded;
        ShowAd();
    }

    private void ShowAd()
    {
        _fullScreenFrame.SetActive(true);
        _fullScreenImage.sprite = _fullScreenData.SpriteList.GetRandomElement();

        int x = 0;

        _countDownTween = DOTween.To(() => x, newValue => x = newValue, _fullScreenData.Duration, _fullScreenData.Duration).OnUpdate(DoCountdown).OnComplete(OpenCloseAdButton).SetUpdate(true);

        void DoCountdown()
        {
            var value = _fullScreenData.Duration - x;

            _countDownText.text = value.ToString();
        }

        void OpenCloseAdButton()
        {
            if(_currentAdEnum == AdEnum.Rewarded)
            {
                FakeRewardedEvents.OnAdRewardedUserEvent?.Invoke(null, null);
            }

            _countDownText.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(true);
        }
    }

    public void CloseAd()
    {
        _fullScreenFrame.gameObject.SetActive(false);
        _closeButton.gameObject.SetActive(false);
        _countDownText.gameObject.SetActive(true);

        if(_countDownTween != null)
        {
            _countDownTween.Kill();
            _countDownTween = null;
        }

        if(_currentAdEnum == AdEnum.Interstatial)
        {
            FakeInterstatialEvents.OnInterstatialAdClosed?.Invoke(null);
        }
        else if(_currentAdEnum == AdEnum.Rewarded)
        {
            FakeRewardedEvents.OnRewardedAdClosedEvent?.Invoke(null);
        }
    }
    #endregion

    #region BannerMethods
    [NaughtyAttributes.Button]
    public void HideBanner()
    {
        _bannerData._bannerImage.enabled = false;
        _bannerData._bannerText.enabled = false;
    }

    [NaughtyAttributes.Button]
    public void DisplayBanner()
    {
        _bannerData._bannerImage.enabled = true;
        _bannerData._bannerText.enabled = true;
    }

    public void CreateBanner(IronSourceBannerSize size, IronSourceBannerPosition position, string placementName = default)
    {
        float bannerHeight = _bannerData._bannerImage.rectTransform.rect.height;
        float canvasHeight =  GetComponent<CanvasScaler>().referenceResolution.y;

        float x = 0;
        float y = 0;
        if(position == IronSourceBannerPosition.BOTTOM)
        {
            y = -(canvasHeight /2) + (bannerHeight / 2);
            
        }
        else
        {
            y = (canvasHeight / 2) - (bannerHeight / 2);
        }

        _bannerData._bannerImage.sprite = _bannerData.SpriteList.GetRandomElement();
        _bannerData._bannerImage.rectTransform.anchoredPosition = new Vector2(x, y);
        _bannerFrame.SetActive(true);
        float v = 0f;
        DOTween.To(() => v, newValue => v = newValue, 1, _bannerData.RefreshTime).SetLoops(-1, LoopType.Restart).OnStepComplete(RefreshBanner);
    }

    [NaughtyAttributes.Button("CreateBanner")]
    private void Test()
    {
        CreateBanner(null, IronSourceBannerPosition.BOTTOM);
    }

    public void RefreshBanner()
    {
        _bannerData._bannerImage.sprite = _bannerData.SpriteList.GetRandomElement();
    }

    [NaughtyAttributes.Button]
    public void DestroyBanner()
    {
        _bannerFrame.SetActive(false);
    }

    #endregion

    #region Datas
    [System.Serializable]
    public class BannerData
    {
        [field:SerializeField] public TextMeshProUGUI _bannerText { get; private set; }
        [field: SerializeField] public Image _bannerImage { get; private set; }
        [field : SerializeField] public int RefreshTime { get; private set; }
        [field : SerializeField] public Sprite[] SpriteList { get; private set; }
    }

    [System.Serializable] 
    public class FullScreenData
    {
        [field: SerializeField] public Sprite[] SpriteList { get; private set; }
        [field: SerializeField] public int Duration { get; private set; }
    }
    #endregion

    #region AdEnum
    private enum AdEnum
    {
        Default,
        Interstatial,
        Rewarded
    }
    #endregion
}
