using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAdScript : MonoBehaviour , IUnityAdsListener
{

    string gameId = "4068245";
    bool testMode = true;

    Button myButton;
    public string mySurfacingId = "rewardedVideo";
    
    void Start () {

        Advertisement.Initialize(gameId, testMode);
    }

    
    public void ShowRewardedVideo () {
        Advertisement.Show (mySurfacingId);
    }
    
    public void ShowInterstitialAd() 
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady()) {
            Advertisement.Show();
        } 
        else {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, activate the button: 
        if (surfacingId == mySurfacingId) {        
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("user started watching Ad");
    }

    public void OnUnityAdsDidFinish (string surfacingId, ShowResult showResult) {
    
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }
}
