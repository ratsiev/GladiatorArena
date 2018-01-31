using UnityEngine;
using System.Collections;

public class TestEquipment : MonoBehaviour {

    private GameObject gladiator;
    private ChangeGear changeGear;
    private Item[] defaultItems = new Item[14];

    void Start() {
        gladiator = GameObject.FindGameObjectWithTag("Gladiator").gameObject;
        changeGear = gladiator.GetComponent<ChangeGear>();

        defaultItems = new Item[] {  ItemDatabase.instance.FetchItemBySlug("helmet_4"),
                                     ItemDatabase.instance.FetchItemBySlug("arm_1_r"),
                                     ItemDatabase.instance.FetchItemBySlug("arm_2_r"),
                                     ItemDatabase.instance.FetchItemBySlug("arm_3_l"),
                                     ItemDatabase.instance.FetchItemBySlug("arm_2_l"),
                                     ItemDatabase.instance.FetchItemBySlug("shoulder_3_r"),
                                     ItemDatabase.instance.FetchItemBySlug("shoulder_2_l"),
                                     ItemDatabase.instance.FetchItemBySlug("shield_3"),
                                     ItemDatabase.instance.FetchItemBySlug("weapon_1_r"),
                                     ItemDatabase.instance.FetchItemBySlug("torso_1"),
                                     ItemDatabase.instance.FetchItemBySlug("leg_2_r"),
                                     ItemDatabase.instance.FetchItemBySlug("leg_3_r"),
                                     ItemDatabase.instance.FetchItemBySlug("leg_2_l"),
                                     ItemDatabase.instance.FetchItemBySlug("leg_3_l")};

        foreach (Item item in defaultItems) {
            changeGear.EquipItem(item.ItemType, item.Slug);
        }

    }

}
