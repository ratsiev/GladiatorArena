using UnityEngine;

public class ChangeGear : MonoBehaviour {
    private Equipment equipment;

    private void Start() {
        equipment = GetComponent<Equipment>();
    }

    public void EquipItem(string itemType, string itemSlug) {  
        UnequipItem(itemType);
        equipment.AddEquipment(ItemDatabase.instance.FetchItemBySlug(itemSlug));
    }

    public void UnequipItem(string itemType) {
        if (WearingItem(itemType))
            equipment.RemoveEquipment(itemType);
    }

    private bool WearingItem(string itemType) {
        return equipment.equippedItems[itemType] != null;
    }

}