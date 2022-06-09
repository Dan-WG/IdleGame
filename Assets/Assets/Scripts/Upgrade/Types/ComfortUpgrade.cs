using UnityEngine;

namespace Idle
{
    public class ComfortUpgrade : Upgrade
    {
        [Header("Scene GameObjects")]
        public GameObject[] comfortObjects;

        private void Start()
        {
            UpdateObjects();
        }
        //Base method is responsible for the purchase of the upgrade
        public override void UpgradeItem(int id)
        {
            base.UpgradeItem(id);
            if (!priced)
                return;

            /////////////////////////////////////////////// #Start
            //This is where the logic of the action is written, provided that we have purchased

            DataManager.upgradeData.comfortLvl++;

            UpdateObjects();

            /////////////////////////////////////////////// #End

            Upgraded();//The method is responsible for the successful purchase, makes saving
        }

        //Method to check the level and include available objects
        void UpdateObjects()
        {
            //Loop to include objects by level
            for (int i = 0; i < DataManager.upgradeData.comfortLvl; i++)
            {
                comfortObjects[i].SetActive(true);

                //if objects were purchased from them, the UI is turned off
                Items[i].buyBtn.interactable = false;
                Items[i].priceImage.enabled = false;
                Items[i].priceText.enabled = false;
            }
        }

    }
}
