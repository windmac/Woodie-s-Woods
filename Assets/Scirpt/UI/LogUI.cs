using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogUI : MonoBehaviour
{
    public float ShowTime;
    public GameObject Log;
    private List<GameObject> LogList;

    private void Awake()
    {
        LogList = new List<GameObject>();
    }

    public void ShowLog(string text)
    {
        GameObject LogText = GameObject.Instantiate<GameObject>(Log, this.transform);
        LogList.Add(LogText);
        RecombinationLogText();
        LogText.GetComponent<Text>().text = text;
        Invoke("RemoveTheFirstLogText", ShowTime);
    }

    private void RecombinationLogText()
    {
        for (int i = 0; i < LogList.Count; i++)
        {
            LogList[i].transform.position = Vector3.zero + Vector3.up * (60 * (LogList.Count - i) - 20);
        }
    }

    private void RemoveTheFirstLogText()
    {
        Destroy(LogList[0]);
        LogList.Remove(LogList[0]);
        RecombinationLogText();
    }
}
