using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class CharInvenSlotList : MonoBehaviour
{
    public enum SortingOptions
    {
        CreationTimeAscending,
        CreationTimeDescending,
        NameAscending,
        NameDescending,
    }

    public enum FilteringOptions
    {
        None,
        Normal,
        Rare,
        SuperRare,
        UltraRare,
    }

    public readonly System.Comparison<SaveCaraData>[] comparisons =
    {
        (lhs, rhs) => lhs.CreationTime.CompareTo(rhs.CreationTime),
        (lhs, rhs) => rhs.CreationTime.CompareTo(lhs.CreationTime),
        (lhs, rhs) => lhs.charData.StringName.CompareTo(rhs.charData.StringName),
        (lhs, rhs) => rhs.charData.StringName.CompareTo(lhs.charData.StringName),
    };

    public readonly System.Func<SaveCaraData, bool>[] filterings =
    {
        x => true,
        x => x.charData.Type == charTypes.Norma,
        x => x.charData.Type == charTypes.Rare,
        x => x.charData.Type == charTypes.SuperRare,
        x => x.charData.Type == charTypes.UltraRare,
    };

    public charInvenSlot prefab;
    public ScrollRect scrollRect;

    private List<charInvenSlot> uiSlotList = new List<charInvenSlot>();
    private List<SaveCaraData> saveCaraDataList = new List<SaveCaraData>();

    public SortingOptions sorting = SortingOptions.CreationTimeAscending;
    public FilteringOptions filtering = FilteringOptions.None;

    private int selectedSlotIndex = -1;

    public UnityEvent onUpdateSlots;
    public UnityEvent<SaveCaraData> onSelectSlot;

    public SortingOptions Sorting
    {
        get => sorting;
        set
        {
            if (sorting != value)
            {
                sorting = value;
                UpdateSlots();
            }
        }
    }

    public FilteringOptions Filtering
    {
        get => filtering;
        set
        {
            if (filtering != value)
            {
                filtering = value;
                UpdateSlots();
            }
        }
    }

    private void OnEnable()
    {
        // 필요하면 로드한 데이터 연결
        // SetSaveCaraDataList(SaveLoadManager.Data.CharList);
    }

    private void OnDisable()
    {
        // 필요하면 저장
        // SaveLoadManager.Data.CharList = saveCaraDataList;
        // SaveLoadManager.Save();
    }

    public void SetSaveCaraDataList(List<SaveCaraData> source)
    {
        saveCaraDataList = source != null ? source.ToList() : new List<SaveCaraData>();
        UpdateSlots();
    }

    public List<SaveCaraData> GetSaveCaraDatas()
    {
        return saveCaraDataList;
    }

    private void UpdateSlots()
    {

        var list = saveCaraDataList.Where(filterings[(int)filtering]).ToList();
        list.Sort(comparisons[(int)sorting]);
        if (uiSlotList.Count < list.Count)
        {
            for (int i = uiSlotList.Count; i < list.Count; ++i)
            {
                var slot = Instantiate(prefab, scrollRect.content);

                slot.SetEmpty();
                slot.gameObject.SetActive(false);

                slot.button.onClick.AddListener(() =>
                {
                    selectedSlotIndex = slot.slotIndex;
                    onSelectSlot?.Invoke(slot.saveCaraData);
                });

                uiSlotList.Add(slot);
            }
        }

        for (int i = 0; i < uiSlotList.Count; ++i)
        {
            uiSlotList[i].slotIndex = i;

            if (i < list.Count)
            {
                uiSlotList[i].gameObject.SetActive(true);
                uiSlotList[i].SetItem(list[i]);
            }
            else
            {
                uiSlotList[i].gameObject.SetActive(false);
                uiSlotList[i].SetEmpty();
            }
        }

        selectedSlotIndex = -1;
        onUpdateSlots?.Invoke();


      
    }

    public void AddRandomChar()
    {
        var data = SaveCaraData.GetRandomItem();

        if (data == null || data.charData == null)
        {
            return;
        }

        saveCaraDataList.Add(data);
        UpdateSlots();
    }

    public void Remove()
    {
        if (selectedSlotIndex == -1)
            return;

        if (selectedSlotIndex >= 0 && selectedSlotIndex < uiSlotList.Count)
        {
            saveCaraDataList.Remove(uiSlotList[selectedSlotIndex].saveCaraData);
            UpdateSlots();
        }
    }
}