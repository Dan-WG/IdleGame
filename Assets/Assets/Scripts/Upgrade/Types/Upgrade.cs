using System.Collections.Generic;
using UnityEngine;

namespace Idle
{
    public class Upgrade : MonoBehaviour
    {
        [Header("Components")]
        [HideInInspector] public Item[] Items;
        [SerializeField] private Transform itemsParent;
        protected bool priced;

        private void Awake()
        {
            InitItems();
        }

        //Initialization of upgrade items
        private void InitItems()
        {
            Items = itemsParent.GetComponentsInChildren<Item>();
        }

        //Base method is responsible for the purchase of the upgrade
        public virtual void UpgradeItem(int id)
        {
            //The condition of checking for money
            if (DataManager.data.Money >= Items[id].itemData.price)
            {
                //With a successful purchase
                DataManager.data.Money -= Items[id].itemData.price; //take money
                Items[id].itemData.price = Items[id].itemData.price * 2; //Increasing the price by 2
                priced = true; //Approve further logic.
            }
        }

        //The method is responsible for the successful purchase, makes saving
        protected void Upgraded()
        {
            priced = false;
            UpdateUI();
            Managers.Instance.uIManager.UpdateUI();

            Managers.Instance.upgradeManager.UpgradeSave();
        }

        //Update UI
        public void UpdateUI()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].UpdateUI();
            }
        }
    }
}