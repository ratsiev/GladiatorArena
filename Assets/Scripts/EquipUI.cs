using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EquipUI : MonoBehaviour {
    private GameObject gladiator;
    private ChangeGear changeGearScript;
    private Equipment equipmentScript;

    private void Start() {
        gladiator = GameObject.FindGameObjectWithTag("Gladiator").gameObject;
        changeGearScript = gladiator.GetComponent<ChangeGear>();
        equipmentScript = gladiator.GetComponent<Equipment>();
    }

    // test
    public void EquipHelmet() {  
        changeGearScript.EquipItem("Head", "helmet_1");
    }

    // test
    public void RemoveHelmet() { 
        changeGearScript.UnequipItem("Head");
    }

    private void ChangeEquipment(string type) {
        List<Item> temp = ItemDatabase.instance.itemList.Where(x => x.ItemType == type).ToList();
    }

}
