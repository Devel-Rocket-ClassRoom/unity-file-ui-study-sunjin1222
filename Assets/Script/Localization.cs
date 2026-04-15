using NUnit.Framework;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class LocalizationText : MonoBehaviour
{
#if UNITY_EDITOR
    public Languages editorLang;
#endif
    public string[] id;
    public TextMeshProUGUI[] text;






    private void OnEnable()
    {
        if (Application.isPlaying)
        {
            Variables.OnLangugeChangeed+=OnChangedId;

            OnChangedId();
        }
#if UNITY_EDITOR
        else
        {
            OnChangeLanguage(editorLang);
            //OnChangedId();
        }
#endif
    }
    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            Variables.OnLangugeChangeed -= OnChangedId;
        }
     }

    private void OnValidate()
    {
#if UNITY_EDITOR
        OnChangeLanguage(editorLang);
        //OnChangedId();
#else
        OnChangeLanguage();
        //OnChangedId();
#endif
    }

    public void OnChangedId()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = DataTableManager.StringTable.Get(id[i]);
        }
    }
 
    private void OnChangeLanguage()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = DataTableManager.StringTable.Get(id[i]);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("OnChangeLanguage")]
    private void OnChangeLanguage(Languages lang)
    {
        for (int i = 0; i < text.Length; i++)
        {
            var stringTable = DataTableManager.GetStringTable(lang);
            text[i].text = stringTable.Get(id[i]);
        }
    }
#endif
}
