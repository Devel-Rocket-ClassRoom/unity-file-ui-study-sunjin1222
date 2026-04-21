using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInvenSlot : MonoBehaviour
{
    public int slotIndex = -1;

    public Image imageIcon;
    public TextMeshProUGUI textName;

    public SaveItemData saveitemdata { get; private set; }

    public Button button;

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
        saveitemdata = null;
    }

    public void SetItem(SaveItemData data)
    {
        saveitemdata = data;

        imageIcon.sprite = data.ItemData.SpriteIcon;
        textName.text = data.ItemData.StringName;
    }
}
