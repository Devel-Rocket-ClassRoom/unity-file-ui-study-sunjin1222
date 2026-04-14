using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDeskMain : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Desc;


    private void Start()
    {
        image.sprite = null;
        Name.text = null;
        Desc.text= null;
    }

    public void OnChangedId(string id)
    {
        ItemData item = DataTableManager.ItemTable.Get(id);
        
        image.sprite = item.SpriteIcon;
        Name.text = item.StringName;
        Desc.text = item.Desc;
    }

    private void OnEnable()
    {
        ItemDeskSub.OnItem += OnChangedId;
    }
    private void OnDisable()
    {
        ItemDeskSub.OnItem -= OnChangedId;
    }
}