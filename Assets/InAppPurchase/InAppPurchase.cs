using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InAppPurchase : MonoBehaviour
{
    private Dictionary<StoreProduct, bool> _productToBooleanMap = new Dictionary<StoreProduct, bool>();
    [SerializeField] private List<string> _shopProductNameList;
    [SerializeField] private Button _restoreButton;
    public Action RemoveAds;
    private int _adRemove;

    private IOpenedItemContainer _openedItemContainer;

    public IOpenedItemContainer OpenedItemContainer => _openedItemContainer;
    public void Init()
    {
#if !UNITY_WEBGL
       // _restoreButton.gameObject.SetActive(false);

        _openedItemContainer = new MarketItemChecker();
        _adRemove = PlayerPrefs.GetInt("NoAds");
        SetNames();
        IAPManager.Instance.InitializeIAPManager(InitializeResultCallback);
#endif
    }

    private void InitializeResultCallback(IAPOperationStatus status, string message, List<StoreProduct> shopProducts)
    {
        if (status == IAPOperationStatus.Success)
        {
            var restoreDone = PlayerPrefs.GetInt("RestoreDone");
#if UNITY_IOS
            if (restoreDone == 0)
            {
                _restoreButton.gameObject.SetActive(true);
            }
#endif
            //IAP was successfully initialized
            //loop through all products
            for (int i = 0; i < shopProducts.Count; i++)
            {
                if (shopProducts[i].productName == _shopProductNameList[i])
                {
                    //if active variable is true, means that user had bought that product
                    //so enable access
                    Debug.Log("Product found");
                    if (shopProducts[i].active)
                    {
                        _productToBooleanMap.Add(shopProducts[i], true);

                        if (shopProducts[i].productName == ShopProductNames.RemoveAds.ToString())
                        {
                            PlayerPrefs.SetInt("NoAds", 1);

                            if (_adRemove == 0)
                            {
#if UNITY_ANDROID
                                RemoveAds?.Invoke();
#endif

                            }
                        }
                        else
                        {
#if UNITY_ANDROID
                            _openedItemContainer.Execute(shopProducts[i].productName);
#endif
                        }
                    }


                }
            }
        }
        else
        {
            // Debug.Log(“Error occurred ”+message);
            Debug.Log("Error in app");
        }
    }

    [NaughtyAttributes.Button]
    public void SetNames()
    {
        _shopProductNameList.Clear();

        var enumValues = Enum.GetValues(typeof(ShopProductNames));

        foreach (ShopProductNames productEnum in enumValues)
        {
            _shopProductNameList.Add(productEnum.ToString());
        }
    }


    public void RemoveAd()
    {
        //This method will be called when adds are removed;
        RemoveAds?.Invoke();
    }

    public void Restore()
    {
        IAPManager.Instance.RestorePurchases(RestoreCallback, RestoreDone);
    }

    private void RestoreCallback(IAPOperationStatus status, string message, StoreProduct product)
    {
        if (status == IAPOperationStatus.Success)
        {
            //consumable products are not restored
            //non consumable Unlock Level 1 -> unlocks level 1 so we set the corresponding bool to true
            if (product.productName == ShopProductNames.RemoveAds.ToString())
            {
                RemoveAds?.Invoke();
            }
            else
            {
                _openedItemContainer.Execute(product.productName);
            }

            //subscription has been bought so we set our subscription variable to true


        }
        else
        {
            //an error occurred in the buy process, log the message for more details
            Debug.Log("Buy product failed: " + message);

           // _restoreButton.gameObject.SetActive(false);
        }

    }

    private void RestoreDone()
    {
        PlayerPrefs.SetInt("RestoreDone", 1);
        RemoveAds?.Invoke();
    }
}
    public interface IOpenedItemContainer
    {
        void Execute(string productName);
        void RegisterEvent(Action method, string name);
    }

    public class MarketItemChecker : IOpenedItemContainer
    {
        public Action OnGunUnlock;

        public MarketItemChecker()
        {
            OnGunUnlock += Empty;
        }

        private void Empty() { }

        public void Execute(string productName)
        {
            if (productName == "unlockguntestname")
            {
                OnGunUnlock?.Invoke();
            }
        }

        public void RegisterEvent(Action method, string name)
        {
            if (name == "unlockguntestname")
            {
                OnGunUnlock += method;
            }
        }
    }
