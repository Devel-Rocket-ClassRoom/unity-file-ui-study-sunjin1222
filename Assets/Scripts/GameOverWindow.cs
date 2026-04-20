
using UnityEngine;
using TMPro;
using Unity.VisualScripting.FullSerializer.Internal;

using UnityEngine.UI;
using System.Collections;

public class GameOverWindow :GenericWindow
{

    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI leftState;
    public TextMeshProUGUI leftScore;
    public TextMeshProUGUI rightState;
    public TextMeshProUGUI rightScore;
    public Button Nextbutton;

    private const int totalstate = 6;
    private int[] stateRolls = new int[totalstate];
    private int finerScore;
    private Coroutine routine;

    private TextMeshProUGUI[] Labels;
    private TextMeshProUGUI[] Values;


    private float statesDelay = 1f;
    private int statePerColume = 3;



    private void Awake()
    {
        Labels=new TextMeshProUGUI[] { leftState, rightState };
        Values=new TextMeshProUGUI[] { leftScore, rightScore };
        Nextbutton.onClick.AddListener(OnNext);
       
    }


    public override void Close()
    {
        base.Close();

        if (routine != null)
        { 
            StopCoroutine(routine);
            routine=null;
        }
    }
    public override void Open()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
        base.Open();
        ResetState();
        routine = StartCoroutine(CoPlayGameOver());
    }

    public void OnNext()
    {
        windowManager.Open(0);
    }


    private void ResetState()
    {
        stateRolls=new int[totalstate];

        for (int i = 0; i < totalstate; i++)
        { 
         stateRolls[i]=Random.Range(0,1000);
        }
        finerScore = Random.Range(0, 1000000);
        for (int i = 0; i < Labels.Length; i++)
        {
            Labels[i].text= string.Empty;
            Values[i].text = string.Empty;
        }

 

        totalScore.text=$"{0:D9}";
    }



    private IEnumerator CoPlayGameOver()
    {
        for (int i = 0; i < totalstate; i++)
        {
          yield return new WaitForSeconds(statesDelay);

            int colume = i / statePerColume;
            var labeltext = Labels[colume];
            var Valuestext = Values[colume];

            string newine= (i% statePerColume==0)?string.Empty:$"\n";
            labeltext.text = $"{labeltext.text}{newine}Stat{i}";
            Valuestext.text = $"{Valuestext.text}{newine}{stateRolls[i]:D4}";

        }
   

        int current = 0;
        float t = 0f;
        while (t < 1f)

        {
            t += Time.deltaTime ;
            current=Mathf.FloorToInt(Mathf.Lerp(0, finerScore, t)) ;
            totalScore.text = $"{current:D9}";
            yield return null;


        }
        totalScore.text = $"{finerScore:D9}";

        routine = null;


    }




}
