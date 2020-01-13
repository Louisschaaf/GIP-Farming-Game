using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour, IInventoryItem
{
    public string Name => "Doll";

    public Sprite _Image;

    public Sprite Image => _Image;

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    
}
