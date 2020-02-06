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
    }

    public ItemType itemType;
    public int amount;
}
