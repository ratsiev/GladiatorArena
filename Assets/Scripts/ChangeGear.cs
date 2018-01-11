using UnityEngine;

public class ChangeGear : MonoBehaviour {
    private Equipment equipmentScript;

    private void Start() {
        equipmentScript = GetComponent<Equipment>();
        //equip stuff
        // EquipItem("Legs", "pants"); 
    }

    public void EquipItem(string itemType, string itemSlug) {
        Item tempItem = ItemDatabase.instance.FetchItemBySlug(itemSlug);      
        if (WearingItem(tempItem))
            UnequipItem(tempItem.ItemType);
        equipmentScript.AddEquipment(tempItem);
    }

    public void UnequipItem(string itemType) {
        equipmentScript.RemoveEquipment(itemType);
    }

    private bool WearingItem(Item item) {
        return equipmentScript.equippedItems[item.ItemType] != null;
    }


}