using CsvHelper;
using System.Globalization;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;


public class CSVData
{ 
    public string Id { get; set; }
    public string String { get; set; }
}


public class CSV_test1 : MonoBehaviour
{
    //public TextAsset textAsset;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            TextAsset textAsset = Resources.Load<TextAsset>("DataTables/StringTableKr");
            string csv = textAsset.text;
            using (var redear = new StringReader(csv))
            using (var csvredear = new CsvReader(redear, CultureInfo.InvariantCulture))
            {
                var redearCode = csvredear.GetRecords<CSVData>();
                foreach (var rede in redearCode)
                {
                    Debug.Log($"{rede.Id}:{rede.String}");
                }

            }

        }
    }

}
