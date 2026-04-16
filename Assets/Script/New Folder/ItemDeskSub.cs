using NUnit.Framework.Interfaces;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemDeskSub : MonoBehaviour
{
    public static System.Action<string> OnItem;
    public TextMeshProUGUI Name;
    public Image image;
    public string itemR;
 

    public void Start()
    {
        var item = DataTableManager.ItemTable.Get(itemR);
        Name.text = item.StringName;
        image.sprite = item.SpriteIcon;
    }

    public void onclick()
    {
        OnItem.Invoke(itemR);
    }



}





