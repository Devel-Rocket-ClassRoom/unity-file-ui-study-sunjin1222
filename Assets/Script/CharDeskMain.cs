using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharDeskMain : MonoBehaviour
{

    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Desc;


    private void Start()
    {
        image.sprite = null;
        Name.text = null;
        Desc.text = null;
    }

  
    public void OnChangedId(string id)
    {
        CharacterData charater = DataTableManager.CharacterTable.Get(id);

        image.sprite = charater.SpriteIconCh;
        Name.text = charater.StringNameCh;
        Desc.text = charater.StringDescCh;
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
