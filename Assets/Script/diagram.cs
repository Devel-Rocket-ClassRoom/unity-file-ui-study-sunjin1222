using Newtonsoft.Json;

using System.IO;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;


public class SomeClass
{

    [JsonConverter(typeof(QuaternionConverter))]
    public Quaternion rot;
    [JsonConverter(typeof(ColorConverter))]
    public Color color;
    [JsonConverter(typeof(Vector3Converter))]
    public Vector3 pos;
    [JsonConverter(typeof(Vector3Converter))]
    public Vector3 scale;


    public override string ToString()
    {
        return $"{pos}/{rot}/{scale}/{color}";
    }


}
[System.Serializable]
public class ObjectSaveData
{
    public string prefabName;
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
    public Color color;
}

public class diagram : MonoBehaviour
{

    private JsonSerializerSettings Vector3Settings;
    private JsonSerializerSettings QuaternionSettings;
    private JsonSerializerSettings ColorSettings;

    private void Awake()
    {
        Vector3Settings = new JsonSerializerSettings();
        Vector3Settings.Formatting = Formatting.Indented;
        Vector3Settings.Converters.Add(new Vector3Converter());

        QuaternionSettings = new JsonSerializerSettings();
        QuaternionSettings.Formatting = Formatting.Indented;
        QuaternionSettings.Converters.Add(new QuaternionConverter());

        ColorSettings = new JsonSerializerSettings();
        ColorSettings.Formatting = Formatting.Indented;
        ColorSettings.Converters.Add(new ColorConverter());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Save

            SomeClass Obj = new SomeClass
            {
                rot = new Quaternion(0,0,0,0), 
                color = new Color(0,0,0,0)

            };

            string path = Path.Combine(
                Application.persistentDataPath,
                "JsonTest",
                "diagram"
                );

            string pathFolder = Path.Combine(
                 Application.persistentDataPath,
               "JsonTest");

            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
                Debug.Log($"파일: {Path.GetFileName(pathFolder)}");
                Debug.Log($"전체 경로: {path}");
            }

            string json = JsonConvert.SerializeObject(Obj, Formatting.Indented);

            File.WriteAllText(path, json);

            Debug.Log(path);
            Debug.Log(json);


        }


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Load
            string path = Path.Combine(
             Application.persistentDataPath,
             "JsonTest",
             "diagram"
             );

            string json = File.ReadAllText(path);

            SomeClass obj = JsonConvert.DeserializeObject<SomeClass>(json);


            Debug.Log(json);
            Debug.Log(obj);
        }


    }
}


