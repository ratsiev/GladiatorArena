using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> itemList = new List<Item>();
    public static ItemDatabase instance;

    private static int id;

    private void Awake() {
        //create singleton
        instance = this;

        LoadItems();
    }

    private void LoadItems() {
        TextAsset textAsset = Resources.Load("ItemDatabase") as TextAsset;
        XDocument doc = XDocument.Parse(textAsset.text);
        foreach(var item in doc.Descendants("Item")) {
            itemList.Add(NewItem(item));
            id++;
        }
    }

    private Item NewItem(XElement item) {
        if (item.Element("Prefab").Value == "")
            return new Item(id, item.Element("Name").Value, item.Element("Description").Value, item.Element("Slug").Value, item.Element("Type").Value);
        return new Item(id, item.Element("Name").Value, item.Element("Description").Value, item.Element("Slug").Value, item.Element("Type").Value, (GameObject)Resources.Load($"Gear/{item.Element("Prefab").Value}"));
    }

    public Item FetchItemByID(int id) {
        return itemList.Find(x => x.ItemID == id);
    }

    public Item FetchItemBySlug(string slugName) {
        return itemList.Find(x => x.Slug == slugName);
    }


}
