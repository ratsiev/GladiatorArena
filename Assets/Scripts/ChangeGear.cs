using UnityEngine;

public class ChangeGear : MonoBehaviour {
    private Equipment equipment;

    private void Awake() {
        equipment = GetComponent<Equipment>();
    }

    public void EquipItem(string id) {
        EquippableItem item = (EquippableItem)GameItemLoader.instance.FetchItemByID(id);
        UnequipItem(item.ID);
        equipment.Equip(item);
    }

    public void UnequipItem(string id) {
        EquippableItem item = (EquippableItem)GameItemLoader.instance.FetchItemByID(id);
        if (WearingItem(item))
            equipment.Unequip(item);
    }

    private bool WearingItem(EquippableItem item) {
        return equipment.EquippedItems.Contains(item);
    }

}