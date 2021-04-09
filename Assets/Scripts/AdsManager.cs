using System;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour {

    private static readonly string AND_BANNER_ID = "ca-app-pub-7832687788012663/7385592239";
    private static readonly string AND_INTERSTITIAL_ID = "ca-app-pub-7832687788012663/5661107718";

    private static readonly string iOS_BANNER_ID = "ca-app-pub-7832687788012663/6504877560";
    private static readonly string iOS_INTERSTITIAL_ID = "ca-app-pub-7832687788012663/1679720432";

    public static AdsManager init = null;

    private void Awake() {
        if (init == null) {
            init = this;
        } else if (init != this) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    public void Start() {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => {
        });

        RequestBannerAd();
        RquestInterstitialAd();
    }

    private void RequestBannerAd() {
        if (!IAPManager.init.isPremium) {
#if UNITY_ANDROID
            string adUnitId = AND_BANNER_ID;
#elif UNITY_IPHONE
            string adUnitId = iOS_BANNER_ID;
#else
            string adUnitId = "unexpected_platform";
#endif

            if(bannerView != null) {
                bannerView.Destroy();
            }

            this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;

            this.bannerView.LoadAd(CreateAdRequest());
        }
    }

    private AdRequest CreateAdRequest() {
        return new AdRequest.Builder().Build();
    }

    private void RquestInterstitialAd() {
#if UNITY_ANDROID
        string adUnitId = AND_INTERSTITIAL_ID;
#elif UNITY_IPHONE
        string adUnitId = iOS_INTERSTITIAL_ID;
#else
        string adUnitId = "unexpected_platform";
#endif
        if (interstitialAd != null) {
            interstitialAd.Destroy();
        }

        this.interstitialAd = new InterstitialAd(adUnitId);

        this.interstitialAd.OnAdClosed += this.HandleOnAdClosed;
        this.interstitialAd.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;

        this.interstitialAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd() {
        if (interstitialAd.IsLoaded() && !IAPManager.init.isPremium) {
            interstitialAd.Show();
        }
    }

    public void HandleOnAdClosed(object sender, EventArgs args) {
        RquestInterstitialAd();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
        Debug.Log($"{sender.ToString()} loaded is fail : {args.Message}");
    }

    public void DestroyBannerAd() {
        try {
            this.bannerView.Destroy();
        } catch (Exception e) {
            Debug.Log(e.StackTrace);
        }
    }
}

