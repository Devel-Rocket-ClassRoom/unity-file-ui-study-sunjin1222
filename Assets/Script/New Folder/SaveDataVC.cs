using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.LowLevelPhysics2D.PhysicsLayers;
using static UnityEngine.Rendering.DebugUI;

[System.Serializable]
public abstract class SaveData
{
    public int Version { get; protected set; }

    public abstract SaveData VersionUp();
}

[System.Serializable]
public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; }
    public SaveDataV1()
    {
        Version = 1;
    }
    public override SaveData VersionUp()
    {
      var saveData=new SaveDataV2();
        saveData.Name = PlayerName;
        return saveData;

    }
}

[System.Serializable]
public class SaveDataV2 : SaveData
{
    public string Name { get; set; }=string.Empty;
    public int Gold = 0;

    public SaveDataV2()
    {
        Version = 2;

    }
    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV2();
        saveData.Name = Name;
        saveData.Gold = Gold;
        return saveData;
    }
}

[System.Serializable]
public class SaveDataV3 : SaveData
{

   
    public string Name { get; set; } = string.Empty;

    public int Gold = 0;


    public List<string> ItemNames = new List<string>();
    public SaveDataV3()
    {
        Version = 3;

    }
    public override SaveData VersionUp()
    {
        return new SaveDataV3();
    }
}

class ArrayList<T> : List<string>
{
    private object value;

    public ArrayList(object value)
    {
        this.value = value;
    }
}