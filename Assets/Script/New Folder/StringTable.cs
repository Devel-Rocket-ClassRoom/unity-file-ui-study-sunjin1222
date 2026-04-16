using UnityEngine;
using System.Collections.Generic;

public class StringTable : DataTable
{
    public class Data
    {
        public string Id { get; set; }
        public string String { get; set; }
    }

    private readonly Dictionary<string, string> table = new Dictionary<string, string>();

    public override void Load(string filename)
    {
        table.Clear();

        string path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);

        if (textAsset == null)
        {
            Debug.LogError($"StringTable 파일을 못 찾음: Resources/{path}");
            return;
        }

        List<Data> list = LoadCSV<Data>(textAsset.text);

        foreach (Data data in list)
        {
            if (!table.ContainsKey(data.Id))
            {
                table.Add(data.Id, data.String);
            }
            else
            {
                Debug.LogError($"키 중복: {data.Id}");
            }
        }
    }

    public string Get(string key)
    {
        if (!table.ContainsKey(key))
        {
            Debug.LogError($"문자열 키 없음: {key}");
            return null;
        }

        return table[key];
    }
}