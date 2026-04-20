using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInvenSlot : MonoBehaviour
{


    public Image imageIcon;
    public TextMeshProUGUI textname;
    public SaveItemData SaveItemData { get; set; }

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textname.text=string.Empty;
        SaveItemData = null;
    }

    public void SetItem(SaveItemData data)
    {
        SaveItemData = data;
        imageIcon.sprite = SaveItemData.ItemData.SpriteIcon;
        textname.text = SaveItemData.ItemData.StringName;

    }

   



}
