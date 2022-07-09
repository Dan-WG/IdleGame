using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class SpawnMineral : MonoBehaviour
{
    public InventoryObject inventory;
    public int idMineral = 0;
    public Transform spawnPoint;
    public GameObject mineralSprite;
    public bool mineral;
   
   

    // Start is called before the first frame update
    void Start()
    {
        InstantiateMineral();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && mineral == true)
        {
           DestroyMineral();
        }
        /*else if(Input.GetKeyDown(KeyCode.Mouse0) && mineral == false)
        {
            InstantiateMineral();
        }*/
        
    }

    public void InstantiateMineral()
    {
        idMineral = Random.Range(0, inventory.Container.Count);
        mineralSprite = Instantiate(inventory.Container[idMineral].item.mineralPrefab, spawnPoint);
        mineral = true;
    }

    public void DestroyMineral()
    {
        Destroy(mineralSprite);
        mineral = false;
        InstantiateMineral();
    }
}
