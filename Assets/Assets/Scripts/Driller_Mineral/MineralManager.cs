using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MineralManager : MonoBehaviour
{
    public TypeOfMineral typeOfMineral = TypeOfMineral.Null;
    public float Durability = 0;
    public Sprite[] spritesMineral;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        var totalNumberOfMinerals = Enum.GetNames(typeof(TypeOfMineral)).Length;
        typeOfMineral = (TypeOfMineral)Random.Range(1, totalNumberOfMinerals);
        Debug.Log($"Mineral: {typeOfMineral}");

        switch (typeOfMineral)
        {
            case TypeOfMineral.Rocks:
                Durability = 5;
                spriteRenderer.sprite = spritesMineral[0];
                break;
            case TypeOfMineral.Iron:
                Durability = 10;
                spriteRenderer.sprite = spritesMineral[1];
                break;
            case TypeOfMineral.Gold:
                Durability = 20;
                spriteRenderer.sprite = spritesMineral[2];
                break;
            case TypeOfMineral.Diamond:
                Durability = 30;
                spriteRenderer.sprite = spritesMineral[3];
                break;
            case TypeOfMineral.Esmerald:
                Durability = 40;
                spriteRenderer.sprite = spritesMineral[4];
                break;
            case TypeOfMineral.Ruby:
                Durability = 50;
                spriteRenderer.sprite = spritesMineral[5];
                break;
        }
    }
}

public enum TypeOfMineral
{
    Null,
    Rocks,
    Iron,
    Gold,
    Diamond,
    Esmerald,
    Ruby
}
