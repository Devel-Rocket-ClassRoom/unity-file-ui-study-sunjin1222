using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.DebugUI;

public class ItemData
{
    public string Id { get; set; }
    public ItemType Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; }

  
    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);


    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");

    public override string ToString()
    {
        return $"{Id}/{Type}/{Name}/{Desc}/{Value}/{Cost}/{Icon}";
    }

}

public class ItemTable : DataTable
{
    private readonly Dictionary<string, ItemData> table = new Dictionary<string, ItemData>();

    public override void Load(string filename)
    {
        table.Clear();
        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        List<ItemData> list = LoadCSV<ItemData>(textAsset.text);

        foreach (var item in list)
        {
            if (!table.ContainsKey(item.Id))
            {
                table.Add(item.Id, item);
            }
            else
            {
                Debug.LogError("아이템 아이디 중복");
            }
        }


    }

    public ItemData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.LogError("아이템 아이디 없음");
            return null;
        }
        return table[id];
    }

    public List<string> Randomitem()
    {
        List<string> a = new List<string>(table.Keys);
        List<string> b = new List<string>(table.Keys);
        foreach (var key in table.Keys)
        {
            ItemData item = DataTableManager.ItemTable.Get(key);

            //b.Add(item);
        }

  
        return new List<string>(table.Keys);
    } 

}


