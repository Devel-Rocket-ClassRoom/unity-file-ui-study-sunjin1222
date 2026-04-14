using System.IO;

using UnityEngine;

public class PathCombineExample : MonoBehaviour
{
    private string Savedata;
    private string path1;
    private string path2;
    private string path3;
    void Start()
    {
        Savedata = Path.Combine(Application.persistentDataPath, "Savedata");

        if (!Directory.Exists(Savedata))
        {
            Directory.CreateDirectory(Savedata);

        }

        path1 = Path.Combine(Savedata, "data1.txt");
        Debug.Log($"파일 경로: {path1}");
        path2 = Path.Combine(Savedata, "data2.txt");
        Debug.Log($"파일 경로: {path2}");
        path3 = Path.Combine(Savedata, "data3.txt");
        Debug.Log($"파일 경로: {path3}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            string text_1 = $"=== 게임 로그 ===\n\"시작 시간: {System.DateTime.Now}\"\n\"플레이어가 게임에 접속했습니다.\"";
            File.WriteAllText(path1, text_1);

            Debug.Log("파일 저장 완료");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            string text_2 = $"=== 게임 로그 ===\n\"시작 시간: {System.DateTime.Now}\"\n\"플레이어가 게임에 접속했습니다.\"";

            File.WriteAllText(path2, text_2);

            Debug.Log("파일 저장 완료");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            string text_3 = $"=== 게임 로그 ===\n\"시작 시간: {System.DateTime.Now}\"\n\"플레이어가 게임에 접속했습니다.\"";

            File.WriteAllText(path3, text_3);

            Debug.Log("파일 저장 완료");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {

            if (File.Exists(path1))
            {
                string backupPath = Path.Combine(Savedata, "data1_backup.txt");
                File.Copy(path1, backupPath, true);
                Debug.Log("data1_backup 복사 완료");
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (File.Exists(path3))
            {
                Debug.Log("파일이 존재합니다.");
                File.Delete(path3);
                Debug.Log("파일이 삭제되었습니다.");
            }
            else
            {
                Debug.Log("파일이 존재하지 않습니다.");
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Directory.Exists(Savedata))
            {
                string[] files = Directory.GetFiles(Savedata);

                foreach (string file in files)
                {
                    Debug.Log($"찾은 파일: {file}");
                }
            }
            else
            {
                Debug.Log("Savedata 폴더가 없습니다.");
            }
        }
    }
}

