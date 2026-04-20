using UnityEngine;
using UnityEngine.UI;

public class UiInvenSlotList : MonoBehaviour
{
    public UIInvenSlot prefab;
    public ScrollRect scrollRect;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 눌림");

            for (int i = 0; i < 10; ++i)
            {
                Debug.Log($"생성 {i}");

                var saveItemData = SaveItemData.GetRandomItem();
                var newInven = Instantiate(prefab, scrollRect.content);
                newInven.SetItem(saveItemData);
            }
        }
    }
}
