using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public string[] MissionListPath;
    private List<MissionGraph> MissionGraphs;

    private void Awake()
    {
        MissionGraphs = new List<MissionGraph>();
        for (int i = 0; i < MissionListPath.Length; i++)
        {
            MissionGraphs.Add(new MissionGraph(MissionListPath[i]));
        }
    }

    public void OnMissionTriggerActived(int missionList,string missionID,MissionState targetState)
    {
        MissionGraphs[missionList].OnMissionTrgger(missionID, targetState);
    }
}
