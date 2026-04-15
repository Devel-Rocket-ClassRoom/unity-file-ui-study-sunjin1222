using Newtonsoft.Json;
using System.IO;
using UnityEngine;


public class PlayerState
{
    public string PlayerName;

    public int Levels;

    public float Health;

    public Vector3 position;
    public override string ToString()
    {
        return $"{PlayerName}/{Levels}/{Health}";
    }


}

public class JsonTest1 : MonoBehaviour
{

    private JsonSerializerSettings JsonSettings;

    private void Awake()
    {
        JsonSettings=new JsonSerializerSettings();
        JsonSettings.Formatting = Formatting.Indented;
        JsonSettings.Converters.Add(new Vector3Converter());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Save

            PlayerState Obj = new PlayerState
            {
                PlayerName = "아나바",
                Levels = 40,
                Health = 10.999f,
            };

            string path = Path.Combine(
                Application.persistentDataPath,
                "JsonTest",
                "Player2.Json"
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

            string json = JsonConvert.SerializeObject( Obj,Formatting.Indented);

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
             "Player2.Json"
             );

            string json = File.ReadAllText(path);

            PlayerState obj = JsonConvert.DeserializeObject<PlayerState>(json);


            Debug.Log(json);
            Debug.Log(obj);
        }


    }
}
