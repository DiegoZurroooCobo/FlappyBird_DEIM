using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplayManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    public static AdDisplayManager instance;
    public string unityAdsID;
    public int androidID, appleID;
    public bool testmode = false;
    public string adType = "Interstitial_Android";

    public void OnUnityAdsAdLoaded(string placementId) // cuando se carga el anuncio 
    {
        Advertisement.Show(adType, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("holaaaaaaaaaaaaaaa" + message);
    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        GameManager.instance.LoadScene("Menu");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {

    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnInitializationComplete()
    {

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {

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
        if(!Advertisement.isInitialized)  // si los anuncios no se han iniciado 
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR || UNITY_ANDROID 
            Advertisement.Initialize(androidID.ToString(), testmode, this); // se inician en 

#elif UNITY_IOS
            Advertisement.Initialize(appleID.ToString(), testMode, this);

#endif
        }
    }

    public void ShowAd() // metodo para mostrar los anuncios 
    { 
        if(Advertisement.isInitialized) 
        {
            Advertisement.Load(adType, this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
