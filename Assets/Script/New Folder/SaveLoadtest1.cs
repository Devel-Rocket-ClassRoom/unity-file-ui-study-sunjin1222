using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class SaveLoadtest1 : MonoBehaviour
{
    public void OnChangedId(string id)
    {
        ItemData item = DataTableManager.ItemTable.Get(id);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveLoadManager.Data = new SaveDataV3();
            SaveLoadManager.Data.Name = "Test1234";
            SaveLoadManager.Data.Gold = 4321;
            var keys = DataTableManager.ItemTable.Randomitem();
       
            for (int i = 0; i < keys.Count; i++)
            {
                if (Random.Range(0, 2) == 0)
                {
                    int index = Random.Range(0, keys.Count);
                    SaveLoadManager.Data.ItemNames.Add(keys[index]);
                }
            }
            

            SaveLoadManager.Save();
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SaveLoadManager.Load();

        }

    }
}
