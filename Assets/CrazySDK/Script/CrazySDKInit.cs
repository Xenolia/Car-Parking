using UnityEngine;

#if CRAZY_GSDK
namespace CrazyGames
{
    class CrazySDKInit
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnRuntimeMethodLoad()
        {
            CrazySDK.ResetDomain();
            CrazyAds.ResetDomain();
            CrazyEvents.ResetDomain();
            
            var sdk = CrazySDK.Instance; // Trigger init by calling instance
        }
    }
}

#endif