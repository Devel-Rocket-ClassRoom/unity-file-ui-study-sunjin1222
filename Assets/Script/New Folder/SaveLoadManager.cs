using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using SaveDataVC = SaveDataV3;
using Unity.VisualScripting;
public static class SaveLoadManager 
{

    public enum Savemode
    { 
        Test,
        Encrypted,
    }
    public static Savemode mode { get; set; }=Savemode.Test;


    public static int SaveDataVersion { get; } = 3;
 

    private static readonly string SaveDirectory =Path.Combine(Application.persistentDataPath, "Save");

    private static readonly string[] SaveFileNames =
    {
        "SaveAuto",
        "Save1",
        "Save2",
        "Save3",
    };


    public static SaveDataVC Data { get; set; } = new SaveDataVC();

    public static string GetSaveSilePath(int slot)
    {
        return GetSaveSilePath(slot,mode);
    }
  


    public static string GetSaveSilePath(int slot, Savemode mode)
    {
        var ext = mode == Savemode.Test ? ".Json" : ".dat";

        return Path.Combine(SaveDirectory, $"{SaveFileNames[slot]}{ext}");
    }

    private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All
    };

    public static bool Save(int slot = 0)
    {
    
    return Save(mode,slot);
    }


    public static bool Save(Savemode mode,int slot = 0 )
    {
        if (Data == null || slot < 0 || slot >= SaveFileNames.Length)
        {
            Debug.LogError("Data 예외");
            return false;
        }
        try
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
            string json = JsonConvert.SerializeObject(Data, Settings);
            string path = GetSaveSilePath(0, mode);
        
            switch (mode)
            {
                case Savemode.Test:
                    File.WriteAllText(path, json);
                    break;

                case Savemode.Encrypted:
                    File.WriteAllBytes(path, CryptoUtil.Encrypt(path));
                    break;

            }
            Debug.Log($"저장 완료: {path}");
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Save 예외: {e}");
            return false;
        }
    }

    public static bool Load(int slot = 0)
    {

        return Load(mode, slot);
    }


    public static bool Load(Savemode mode,int slot = 0)
    {
        if (slot < 0 || slot >= SaveFileNames.Length)
        {
            Debug.LogError("Data 예외");
            return false;
        }
        string path = Path.Combine(SaveDirectory, SaveFileNames[slot]);
        if (!File.Exists(path))
        {
            return false;
        }
        try
        {
            string json = string.Empty;
            
            switch(mode)
            {
                case Savemode.Test:
                    json= File.ReadAllText(path);
                    break;

                case Savemode.Encrypted:
                    json = CryptoUtil.Decrypt(File.ReadAllBytes(path));
                    break;
            }

            var saveData = JsonConvert.DeserializeObject<SaveData>(json, Settings);
            while (saveData.Version < SaveDataVersion)
            {

                saveData = saveData.VersionUp();

            }
            Data = saveData as SaveDataVC;
     
            Debug.Log(json);
            Debug.Log(saveData);

            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Load: {e}");
            return false;
        }

    }


}
