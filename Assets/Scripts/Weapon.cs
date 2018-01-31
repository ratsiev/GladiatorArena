using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum WeaponType { OneHanded, TwoHanded, Pole }
public class Weapon : Item {

    public WeaponType WeaponType;

    public Weapon(int id, string itemName, string itemDescription, string slug, string equipmentType, string itemType, GameObject itemPrefab, string weaponType) : base(id, itemName, itemDescription, slug, equipmentType, itemType, itemPrefab) {
        WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), weaponType);
    }

}
