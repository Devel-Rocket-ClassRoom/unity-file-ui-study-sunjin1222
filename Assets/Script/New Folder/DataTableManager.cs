using System.Collections.Generic;
using UnityEngine;

public static class DataTableManager
{
    private static readonly Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();

    public static ItemTable ItemTable => Get<ItemTable>(DatatableIdes.Item);
    public static StringTable StringTable => Get<StringTable>(DatatableIdes.String);

    public static CharacterTable CharacterTable => Get<CharacterTable>(DatatableIdes.charater);


#if UNITY_EDITOR
    public static StringTable GetStringTable(Languages lang)
    {
        return Get<StringTable>(DatatableIdes.stringTableIDs[(int)lang]);
    }
#endif

    static DataTableManager()
    {
        Init();
    }

    private static void Init()
    {
#if !UNITY_EDITOR
        var stringTable = new StringTable();
        stringTable.Load(DataTableIds.String);
        tables.Add(DataTableIds.String, stringTable);
#else
        foreach (var id in DatatableIdes.stringTableIDs)
        {
            var stringTable = new StringTable();
            stringTable.Load(id);
            tables.Add(id, stringTable);
        }

#endif
        var Charater = new CharacterTable();
        Charater.Load(DatatableIdes.charater);
        tables.Add(DatatableIdes.charater, Charater);

        var ItmeTable = new ItemTable();
        ItmeTable.Load(DatatableIdes.Item);
        tables.Add(DatatableIdes.Item, ItmeTable);

  

    }

    public static void changLanguage(Languages Lang)
    {

        string oldId = string.Empty;
        foreach (var id in DatatableIdes.stringTableIDs)
        {
            if (tables.ContainsKey(id))
            {
                oldId=id; 
                break;
            }
        }
        var stringTable = tables[oldId];
        StringTable.Load(DatatableIdes.stringTableIDs[(int)Lang]);
        tables.Remove(oldId);
        tables.Add(DatatableIdes.String, stringTable);

    }
    public static T Get<T>(string id) where T : DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("테이블 없음");
            return null;
        }
        return tables[id] as T;
    }
}
