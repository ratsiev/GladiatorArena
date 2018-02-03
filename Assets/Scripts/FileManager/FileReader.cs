using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader {

    public static List<FileItem> ReadTextAsset(string file) {
        List<FileItem> GameItems = new List<FileItem>();

        string[] itemInfo = file.Split(new[] { "[" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in itemInfo) {
            GameItems.Add(NewItem(line));
        }

        return GameItems;
    }

    private static FileItem NewItem(string text) {
        string[] elements = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        FileItem item = new FileItem(elements[0].Trim(']'));
        for (int i = 1; i < elements.Length; i++) {
            string[] element = elements[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            item.AddChild(element[0], element[1]);
        }
        return item;
    }
}

