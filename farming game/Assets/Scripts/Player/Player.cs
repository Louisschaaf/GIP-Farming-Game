using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public static Player Instance { get; private set; }

    public event EventHandler OnGoldAmountChanged;
    public event EventHandler OnPumpkinSeedAmountChanged;
    public event EventHandler OnGarlicSeedAmountChanged;
    public event EventHandler OnWheatSeedAmountChanged;
    public event EventHandler OnPotatoSeedAmountChanged;


    private int goldAmount;
    private int pumpkinSeedAmount;
    private int garlicSeedAmount;
    private int potatoSeedAmount;
    private int wheatSeedAmount;

    public void AddPumpkinSeed(int addPumpkinSeed)
    {
        pumpkinSeedAmount += addPumpkinSeed;
        OnPumpkinSeedAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddGarlicSeed(int addGarlicSeed)
    {
        garlicSeedAmount += addGarlicSeed;
        OnGarlicSeedAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddPotatoSeed(int addPotatoSeed)
    {
        potatoSeedAmount += addPotatoSeed;
        OnPotatoSeedAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddWheatSeed(int addWheatSeed)
    {
        wheatSeedAmount += addWheatSeed;
        OnWheatSeedAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddGoldAmount(int addGoldAmount)
    {
        goldAmount += addGoldAmount;
        OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetGoldAmount()
    {
        return goldAmount;
    }

    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Bought item: " + itemType);
        switch (itemType)
        {
            case Item.ItemType.Garlic_seed: AddGarlicSeed(garlicSeedAmount); break;
            case Item.ItemType.Potato_seed: AddPotatoSeed(potatoSeedAmount); break;
            case Item.ItemType.Wheat_seed: AddWheatSeed(wheatSeedAmount); break;
            case Item.ItemType.Pumpkin_seed: AddPumpkinSeed(pumpkinSeedAmount); break;
        }
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        if (GetGoldAmount() >= spendGoldAmount)
        {
            goldAmount -= spendGoldAmount;
            OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
}
