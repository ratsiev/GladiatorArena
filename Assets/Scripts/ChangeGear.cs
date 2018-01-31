using UnityEngine;

public class ChangeGear : MonoBehaviour {
    private Equipment equipment;

    private void Awake() {
        equipment = GetComponent<Equipment>();
    }

    public void EquipItem(string itemSlug) {
        Item item = ItemDatabase.instance.FetchItemBySlug(itemSlug);
        UnequipItem(item.EquipmentType);
        equipment.AddEquipment(item);
    }

    public void UnequipItem(string equipmentType) {
        if (WearingItem(equipmentType))
            equipment.RemoveEquipment(equipmentType);
    }

    private bool WearingItem(string equipmentType) {
        return equipment.equippedItems[equipmentType] != null;
    }

}