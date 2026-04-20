using NUnit.Framework.Interfaces;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class KeybordSub : MonoBehaviour
{
    public static event System.Action<string> OnItem;
    public TextMeshProUGUI Key;
    public string charI;


    public void Start()
    {
        charI = Key.text;

    }

    public void onclick()
    {
        OnItem.Invoke(charI);
    }

}
