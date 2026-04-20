using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class KeyboardWindow : GenericWindow
{
    private readonly StringBuilder sd = new StringBuilder();

    public GameObject ga;
    public TextMeshProUGUI Headertext;

    private int Max = 7;
    private string Inputstring = string.Empty;

    private float timer = 0f;
    private float delay = 0.5f;
    private bool blink = false;

    private void Awake()
    {
   
        var keys = ga.GetComponentsInChildren<Button>();

        foreach (var key in keys)
        {
            var text = key.GetComponentInChildren<TextMeshProUGUI>();

            // text가 null이 아닐 때만 등록
            if (text != null)
            {
                string keyValue = text.text; // 지역 변수에 복사
                key.onClick.AddListener(() => Onkey(keyValue));
            }
        }
    }

    public override void Open()
    {
        base.Open();
        UpdateInputField();
    }

    public override void Close()
    {
        base.Close();
    }

    public void Onkey(string key)
    {
        Input(key);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            timer = 0f;
            blink = !blink;
            UpdateInputField(); // 깜빡임 상태 바뀔 때 텍스트 갱신
        }
    }

    public void Input(string id)
    {
        if (Inputstring.Length < Max)
        {
            Inputstring += id;
        }

        UpdateInputField();
    }

    private void OnEnable()
    {
        KeybordSub.OnItem += Input;
    }

    private void OnDisable()
    {
        KeybordSub.OnItem -= Input;
    }

    public void OnCancle()
    {
        Inputstring = string.Empty;
        UpdateInputField();
    }

    public void OnDelete()
    {
        if (Inputstring.Length > 0)
        {
            // 문자열 마지막 1글자 삭제
            Inputstring = Inputstring.Substring(0, Inputstring.Length - 1);
            UpdateInputField();
        }
    }

    public void Onaccept()
    {
        windowManager.Open(1);
    }

    private void UpdateInputField()
    {
        sd.Clear();
        sd.Append(Inputstring);

        // 최대 길이가 아니면 커서(_) 표시
        if (Inputstring.Length < Max && blink)
        {
            sd.Append("_");
        }

        Headertext.text = sd.ToString();
    }
}