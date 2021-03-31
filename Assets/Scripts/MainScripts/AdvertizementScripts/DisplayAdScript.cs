using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
public class DisplayAdScript : MonoBehaviour,IUnityAdsListener
{
    private string playStoreID = "4068245";
    private string appleStoreID = "4068244";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "Rewarded_Android";

    public bool isTargetPlayStore;
    public bool isTestAd;

    public PlayerModel playerModel;
    public int NutsAndBoltsRewardAmount;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();


    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }

        Advertisement.Initialize(appleStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }

        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }

        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                if(placementId == interstitialAd){Debug.Log("Skipped interstitial");}
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("Reward the player");
                    playerModel.NutsBolts += NutsAndBoltsRewardAmount;

                }
                if(placementId == interstitialAd){Debug.Log("Finished interstitial");}
                break;
        }
    }
}