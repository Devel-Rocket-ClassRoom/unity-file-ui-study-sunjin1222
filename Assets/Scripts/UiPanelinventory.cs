using TMPro;
using UnityEngine;

public class UiPanelinventory : MonoBehaviour
{
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiInvenSlotList uiInvenSlotList;

    private void Awake()
    {
        OnLoad();
    }

    public void OnChangesorting(int index)
    {
        uiInvenSlotList.Sorting = (UiInvenSlotList.SortingOptions)index;
    }

    public void OnChangefiltering(int index)
    {
        uiInvenSlotList.Filtering = (UiInvenSlotList.FilteringOptions)index;
    }

    public void OnSave()
    {

        SaveLoadManager.Data.ItemList = uiInvenSlotList.GetSaveItemDatas();

        SaveLoadManager.Data.SortingValue = sorting.value;
        SaveLoadManager.Data.FilteringValue = filtering.value;

        SaveLoadManager.Save();
    }

    public void OnLoad()
    {

        sorting.value = SaveLoadManager.Data.SortingValue;
        filtering.value = SaveLoadManager.Data.FilteringValue;
        OnChangesorting(sorting.value);
        OnChangefiltering(filtering.value);
        uiInvenSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
    }

    public void OnCreateitem()
    {
        uiInvenSlotList.AddRandomItem();
    }

    public void Onremoveitem()
    {
        uiInvenSlotList.Remove();
    }
}