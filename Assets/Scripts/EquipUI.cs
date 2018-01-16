using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EquipUI : MonoBehaviour {

    public Slider redSlider;
    public Slider blueSlider;
    public Slider greenSlider;

    private GameObject gladiator;
    private ChangeGear changeGear;
    private Equipment equipment;
    private string currentItemType;
    private int index;

    private void Start() {
        gladiator = GameObject.FindGameObjectWithTag("Gladiator").gameObject;
        changeGear = gladiator.GetComponent<ChangeGear>();
        equipment = gladiator.GetComponent<Equipment>();
        redSlider.enabled = blueSlider.enabled = greenSlider.enabled = false;
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
                    SetColor(itemType);
                    break;
                }
            }
        } else {
            changeGear.UnequipItem(temp[index - 1].ItemType);
            index = 0;
        }
    }

    public void ChangeColor(string color) {
        if (currentItemType != "") {
            Color temp = equipment.equippedItems[currentItemType].ItemObject.GetComponentInChildren<Renderer>().material.color;
            switch (color) {
                case "red":
                    temp.r = redSlider.value;
                    break;
                case "blue":
                    temp.b = blueSlider.value;
                    break;
                case "green":
                    temp.g = greenSlider.value;
                    break;
            }
            equipment.equippedItems[currentItemType].ChangeColor(temp);
        }
    }

    private void SetColor(string itemType) {
        Color color = equipment.equippedItems[itemType].Item.Color;
        redSlider.value = color.r;
        redSlider.enabled = true;
        blueSlider.value = color.b;
        blueSlider.enabled = true;
        greenSlider.value = color.g;
        greenSlider.enabled = true;
    }

    private int GetItemIndex(string itemType) {
        List<Item> temp = ItemDatabase.instance.itemList.Where(x => x.ItemType == itemType).ToList();
        return temp.IndexOf(equipment.equippedItems[itemType].Item);
    }

}
