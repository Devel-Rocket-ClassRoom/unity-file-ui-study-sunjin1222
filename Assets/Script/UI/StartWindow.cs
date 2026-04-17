using UnityEngine;
using UnityEngine.UI;


public class StartWindow : GenericWindow
{
    public Button continueButton;
    public Button startButton;
    public Button optionButton;

    public bool canContinue=true;

    private void Awake()
    {
        continueButton.onClick.Invoke();
        startButton.onClick.Invoke();
        optionButton.onClick.Invoke();
    }




    public override void Open()
    {
    
        continueButton.gameObject.SetActive(canContinue);
        if (!canContinue)
        {
            firstsekected=startButton.gameObject;
        }
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }


    public void onContinue()
    {
        //Debug.Log(onContinue());
    }

    public void onNewGame()
    {

    }
    public void onOption()
    {

    }



}
