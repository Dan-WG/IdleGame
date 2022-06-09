using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Idle
{
    public sealed class GameManager : MonoBehaviour
    {
        //The method is invoked by tapping the screen
        public void Click()
        {
            DataManager.data.Money += DataManager.data.MoneyByClick; //add money by tap
            StartCoroutine(CameraShake.Shake(Camera.main.transform, 0.1f, 0.01f));  //play the effect of shaking
            Managers.Instance.particleManager.PlayEffect(Managers.Instance.particleManager.clickEffect);  //play the particle effect
            Managers.Instance.uIManager.UpdateUI(); //Updating UI
            Managers.Instance.audioManager.PlaySound(Managers.Instance.audioManager.Coin);//play sound
        }

        //Method to start the game
        public void StartGame()
        {
            Managers.Instance.uIManager.ChangeScreen("GameScreen");
            StartCoroutine(MoneyPerSecond());
        }
        //Method to pause
        public void Pause()
        {
            Managers.Instance.uIManager.ChangeScreen("PauseMenu");
        }

        //Mthhod call ads from AdmobManager
        public void ShowRewardAd()
        {
            AdmobManager.instance.ShowBanner(); //An example of calling a banner from a script
           // AdmobManager.instance.HideBanner(); //Hide banner


            AdmobManager.instance.ShowInterstitial();// An example of calling a Interstitial from a script

            AdmobManager.instance.rewardCount = 10; //Set reward value
            AdmobManager.instance.ShowReward(); //Call the video
        }

        //The loop of adding money per second
        IEnumerator MoneyPerSecond()
        {
            yield return new WaitForSeconds(1); //WaitForSeconds(HERE HOW MANY SECONDS WAIT)

            DataManager.data.Money += DataManager.data.MoneyPerSecond;  //add money by second
            Managers.Instance.uIManager.UpdateUI();  //Updating UI
            DataManager.SaveData();  //Save data
            StartCoroutine(MoneyPerSecond());   //Repeat loop
        }
    }
}