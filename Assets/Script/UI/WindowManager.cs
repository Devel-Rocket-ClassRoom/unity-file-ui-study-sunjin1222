using UnityEngine;

public class WindowManager : MonoBehaviour
{
 public GenericWindow[] windows;

    public int crreentWindoId;
    public int defaultWindowId;

    private void Awake()
    {
        foreach (var window in windows)
        {
            window.gameObject.SetActive(false);
            window.init(this);
        }

        crreentWindoId=defaultWindowId;
        windows[crreentWindoId].Open();
    }


    public GenericWindow Open(int id)
    {
        windows[crreentWindoId].Close();
        crreentWindoId=id;
        windows[defaultWindowId].Open();

          return windows[crreentWindoId];  
    }

}
