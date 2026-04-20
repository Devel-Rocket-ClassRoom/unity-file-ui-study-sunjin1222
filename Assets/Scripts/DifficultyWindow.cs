using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class DifficultyWindow : GenericWindow
{

    public Toggle[] toggles;
    public int selected;
    private string Difficulty= "Easy";

    private void Awake()
    {
        toggles[0].onValueChanged.AddListener(OnEasy);
        toggles[1].onValueChanged.AddListener(OnNomal);
        toggles[2].onValueChanged.AddListener(OnHard);
    }


    public override void Open()
    {
        base.Open();
        toggles[selected].isOn = true;
        Savedata(Difficulty);

    }

    public override void Close()
    {
        base.Close();
 
    }

    public void OnEasy(bool active)
    {
        if (active)
        {
            Difficulty= "Easy";
        }
    }
    public void OnNomal(bool active)
    {
        if (active)
        {
            Difficulty = "Normal";
        }
    }
    public void OnHard(bool active)
    {
        if (active)
        {
            Difficulty = "Hard";
        }
    }

    public void OnSave()
    {
       Savedata(Difficulty);
    }

      public void OnCancle()
    {
        windowManager.Open(0);
    }

    public void Savedata(string Difficulty)
    {
        string path = Path.Combine( Application.persistentDataPath,"JsonTest","to.Json");

            string pathFolder = Path.Combine(
                 Application.persistentDataPath,
               "JsonTest");
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
                Debug.Log($"파일: {Path.GetFileName(pathFolder)}");
                Debug.Log($"전체 경로: {path}");
            }

        string json = $"난이도: {Difficulty}"; 
        File.WriteAllText(path, json); 
        Debug.Log($"난이도: {Difficulty}");
        Debug.Log(path);
    }

    
    }


