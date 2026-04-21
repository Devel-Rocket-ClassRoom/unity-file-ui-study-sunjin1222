using TMPro;
using UnityEngine;

public class charPanelinventory : MonoBehaviour
{

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public CharInvenSlotList charInvenSlotList;

    private void Awake()
    {
        filtering.value = 0;
        charInvenSlotList.Filtering = CharInvenSlotList.FilteringOptions.None;
        OnLoad();
    }

    public void OnChangesorting(int index)
    {
        charInvenSlotList.Sorting = (CharInvenSlotList.SortingOptions)index;
    }

    public void OnChangefiltering(int index)
    {
        charInvenSlotList.Filtering = (CharInvenSlotList.FilteringOptions)index;
    }

    public void OnSave()
    {

        SaveLoadManager.Data.charList = charInvenSlotList.GetSaveCaraDatas();

        SaveLoadManager.Data.SortingValue = sorting.value;
        SaveLoadManager.Data.FilteringValue = filtering.value;

        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        sorting.value = SaveLoadManager.Data.SortingValue;
        filtering.value = SaveLoadManager.Data.FilteringValue;

        // 🔥 여기 추가
        filtering.value = 0;

        OnChangesorting(sorting.value);
        OnChangefiltering(filtering.value);

        charInvenSlotList.SetSaveCaraDataList(SaveLoadManager.Data.charList);
    }

    public void OnCreateitem()
    {
        charInvenSlotList.AddRandomChar();
    }

    public void Onremoveitem()
    {
        charInvenSlotList.Remove();
    }
}

