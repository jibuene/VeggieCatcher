using System;
using UnityEngine;
using GoogleMobileAds.Api;
public class AddAds : MonoBehaviour
{
    private BannerView bannerView;

    public void Start()
    {
        this.RequestBanner();
    }

    private void RequestBanner()
    {

        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-5661017804148591/8223487291";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-5661017804148591/8223487291";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
// {
//     private BannerView bannerView;
//     public void Start()
//     {
//         // Initialize the Google Mobile Ads SDK.
//         MobileAds.Initialize(initStatus => { });

//         this.RequestBanner();
//     }

//     private void RequestBanner()
//     {
//         #if UNITY_ANDROID
//             string adUnitId = "ca-app-pub-3940256099942544/6300978111";
//         #elif UNITY_IPHONE
//             string adUnitId = "ca-app-pub-3940256099942544/6300978111";
//         #else
//             string adUnitId = "unexpected_platform";
//         #endif

//         // Create a 320x50 banner at the top of the screen.
//         AdSize adaptiveSize =
//                 AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

//         this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Top);

//         // Create an empty ad request.
//         AdRequest request = new AdRequest.Builder().Build();

//         // Load the banner with the request.
//         this.bannerView.LoadAd(request);

//     }
// }