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
            {"LeftLeg2" , null}
        };

    }

    public void AddEquipment(Item equipmentToAdd) {
        equippedItems[equipmentToAdd.ItemType] = new EquippedItem(equipmentToAdd);
        Wear(equippedItems[equipmentToAdd.ItemType].itemObject, equipmentToAdd.ItemType);
    }

    public void RemoveEquipment(string equipmentToRemove) {
        RemoveWorn(equippedItems[equipmentToRemove].itemObject);
        equippedItems[equipmentToRemove] = null;
    }

    private void RemoveWorn(GameObject wornClothing) {
        Destroy(wornClothing);
    }

    private void Wear(GameObject clothing, string itemType) {
        clothing = Instantiate(clothing);
        equippedItems[itemType].itemObject = stitcher.Stitch(clothing, avatar);
        Destroy(clothing);
    }

}

public class EquippedItem {

    public Item item;
    public GameObject itemObject;

    public EquippedItem(Item item) {
        this.item = item;
        itemObject = item.ItemPrefab;
    }

}
