using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class SpawnMineral : MonoBehaviour
{
    public InventoryObject inventory;
    public Transform spawnPoint;
    public GameObject destroyNoMined;

    [SerializeField] private int idMineral = 0;
    [SerializeField] private GameObject mineralSprite;
    [SerializeField] private bool mineral;
    
    
  
    public float minSpawnChange = 2;
    public float maxSpawnChange = 4;
    private float spawnChangeValue = 0;



    // Start is called before the first frame update
    void Start()
    {
        InstantiateMineral();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0) && mineral == true)
        {
            DestroyMineral();
            SpawnMove();
            InstantiateMineral();
        }
        /*else if (destroyNoMined.GetComponent<DestroNoMinedMinerals>().noMined == true);
        {
            //DestroyNoMinedMinerals();
            DestroyMineral();
            DestroyNoMinedMinerals();
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
        //SpawnMove();
        //InstantiateMineral();
    }

    public void SpawnMove()
    {
        spawnChangeValue = Random.Range(minSpawnChange,maxSpawnChange);
        spawnPoint.position = spawnPoint.position + new Vector3(spawnChangeValue, 0, 0);
    }

    public void DestroyNoMinedMinerals()
    {
       
        spawnChangeValue = Random.Range(minSpawnChange * 2,maxSpawnChange * 2);
        spawnPoint.position = spawnPoint.position + new Vector3(spawnChangeValue, 0, 0);
        
       
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("NoMined") == true)
        {
            DestroyMineral();
            DestroyNoMinedMinerals();
            InstantiateMineral();
        }
    }

   
}
