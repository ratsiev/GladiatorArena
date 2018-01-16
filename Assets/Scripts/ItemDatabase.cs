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
        return new Item(id, item.Element("Name").Value, item.Element("Description").Value, item.Element("Slug").Value, item.Element("Type").Value, (GameObject)Resources.Load($"Gear/{item.Element("Prefab").Value}"), SetColor(item.Element("Color")));
    }

    public Item FetchItemByID(int id) {
        return itemList.Find(x => x.ItemID == id);
    }

    public Item FetchItemBySlug(string slugName) {
        return itemList.Find(x => x.Slug == slugName);
    }

    private Color SetColor(XElement color) {
        return new Color(XmlConvert.ToSingle(color.Element("R").Value), XmlConvert.ToSingle(color.Element("G").Value), XmlConvert.ToSingle(color.Element("B").Value));
    }

}
