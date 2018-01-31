using UnityEngine;

[System.Serializable]
public class Item {

    public string Slug;
    public string EquipmentType;
    public GameObject ItemPrefab;
    public string ItemType;
    public int ItemID;

    public string ItemName;
    public string ItemDescription;

    public Sprite ItemIcon;

    public Item(int id, string itemName, string itemDescription, string slug, string equipmentType, string itemType, GameObject itemPrefab) {
        ItemID = id;
        ItemName = itemName;
        ItemDescription = itemDescription;
        Slug = slug;
        EquipmentType = equipmentType;
        ItemType = itemType;
        ItemPrefab = itemPrefab;
    }

    public string Info() {
        return $"Name: {ItemName}\tType: {EquipmentType}\nSlug: {Slug}";
    }

}