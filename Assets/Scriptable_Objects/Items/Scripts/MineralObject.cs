using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mineral Object", menuName = "Inventory System/Items/Mineral")]
public class MineralObject : ItemObject
{
    public float durability = 0f;
    public float goldEarned = 0f;

    public void Awake()
    {
        type = ItemType.Mineral;
    }
}
