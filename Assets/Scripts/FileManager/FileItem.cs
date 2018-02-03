using System.Collections.Generic;

public class FileItem {

    public string Name;
    public Dictionary<string, string> Child;

    public FileItem(string name) {
        Name = name;
        Child = new Dictionary<string, string>();
    }

    public void AddChild(string childName, string value) {
        Child.Add(childName, value);
    }

}
