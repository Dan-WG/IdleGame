using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Point Object", menuName = "Inventory System/Items/Spawn Point")]
public class SpawnPointObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.SpawnPoint;
    }

}
