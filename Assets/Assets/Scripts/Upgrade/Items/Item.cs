using UnityEngine;
using UnityEngine.UI;
using System;

namespace Idle
{
    public class Item : MonoBehaviour
    {
        [Header("Components")]
        public ItemData itemData;

        [Header("Item info")]
        public string itemName;
        public string description;
        public Sprite icon;
        [Header("UI")]
        public Image iconImage, priceImage;
        public Text nameText, descriptionText, priceText;
        public Button buyBtn;

        [Header("Value to add")]
        public int value;

        //Method for update UI
        public void UpdateUI()
        {
            iconImage.sprite = icon;
            nameText.text = itemName;
            descriptionText.text = description + ": " + value;
            priceText.text = ":" + UIManager.IntParseToString(itemData.price);
        }
    }

    //The class that stores the data to save the Item
    [Serializable]
    public class ItemData
    {
        public long price;
    }

}