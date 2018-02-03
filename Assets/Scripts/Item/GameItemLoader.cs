using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class GameItemLoader : MonoBehaviour {

    public List<Item> itemList = new List<Item>();
    public static GameItemLoader instance;

    private void Awake() {
        instance = this;

        LoadItems();
    }

    private void LoadItems() {
        TextAsset textAsset = Resources.Load("GameItems") as TextAsset;

		if(textAsset.text.Length > 0) {
            List<FileItem> fileItems = FileReader.ReadTextAsset(textAsset.text);
            fileItems.ForEach(x => itemList.Add(NewItem(x)));
        }

    }
    private Item NewItem(FileItem fileItem) {
        Item item = fileItem.Name == "Weapon" ? NewWeapon(fileItem) : fileItem.Name == "Armor" ? NewArmor(fileItem) : fileItem.Name == "Shield" ? NewShield(fileItem) : (Item)NewPotion(fileItem);
        return item;
    }

    private Weapon NewWeapon(FileItem item) {
        return new Weapon() {
            ID = item.Child["ID"],
            Name = item.Child["Name"],
            Description = item.Child["Description"],
            Prefab = (GameObject)Resources.Load($"Gear/{item.Child["Prefab"]}"),
            Icon = item.Child["Icon"],
            Price = float.Parse(item.Child["Price"]),
            Health = float.Parse(item.Child["Health"]),
            Weight = float.Parse(item.Child["Weight"]),
            Type = item.Child["Type"],
			EquipmentType = item.Child["EquipmentType"],
            Damage = float.Parse(item.Child["Damage"]),
            DamageType = item.Child["DamageType"].Split(','),
            Speed = float.Parse(item.Child["Speed"]),
            Grip = (Weapon.WeaponGrip)Enum.Parse(typeof(Weapon.WeaponGrip), item.Child["Grip"]),
            Range = float.Parse(item.Child["Range"])
        };
    }

    private Armor NewArmor(FileItem item) {
        return new Armor() {
            ID = item.Child["ID"],
            Name = item.Child["Name"],
            Description = item.Child["Description"],
            Prefab = (GameObject)Resources.Load($"Gear/{item.Child["Prefab"]}"),
            Icon = item.Child["Icon"],
            Price = float.Parse(item.Child["Price"]),
            Health = float.Parse(item.Child["Health"]),
            Weight = float.Parse(item.Child["Weight"]),
            Type = item.Child["Type"],
			EquipmentType = item.Child["EquipmentType"],
            Places = item.Child["Places"].Split(','),
            Layer = item.Child["Layer"],
            ArmorRating = float.Parse(item.Child["ArmorRating"])
        };
    }

    private Shield NewShield(FileItem item) {
        return new Shield() {
            ID = item.Child["ID"],
            Name = item.Child["Name"],
            Description = item.Child["Description"],
            Prefab = (GameObject)Resources.Load($"Gear/{item.Child["Prefab"]}"),
            Icon = item.Child["Icon"],
            Price = float.Parse(item.Child["Price"]),
            Health = float.Parse(item.Child["Health"]),
            Weight = float.Parse(item.Child["Weight"]),
            Type = item.Child["Type"],
			EquipmentType = item.Child["EquipmentType"],
            DefensePoints = float.Parse(item.Child["DefensePoints"])
        };
    }

    private Potion NewPotion(FileItem item) {
        return new Potion() {
            ID = item.Child["ID"],
            Name = item.Child["Name"],
            Description = item.Child["Description"],
            Prefab = (GameObject)Resources.Load($"Gear/{item.Child["Prefab"]}"),
            Icon = item.Child["Icon"],
            Price = float.Parse(item.Child["Price"]),
            Type = item.Child["Type"],
            Points = float.Parse(item.Child["Points"])
        };
    }

    public Item FetchItemByID(string id) {
        return itemList.Find(x => x.ID == id);
    }

}

