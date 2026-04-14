using UnityEngine;

public enum Languages
{ 
    Korean,
    English,
    Japanese
}
public enum ItemType
{
    Weapon,
    Equip,
    Consumable
}




public static class Variables
{
    public static event System.Action OnLangugeChangeed;
    private static Languages languages = Languages.Korean;
    public static Languages Languages
    {
        get 
        { 
            return languages;
        }
        set 
        {
            if (languages == value)
            {
                return;
            }
            languages = value;
            DataTableManager.changLanguage(languages);

            OnLangugeChangeed?.Invoke();
           
        }
    }
 
}

public static class DatatableIdes
{
    public static readonly string[] stringTableIDs =
    {
        
        "StringTableKr",
        "StringTableEn",
        "StringTableJp"
    };

    public static string String => stringTableIDs[(int)Variables.Languages];
    public static string Item => "ItemTable";
    public static string charater => "Charater";
}
