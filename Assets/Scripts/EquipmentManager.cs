using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    private MeshManager meshManager;
    private Equipment equipment;

    private void Awake() {
        meshManager = GetComponent<MeshManager>();
        equipment = GetComponent<Equipment>();
        CreateEquipmentDictionaries();
    }

    public void AddEquipment(EquippableItem equipmentToAdd) {
        switch (equipmentToAdd.GetType().Name) {
            case "Weapon":
                EquipWeapon(equipmentToAdd as Weapon);
                break;
            case "Armor":
                EquipArmor(equipmentToAdd as Armor);
                break;
            case "Shield":
                equipment.items["Shield"] = equipmentToAdd as Shield;
                break;
        }
        meshManager.AddMesh(equipmentToAdd, GetLayer(equipmentToAdd));
    }

    public void RemoveEquipment(EquippableItem equipmentToRemove) {
        switch (equipmentToRemove.GetType().Name) {
            case "Weapon":
                RemoveWeapon(equipmentToRemove as Weapon);
                break;
            case "Armor":
                RemoveArmor(equipmentToRemove as Armor);
                break;
            case "Shield":
                equipment.items["Shield"] = equipmentToRemove as Shield;
                break;
        }
        meshManager.RemoveMesh(equipmentToRemove.EquipmentType, GetLayer(equipmentToRemove));
    }

    public void CreateEquipmentDictionaries() {

        equipment.armor = new Dictionary<string, Dictionary<string, Armor>>();

        CreateArmorLayers();

        equipment.weapons = new Dictionary<string, Weapon>() {
            {"RightHand" , null},
            {"LeftHand" , null}
        };

        equipment.items = new Dictionary<string, object>() {
            {"Weapon",equipment.weapons},
            {"Armor",equipment.armor},
            {"Shield",equipment.equippedShield}
        };
    }

    private void EquipArmor(Armor armor) {
        equipment.armor[armor.Layer][armor.EquipmentType] = armor;
    }

    private void RemoveArmor(Armor armor) {
        equipment.armor[armor.Layer][armor.EquipmentType] = null;
    }

    private void EquipWeapon(Weapon weapon) {
        equipment.weapons[weapon.EquipmentType] = weapon;
    }

    private void RemoveWeapon(Weapon weapon) {
        equipment.weapons[weapon.EquipmentType] = null;
    }

    private string GetLayer(EquippableItem item) {
        if (item.GetType() == typeof(Armor)) {
            Armor armor = item as Armor;
            return armor.Layer;
        }
        return "First";
    }

    private void CreateArmorLayers() {
        Equipment.layers.ToList().ForEach(layer => equipment.armor.Add(layer, new Dictionary<string, Armor>() {
            {"Torso" , null},
            {"Head" , null},
            {"RightForearm" , null},
            {"RightArm" , null},
            {"RightShoulder", null},
            {"LeftForearm" , null},
            {"LeftArm" , null},
            {"LeftShoulder" , null},
            {"RightLeg", null},
            {"LeftLeg" , null},
            {"Pants" , null}
        }));
    }
}



