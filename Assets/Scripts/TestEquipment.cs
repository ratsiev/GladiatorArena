using UnityEngine;
using System.Collections;

public class TestEquipment : MonoBehaviour {

    public GameObject gladiator;
    private ChangeGear changeGear;
    public string[] defaultItems;

    void Start() {
        changeGear = gladiator.GetComponentInChildren<ChangeGear>();

        foreach (string item in defaultItems) {
            changeGear.EquipItem(item);
        }

    }

}
