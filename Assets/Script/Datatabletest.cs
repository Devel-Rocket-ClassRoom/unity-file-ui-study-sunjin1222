using CsvHelper;
using System.Globalization;
using System.IO;
using UnityEngine;
using static Unity.VisualScripting.Icons;
using static UnityEngine.Rendering.DebugUI;

public class Datatabletest : MonoBehaviour
{
    public string NameStringTableKr = "stringTableKr";
    public string NameStringTableEn = "stringTableEn";
    public string NameStringTableJp = "stringTableJp";


    public void OnClickstringtableKr()
    {

        Debug.Log(DataTableManager.StringTable.Get("You Die"));

    }

    public void OnClickstringtableEn()
    {
        var textAsset = new StringTable();
        textAsset.Load(NameStringTableEn);
        Debug.Log(textAsset.Get("You Die"));
    
    }

    public void OnClickstringtableJp()
    {
        var textAsset = new StringTable();
        textAsset.Load(NameStringTableJp);
        Debug.Log(textAsset.Get("You Die"));
      
    }





}
