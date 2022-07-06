using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour
{
    public Text Rock_txt;
    public Text Iron_txt;
    public Text Gold_txt;
    public Text Diamond_txt;
    public Text Esmerald_txt;
    public Text Ruby_txt;

    public int RockItems; 
    public int IronItems; 
    public int GoldItems; 
    public int DiamondItems; 
    public int Esmeraldtems; 
    public int RubyItems; 

    void Awake()
    {
      //Load mineral storage  
      //Update UI
    }

    public void AddItemMineral(TypeOfMineral typeOfMineral, int NumberOfItemDrilled)
    {
        switch (typeOfMineral)
        {
            case TypeOfMineral.Rocks:
                RockItems += NumberOfItemDrilled;
                break;
            case TypeOfMineral.Iron:
                IronItems += NumberOfItemDrilled;
                break;
            case TypeOfMineral.Gold:
                GoldItems += NumberOfItemDrilled;
                break;
            case TypeOfMineral.Diamond:
                DiamondItems += NumberOfItemDrilled;
                break;
            case TypeOfMineral.Esmerald:
                Esmeraldtems += NumberOfItemDrilled;
                break;
            case TypeOfMineral.Ruby:
                RubyItems += NumberOfItemDrilled;
                break;
        }
        UpdateUIMineralStorage();
    }

    public void UpdateUIMineralStorage()
    {
        Rock_txt.text = RockItems.ToString();
        Iron_txt.text = IronItems.ToString();
        Gold_txt.text = GoldItems.ToString();
        Diamond_txt.text = DiamondItems.ToString();
        Esmerald_txt.text = Esmeraldtems.ToString();
        Ruby_txt.text = RubyItems.ToString();
    }
}
