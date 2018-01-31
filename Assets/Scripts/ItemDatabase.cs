using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> itemList = new List<Item>();
    public static ItemDatabase instance;

    private static int id;

    private void Awake() {
        //create singleton
        instance = this;

        LoadShield();
        LoadWeapon();
        LoadArmor();
    }

    private void LoadShield() {
        TextAsset textAsset = Resources.Load("ShieldDatabase") as TextAsset;
        XDocument doc = XDocument.Parse(textAsset.text);
        foreach (var item in doc.Descendants("Shield")) {
            itemList.Add(NewItem(item));
            id++;
        }
    }

    private void LoadWeapon() {
        TextAsset textAsset = Resources.Load("WeaponDatabase") as TextAsset;
        XDocument doc = XDocument.Parse(textAsset.text);
        foreach (var item in doc.Descendants("Weapon")) {
            itemList.Add(NewWeapon(item));
            id++;
        }
    }

    private void LoadArmor() {
        TextAsset textAsset = Resources.Load("ArmorDatabase") as TextAsset;
        XDocument doc = XDocument.Parse(textAsset.text);
        foreach (var item in doc.Descendants("Armor")) {
            itemList.Add(NewItem(item));
            id++;
        }
    }

    private Item NewWeapon(XElement item) {
        return new Weapon(id, item.Element("Name").Value, item.Element("Description").Value, item.Element("Slug").Value, item.Element("EquipmentType").Value, item.Element("ItemType").Value, (GameObject)Resources.Load($"Gear/{item.Element("Prefab").Value}"), item.Element("WeaponType").Value);
    }

    private Item NewItem(XElement item) {
        return new Item(id, item.Element("Name").Value, item.Element("Description").Value, item.Element("Slug").Value, item.Element("EquipmentType").Value, item.Element("ItemType").Value, (GameObject)Resources.Load($"Gear/{item.Element("Prefab").Value}"));
    }

    public Item FetchItemByID(int id) {
        return itemList.Find(x => x.ItemID == id);
    }

    public Item FetchItemBySlug(string slugName) {
        return itemList.Find(x => x.Slug == slugName);
    }

}
