using UnityEngine;

public class Weapon : EquippableItem {

    public float Damage { get; set; }
    public float Speed { get; set; }
    public float Range { get; set; }
    public string[] DamageType { get; set; }
    public WeaponGrip Grip { get; set; }

    public enum WeaponGrip { OneHanded, TwoHanded }

}

