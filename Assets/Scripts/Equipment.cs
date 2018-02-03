using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class Equipment : MonoBehaviour {

    public static string[] layers = new string[] { "First", "Second" };

    public Dictionary<string, object> items;
    public Dictionary<string, Weapon> weapons;
    public Dictionary<string, Dictionary<string, Armor>> armor;
    public Shield equippedShield;
    private EquipmentManager manager;

    private void Awake() {
        manager = GetComponent<EquipmentManager>();
    }

    public void Equip(EquippableItem item) {
        manager.AddEquipment(item);       
    }

    public void Unequip(EquippableItem equipmentToRemove) {
        manager.RemoveEquipment(equipmentToRemove);
    }

    public List<EquippableItem> EquippedItems {
        get {
            List<EquippableItem> temp = new List<EquippableItem>();
            temp.AddRange(weapons.Select(kvp => kvp.Value as EquippableItem).Where(item => item != null).ToList());
            layers.ToList().ForEach(layer => temp.AddRange(armor[layer].Select(kvp => kvp.Value as EquippableItem).Where(item => item != null).ToList()));
            if (equippedShield != null)
                temp.Add(equippedShield as EquippableItem);
            return temp;
        }
    }

}
