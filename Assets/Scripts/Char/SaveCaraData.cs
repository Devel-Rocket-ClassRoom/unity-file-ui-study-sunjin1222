using Newtonsoft.Json;
using System;
using UnityEngine;
[Serializable]
public class SaveCaraData 
{

    public string charId { get; set; }
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(ItemDataConverter))]
    public CharData charData { get; set; }
    public DateTime CreationTime { get; set; }

    public static SaveCaraData GetRandomItem()
    {
        SaveCaraData newItem = new SaveCaraData();
        newItem.charData = DataTableManager.charTable.GetRandom();
        return newItem;
    }

    public SaveCaraData()
    {
        InstanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{InstanceId}{CreationTime}";
    }

}




