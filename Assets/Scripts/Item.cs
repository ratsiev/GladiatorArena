using UnityEngine;

[System.Serializable]
public class Item {

    public string Slug;
    public string ItemType;
    public GameObject ItemPrefab;
    public int ItemID;

    public string ItemName;
    public string ItemDescription;

    public Sprite ItemIcon;

    //constructor for facial hair, hair, weapons, and armor
    public Item(int id, string itemName, string itemDescription, string slug, string itemType, GameObject itemPrefab) {
        ItemID = id;
        ItemName = itemName;
        ItemDescription = itemDescription;
        Slug = slug;
        ItemType = itemType;
        ItemPrefab = itemPrefab;
    }

    public string Info() {
        return $"Name: {ItemName}\tType: {ItemType}\nSlug: {Slug}";
    }

}