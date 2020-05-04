using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    private Transform Container;
    private Transform ShopItemTemplate;
    private IShopCustomer shopCustomer;
    private void Awake()
    {
        Container = transform.Find("Container");
        ShopItemTemplate = Container.Find("ShopItemTemplate");
        ShopItemTemplate.gameObject.SetActive(false);

    }

    private void Start()
    {
        CreateItemButton(Item.ItemType.Wheat_seed, Item.GetSprite(Item.ItemType.Wheat_seed), "Wheat Seed", Item.GetCost(Item.ItemType.Wheat_seed), 0);
        CreateItemButton(Item.ItemType.Garlic_seed, Item.GetSprite(Item.ItemType.Garlic_seed), "Garlic Seed", Item.GetCost(Item.ItemType.Garlic_seed), 1);
        CreateItemButton(Item.ItemType.Potato_seed, Item.GetSprite(Item.ItemType.Potato_seed), "Potato Seed", Item.GetCost(Item.ItemType.Potato_seed), 2);
        CreateItemButton(Item.ItemType.Pumpkin_seed, Item.GetSprite(Item.ItemType.Pumpkin_seed), "Pumpkin Seed", Item.GetCost(Item.ItemType.Pumpkin_seed), 3);

        Hide();
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(ShopItemTemplate, Container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 100f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("NameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("PriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            TryBuyItem(itemType);
        };
    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

