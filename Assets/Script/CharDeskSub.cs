using NUnit.Framework.Interfaces;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CharDeskSub : MonoBehaviour
{
    public static System.Action<string> OnItem;
    public TextMeshProUGUI Name;
    public Image image;
    public string charI;


    public void Start()
    {
        var charE = DataTableManager.CharacterTable.Get(charI);
        Name.text = charE.StringNameCh;
        image.sprite = charE.SpriteIconCh;
    }

    public void onclick()
    {
        OnItem.Invoke(charI);
    }

}
