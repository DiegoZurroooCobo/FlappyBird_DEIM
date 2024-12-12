using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplayManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdDisplayManager instance;
    public string unityAdsID;
    public int androidID, appleID;
    public bool testmode = false;
    public string adType = "Banner_Android";

    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        GameManager.instance.LoadScene("Menu");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        if(!instance) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!Advertisement.isInitialized) 
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR || UNITY_ANDROID
            Advertisement.Initialize(androidID.ToString(), testmode);
#elif UNITY_IOS
            Advertisement.Initialize(appleID);
#endif
        }
    }

    public void ShowAd() 
    { 
        if(Advertisement.isInitialized) 
        {
            Advertisement.Load(adType);
            Advertisement.Show(adType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
