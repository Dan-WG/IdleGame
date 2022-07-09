using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Mineral,
    SpawnPoint
}
public class ItemObject : ScriptableObject
{
    public GameObject mineralPrefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}