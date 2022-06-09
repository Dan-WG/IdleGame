using UnityEngine;
using GoogleMobileAds.Api;

namespace Idle
{
    public class AdmobManager : MonoBehaviour
    {
        public enum BannerPosition { Top, Bottom } //Numerator for position of banner

        private BannerView bannerView;
        private RewardBasedVideoAd rewardBasedVideo;

        public static AdmobManager instance; //Singletop

        [Header("Your Admob config")]
        public AdmobConfig admobConfig;

        [Header("Banner settings")]
        [SerializeField] private bool showBannerOnAwake; //Flag to check the need to display a banner at startup
        [SerializeField] private BannerPosition bannerPosition; //Position of banner

        [Header("Reward settings")]
        public long rewardCount; //You can edit this from any scripts 

        private void Awake()
        {
            instance = this;
        }

        public void Start()
        {
            Init();
        }

        void Init()
        {
            MobileAds.Initialize(admobConfig.appId);

            this.rewardBasedVideo = RewardBasedVideoAd.Instance;//Load RewardVideo 

            rewardBasedVideo.LoadAd(new AdRequest.Builder().Build(), admobConfig.rewardBasedVideoID);

            rewardBasedVideo.OnAdRewarded += onRewardedVideoEvent;

            if (showBannerOnAwake) //if bool is true it show Banner after admob init 
            {
                ShowBanner();
            }
        }

        #region // Show methods
        public void ShowBanner()
        {
            switch (bannerPosition)//check selected banner position
            {
                case BannerPosition.Top:
                    bannerView = new BannerView(admobConfig.bannerViewID, AdSize.Banner, AdPosition.Top); //show banner
                    break;
                case BannerPosition.Bottom:
                    bannerView = new BannerView(admobConfig.bannerViewID, AdSize.Banner, AdPosition.Bottom);
                    break;
            }

            bannerView.LoadAd(new AdRequest.Builder().Build());

            bannerView.Show();
        }
        public void HideBanner()
        {
            bannerView.Hide();
        }

        public void ShowInterstitial()
        {
            InterstitialAd interstitial = new InterstitialAd(admobConfig.interstitialID);
            interstitial.LoadAd(new AdRequest.Builder().Build());

            if (interstitial.IsLoaded()) //if isInterstitial loaded it show
            {
                interstitial.Show();
            }
            else
            {
                interstitial = new InterstitialAd(admobConfig.interstitialID); //Load Interstitial 
            }
        }

        public void ShowReward()
        {
            if (rewardBasedVideo.IsLoaded())//if reward loaded it show
            {
                rewardBasedVideo.Show();//show method
            }

        }
        #endregion


        #region // Events
        void onRewardedVideoEvent(object sender, Reward args)
        {
            //Reward
            DataManager.data.Money += rewardCount;
            DataManager.SaveData();
        }

        #endregion


    }
}