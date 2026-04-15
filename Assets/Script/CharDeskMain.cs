using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharDeskMain : MonoBehaviour
{

    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Desc;
    public TextMeshProUGUI AT;
    public TextMeshProUGUI DF;
   
    private void Start()
    {
        image.sprite = null;
        Name.text = null;
        Desc.text = null;
        AT.text = null;
        DF.text = null;

    }


    public void OnChangedId(string id)
    {
        CharacterData charater = DataTableManager.CharacterTable.Get(id);

        image.sprite = charater.SpriteIconCh;
        Name.text = charater.StringNameCh;
        Desc.text = charater.StringDescCh;
        AT.text = charater.StringATCh;
        DF.text = charater.StringDfCh;
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
