using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsLayers;

public class PlayerInfo
{ 
    public string PlayerName;
    public int Level;

    public float Heath;

    public Vector3 Position;

    public Dictionary<string, int> score = new Dictionary<string, int>
    {
        { "stage1",100},
        { "stage2",200}
    };


}

public class Jsontest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Save

            PlayerInfo Obj = new PlayerInfo
            {
                PlayerName = "ABC",
                Level = 10,
                Heath = 10.999f,
                Position = new Vector3(1f, 2f, 3f)
            };

            string path = Path.Combine(
                Application.persistentDataPath,
                "JsonTest",
                "Player.Json"
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
 
            string json = JsonUtility.ToJson( Obj,prettyPrint:true );
            File.WriteAllText( path, json );


        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Load
            string path = Path.Combine(
             Application.persistentDataPath,
             "JsonTest",
             "Player.Json"
             );

            string json=File.ReadAllText( path );

            //PlayerInfo obj=JsonUtility.FromJson<PlayerInfo>( json );

            PlayerInfo obj = new PlayerInfo();
            JsonUtility.FromJsonOverwrite(json, obj);


            Debug.Log(json);
            Debug.Log($"{obj.PlayerName}/{obj.Heath}");
        }
    }



}
