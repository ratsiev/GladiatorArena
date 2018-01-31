using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EquipUI : MonoBehaviour {

    private GameObject gladiator;
    private ChangeGear changeGear;
    private Equipment equipment;
    private string currentEquipmentType;
    private int index;

    private void Start() {
        gladiator = GameObject.FindGameObjectWithTag("Gladiator").gameObject;
        changeGear = gladiator.GetComponent<ChangeGear>();
        equipment = gladiator.GetComponent<Equipment>();
    }

    public void ChangeEquipment(string equipmentType) {
        List<Item> temp = ItemDatabase.instance.itemList.Where(x => x.EquipmentType == equipmentType).ToList();
        if (currentEquipmentType != equipmentType) {
            currentEquipmentType = equipmentType;
            if (equipment.equippedItems[equipmentType] != null)
                index = temp.Count == 1 ? GetItemIndex(equipmentType) == 1 ? 0 : 1 : GetItemIndex(equipmentType) + 1;
            else
                index = 0;
        }
        if (index != temp.Count) {
            for (int i = 0; i < temp.Count; i++) {
                if (i == index) {
                    changeGear.EquipItem(temp[i].Slug);
                    index++;
                    break;
                }
            }
        } else {
            changeGear.UnequipItem(temp[index - 1].EquipmentType);
            index = 0;
        }
    }

    private int GetItemIndex(string equipmentType) {
        List<Item> temp = ItemDatabase.instance.itemList.Where(x => x.EquipmentType == equipmentType).ToList();
        return temp.IndexOf(equipment.equippedItems[equipmentType]);
    }

}
