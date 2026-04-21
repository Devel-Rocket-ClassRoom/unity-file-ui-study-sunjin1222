using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class charInvenSlot : MonoBehaviour
{
    public int slotIndex = -1;

    public Image imageIcon;
    public TextMeshProUGUI textName;

    public SaveCaraData saveCaraData { get; private set; }

    public Button button;

    private void Awake()
    {
    
    }

    public void SetEmpty()
    {

        imageIcon.sprite = null;
        textName.text = string.Empty;
        saveCaraData = null;
    }

    public void SetItem(SaveCaraData data)
    {
        if (data == null || data.charData == null)
        {
            SetEmpty();
            return;
        }

        saveCaraData = data;

        textName.text = data.charData.StringName;
        imageIcon.sprite = data.charData.SpriteIcon;
    }
}