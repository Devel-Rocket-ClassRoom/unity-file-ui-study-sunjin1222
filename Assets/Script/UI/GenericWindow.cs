using UnityEngine;
using UnityEngine.EventSystems;
public class GenericWindow : MonoBehaviour
{

    public GameObject firstsekected;

    protected WindowManager windowManager;

    public void init(WindowManager ws)
    {
        ws = windowManager;
    }


    public virtual void Open()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstsekected);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

}
