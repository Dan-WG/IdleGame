using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Idle
{
    [CreateAssetMenu(fileName = "Admob Config", menuName = "Admob/Admob Config")]
    public class AdmobConfig : ScriptableObject
    {

        [Header("App ID")]
        [Tooltip("You can find your app's App ID in the AdMob UI.")]
        public string appId = "ca-app-pub-3940256099942544~3347511713";

        [Header("Banner ID")]
        public string bannerViewID = "ca-app-pub-3940256099942544~3347511713";

        [Header("Interstitial ID")]
        public string interstitialID = "ca-app-pub-3940256099942544/1033173712";

        [Header("Reward ID")]
        public string rewardBasedVideoID = "ca-app-pub-3940256099942544~3347511713";

    }
}
