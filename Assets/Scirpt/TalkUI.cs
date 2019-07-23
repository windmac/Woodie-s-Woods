using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TalkUI : MonoBehaviour
{
    public KeyCode NextText = KeyCode.V;
    private string[][] TextContent;

    private Text TalkContent;
    private string[] TalkText;

    public int TextIndex = 0;

    private bool Talking = false;

    private void Awake()
    {
        TalkContent = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(NextText)&&Talking)
        {
            TextIndex++;
            if (TextIndex >= TalkText.Length)
            {
                DestroyThis();
                return;
            }
            TalkContent.text = TalkText[TextIndex];
            
        }
    }

    private void LoadText(string textPath)
    {
        FileStream fs = new FileStream(@".\Assets\Resources\Text\TalkText.json", FileMode.Open, FileAccess.Read);

        StreamReader sr = new StreamReader(fs, System.Text.Encoding.ASCII);

        string talkContent = sr.ReadToEnd();
        string[] talkContent1 = talkContent.Split('\n');
        TextContent = new string[talkContent1.Length][];
        for (int i = 0; i < talkContent1.Length; i++)
        {
            string[] talkContent2 = talkContent1[i].Split(',');
            TextContent[i] = new string[talkContent2.Length];
            for (int j = 0; j < talkContent2.Length; j++)
            {
                TextContent[i][j] = talkContent2[j];
                Debug.Log(talkContent2[j]);
            }
        }
    }

    public void ShowText(string textPath,string[] textID)
    {
        LoadText(textPath);
        TalkText = new string[textID.Length];
        for (int i = 0; i < textID.Length; i++)
        {
            for (int j = 0; j < TextContent.Length; j++)
            {
                if (textID[i]== TextContent[j][0])
                {
                    TalkText[i] = TextContent[j][1];
                    break;
                }
            }
            if (TalkText[i]==string.Empty||TalkText[i]==null)
            {
                TalkText[i] = "###ERROR###";
            }
        }
        if (TalkText.Length<=0)
        {
            return;
        }
        TalkContent.text = TalkText[TextIndex];
        Talking = true;
    }

    public void DestroyThis(float time = 1)
    {
        GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().SetCameraMode(0);
        Destroy(this.gameObject,time);
    }
}
