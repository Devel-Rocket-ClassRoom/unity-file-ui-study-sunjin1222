using System.Collections.Generic;
using UnityEngine;


//1.CSV 파일(ID/이름/설명/공격력/초상화)
//2.데이터테이블 상속
public class CharacterData
{
    public string CId { get; set; }
    public string CName { get; set; }
    public string CDesc { get; set; }
    public string CAttack { get; set; }
    public string CDfance { get; set; }
    public string CIcon { get; set; }

    public string StringNameCh => DataTableManager.StringTable.Get(CName);
    public string StringDescCh => DataTableManager.StringTable.Get(CDesc);

    public Sprite SpriteIconCh => Resources.Load<Sprite>($"Icon/{CIcon}");

    public override string ToString()
    {
        return $"{CId}/{CName}/{CDesc}/{CAttack}/{CDfance}/{CIcon}";
    }

}
public class CharacterTable : DataTable
{
    private readonly Dictionary<string, CharacterData> table = new Dictionary<string, CharacterData>();

    public override void Load(string filename)
    {
        table.Clear();
        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        List<CharacterData> list = LoadCSV<CharacterData>(textAsset.text);

        foreach (var Cha in list)
        {
            if (!table.ContainsKey(Cha.CId))
            {
                table.Add(Cha.CId, Cha);
            }
            else
            {
                Debug.LogError("캐릭터 아이디 중복");
            }
        }


    }

    public CharacterData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.LogError("캐릭터 아이디 없음");
            return null;
        }
        return table[id];
    }
}

