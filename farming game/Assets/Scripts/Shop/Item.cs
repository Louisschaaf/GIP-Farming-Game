using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Axe,
        Hoe,
        Shovel,
        PickAxe,
        Pumpkin_seed,
        Potato_seed,
        Wheat_seed,
        Garlic_seed

    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Wheat_seed: return 10;
            case ItemType.Garlic_seed: return 15;
            case ItemType.Potato_seed: return 20;
            case ItemType.Pumpkin_seed: return 25;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Wheat_seed: return GameAssets.i.Wheat_seed; 
            case ItemType.Garlic_seed: return GameAssets.i.Garlic_seed;
            case ItemType.Potato_seed: return GameAssets.i.Potato_seed;
            case ItemType.Pumpkin_seed: return GameAssets.i.Pumpkin_seed;

        }
    }


}
