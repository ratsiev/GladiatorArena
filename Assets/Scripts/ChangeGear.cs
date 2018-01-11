using UnityEngine;

public class ChangeGear : MonoBehaviour {
    private Equipment equipmentScript;

    private void Start() {
        equipmentScript = GetComponent<Equipment>();
    }

    public void EquipItem(string itemType, string itemSlug) {  
        UnequipItem(itemType);
        equipmentScript.AddEquipment(ItemDatabase.instance.FetchItemBySlug(itemSlug));
    }

    public void UnequipItem(string itemType) {
        if (WearingItem(itemType))
            equipmentScript.RemoveEquipment(itemType);
    }

    private bool WearingItem(string itemType) {
        return equipmentScript.equippedItems[itemType] != null;
    }

}