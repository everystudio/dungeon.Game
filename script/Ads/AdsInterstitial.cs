using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsInterstential : MonoBehaviour {
#if UNITY_EDITOR
	string adUnitId1 = "unused";
#elif UNITY_ANDROID
    string adUnitId1 = "ca-app-pub-5869235725006697/4481993169";
#elif UNITY_IPHONE
    string adUnitId1 = "ca-app-pub-5869235725006697/5958726364";
#else
    string adUnitId1 = "unexpected_platform";
#endif
	InterstitialAd interstitial;
	private AdRequest request;
	// Use this for initialization
	void Start () {
		interstitial = new InterstitialAd(adUnitId1);

		request = new AdRequest.Builder().Build();
		interstitial.LoadAd(request);

		interstitial.OnAdClosed += HandleAdClosed;
	}

	// インタースティシャル広告を閉じた時に走る
	void HandleAdClosed(object sender, System.EventArgs e)
	{
	}
	// Update is called once per frame
	void Update () {
		
	}
}
