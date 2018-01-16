// with the exception of some changes, this is not the work of ratsiev. The script was downloaded from here: https://www.youtube.com/watch?v=bhNiMWaCGn4

using UnityEngine;

[System.Serializable]
public class Item {
    public string Slug;
    public string ItemType;
    public GameObject ItemPrefab;
    public int ItemID;
    public Color Color;

    public string ItemName;
    public string ItemDescription;

    public bool Stackable;
    public Sprite ItemIcon;

    //constructor for facial hair, hair, weapons, and armor
    public Item(int id, string itemName, string itemDescription, string slug, string itemType, GameObject itemPrefab, Color color) {
        ItemID = id;
        ItemName = itemName;
        ItemDescription = itemDescription;
        Slug = slug;
        ItemType = itemType;
        ItemPrefab = itemPrefab;
        Color = color;
    }

    public string Info() {
        return $"Name: {ItemName}\tType: {ItemType}\nSlug: {Slug}";
    }

}