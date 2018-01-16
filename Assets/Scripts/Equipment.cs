using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Equipment : MonoBehaviour {

    public GameObject avatar;

    public Dictionary<string, EquippedItem> equippedItems;

    private Stitcher stitcher;

    public void Awake() {
        stitcher = new Stitcher();

        equippedItems = new Dictionary<string, EquippedItem>() {
            {"Torso" , null},
            {"Head" , null},
            {"RightHand" , null},
            {"RightArm1" , null},
            {"RightArm2" , null},
            {"RightShoulder", null},
            {"LeftHand" , null},
            {"LeftArm1" , null},
            {"LeftArm2" , null},
            {"LeftShoulder" , null},
            {"RightLeg1", null},
            {"RightLeg2" , null},
            {"LeftLeg1" , null},
            {"LeftLeg2" , null},
            {"Shield" , null},
        };

    }

    public void AddEquipment(Item equipmentToAdd) {
        equippedItems[equipmentToAdd.ItemType] = new EquippedItem(equipmentToAdd);
        Wear(equippedItems[equipmentToAdd.ItemType].ItemObject, equipmentToAdd.ItemType);
    }

    public void RemoveEquipment(string equipmentToRemove) {
        RemoveWorn(equippedItems[equipmentToRemove].ItemObject);
        equippedItems[equipmentToRemove] = null;
    }

    private void RemoveWorn(GameObject wornClothing) {
        Destroy(wornClothing);
    }

    private void Wear(GameObject clothing, string itemType) {
        clothing = Instantiate(clothing);
        equippedItems[itemType].ItemObject = stitcher.Stitch(clothing, avatar);
    }

}

public class EquippedItem {

    public Item Item;
    public GameObject ItemObject;

    public EquippedItem(Item item) {
        Item = item;
        ItemObject = item.ItemPrefab;
    }

    public void SetColor() {
        ItemObject.GetComponentInChildren<Renderer>().material.color = Item.Color;
    }

    public void ChangeColor(Color color) {
        Item.Color = color;
        ItemObject.GetComponentInChildren<Renderer>().material.color = Item.Color;
    }

}
