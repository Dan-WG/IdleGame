using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroNoMinedMinerals : MonoBehaviour
{
    public bool noMined; 
    // Start is called before the first frame update
    void Start()
    {
        noMined = false;
    }

  
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Mineral") && noMined == false)
        {
            noMined = true;
        }
    }
}
