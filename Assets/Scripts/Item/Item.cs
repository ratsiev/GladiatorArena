using UnityEngine;

public abstract class Item {

    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public GameObject Prefab { get; set; }
    public string Icon { get; set; }
    public float Price { get; set; }
    public string Type { get; set; }

}

