using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MineralManager : MonoBehaviour
{
    [Header("Basic for minerals")]
    public TypeOfMineral typeOfMineral = TypeOfMineral.Null;
    public float Durability = 0;
    public Sprite[] spritesMineral;
    public SpriteRenderer spriteRenderer;
    [Space]
    [Header("Basic for UI Animation")]
    [SerializeField] float[] RangeDurability = new float[2];
    public Sprite[] SpriteBroke;
    public SpriteRenderer BrokeRenderer;
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

        RangeDurability[0] = 0;
        RangeDurability[1] = Durability;
        BrokeRenderer.sprite = SpriteBroke[0];
    }

    public void UpdateMineralDurabilityUI()
    {
        float percentajeDurability = (Durability - RangeDurability[0]) / (RangeDurability[1] - RangeDurability[0]);
        Debug.Log("percentaje: " + percentajeDurability);
        
        if(percentajeDurability >= 0.801f)
        {
            BrokeRenderer.sprite = SpriteBroke[0];
        }
        else if (percentajeDurability >= 0.601f && percentajeDurability <= 0.8)
        {
            BrokeRenderer.sprite = SpriteBroke[1];
        }
        else if (percentajeDurability >= 0.401f && percentajeDurability <= 0.6)
        {
            BrokeRenderer.sprite = SpriteBroke[2];
        }
        else if (percentajeDurability >= 0.201f && percentajeDurability <= 0.4)
        {
            BrokeRenderer.sprite = SpriteBroke[3];
        }
        else if (percentajeDurability >= 0.001f && percentajeDurability <= 0.2)
        {
            BrokeRenderer.sprite = SpriteBroke[4];
        }
        else if (percentajeDurability <= 0)
        {
            BrokeRenderer.sprite = SpriteBroke[5];
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
