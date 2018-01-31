using UnityEngine;
using System.Collections;

public class TestEquipment : MonoBehaviour {

    public GameObject gladiator;
    private ChangeGear changeGear;
    private string[] defaultItems = new string[] { "helmet_4", "arm_1_r", "arm_2_r", "arm_3_l", "arm_2_l", "shoulder_3_r", "shoulder_2_l", "shield_3", "weapon_1_r",
            "torso_1", "leg_2_r", "leg_3_r", "leg_2_l", "leg_3_l" };

    void Start() {
        changeGear = gladiator.GetComponent<ChangeGear>();

        foreach (string item in defaultItems) {
            changeGear.EquipItem(item);
        }

    }

}
