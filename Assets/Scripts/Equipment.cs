using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Equipment : MonoBehaviour {

    public Dictionary<string, Item> equippedItems;

    private MeshManager meshManager;

    public void Awake() {
        meshManager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<MeshManager>();

        equippedItems = new Dictionary<string, Item>() {
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
        equippedItems[equipmentToAdd.ItemType] = equipmentToAdd;
        meshManager.AddMesh(equipmentToAdd);
    }

    public void RemoveEquipment(string equipmentToRemove) {
        meshManager.RemoveMesh(equipmentToRemove);
        equippedItems[equipmentToRemove] = null;
    }
}
