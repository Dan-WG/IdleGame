using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillerManager : MonoBehaviour
{
    public float DrillSpeed;
    public float DrillPotency;
    [Space]
    [SerializeField] float TimeWaiting;
    [SerializeField] MineralManager mineralManager;
    [SerializeField] StorageManager storageManager;

    // Start is called before the first frame update
    void Start()
    {
        //Load speed and potency.
       
    }

    // Update is called once per frame
    void Update()
    {
        TimeWaiting += Time.deltaTime;
        if(DrillSpeed < TimeWaiting)
        {
            mineralManager.Durability -= DrillPotency; 
            Debug.Log($"La durabilidad del mineral ha sido bajado en: -{DrillPotency}, total: {mineralManager.Durability}");

            mineralManager.UpdateMineralDurabilityUI();

            if(mineralManager.Durability <= 0)
            {
                Debug.Log("Mineral destruido");

                //provisional
                int numberItem = Random.Range(1, 2);
                //
                storageManager.AddItemMineral(mineralManager.typeOfMineral, numberItem);
                Debug.Log($"Mineral agregado: {mineralManager.typeOfMineral} x{numberItem}");

                mineralManager.Reset();
            }

            TimeWaiting = 0.0f;
            Debug.Log("Reseteo");
        }
    }
}
