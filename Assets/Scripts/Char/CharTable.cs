using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/*
Id, Type, Name, Desc, Value, Cost, Icon
Item1, Weapon, Item1Name, Item1Desc,10,500, Icon_Sword01
Item2, Equip, Item2Name, Item2Desc,20,200, Icon_Shield01
Item3, Weapon, Item3Name, Item3Desc,5,1000, Icon_Bow01
Item4, Consumable, Item4Name, Item4Desc,50,50, Icon_Heart01
*/


public class CharData 
{


    public string Id { get; set; }
    public charTypes Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int attack { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; }

    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);
    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");

    public override string ToString()
    {
        return $"{Id} / {Type} / {Name} / {Desc} / {attack} / {Cost} / {Icon}";
    }
}

public class CharTable : DataTable
{
    private readonly Dictionary<string, CharData> table =
        new Dictionary<string, CharData>();

    private List<string> keyList;

    public override void Load(string filename)
    {
        table.Clear();

        string path = string.Format(FormatPath, filename);
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        List<CharData> list = LoadCSV<CharData>(textAsset.text);

        foreach (var chara in list)
        {
            if (!table.ContainsKey(chara.Id))
            {
                table.Add(chara.Id, chara);
            }
            else
            {
                Debug.LogError("아이템 아이디 중복");
            }
        }

        keyList = table.Keys.ToList();
    }

    public CharData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.LogError("아이템 아이디 없음");
            return null;
        }
        return table[id];
    }

    public CharData GetRandom()
    {
        return Get(keyList[Random.Range(0, keyList.Count)]);
    }
}


