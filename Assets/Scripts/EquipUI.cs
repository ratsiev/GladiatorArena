using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EquipUI : MonoBehaviour {

    private GameObject gladiator;
    private ChangeGear changeGear;
    private Equipment equipment;
    private string currentItemType;
    private int index;

    private void Start() {
        gladiator = GameObject.FindGameObjectWithTag("Gladiator").gameObject;
        changeGear = gladiator.GetComponent<ChangeGear>();
        equipment = gladiator.GetComponent<Equipment>();
    }

    public void ChangeEquipment(string itemType) {
        List<Item> temp = ItemDatabase.instance.itemList.Where(x => x.ItemType == itemType).ToList();
        if (currentItemType != itemType) {
            currentItemType = itemType;
            if (equipment.equippedItems[itemType] != null)
                index = temp.Count == 1 ? GetItemIndex(itemType) == 1 ? 0 : 1 : GetItemIndex(itemType) + 1;
            else
                index = 0;
        }
        if (index != temp.Count) {
            for (int i = 0; i < temp.Count; i++) {
                if (i == index) {
                    changeGear.EquipItem(itemType, temp[i].Slug);
                    index++;
                    break;
                }
            }
        } else {
            changeGear.UnequipItem(temp[index - 1].ItemType);
            index = 0;
        }
    }

    private int GetItemIndex(string itemType) {
        List<Item> temp = ItemDatabase.instance.itemList.Where(x => x.ItemType == itemType).ToList();
        return temp.IndexOf(equipment.equippedItems[itemType]);
    }

}
