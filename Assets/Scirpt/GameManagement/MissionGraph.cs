using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionGraph
{
    private List<MissionNode> MissionTree;

    public MissionGraph(string missionListPath)
    {
        MissionTree = new List<MissionNode>();
        ReadMissionList(missionListPath);
    }

    public void OnMissionTrgger(string missionID,MissionState targetState)
    {
        MissionTree[FindMissionNode(missionID)].SetMissionState(targetState);
    }

    private void ReadMissionList(string missionListPath)
    {
        string content = Resources.Load<TextAsset>(missionListPath).text;
        string[] content1 = content.Split('\n');
        for (int i = 0; i < content1.Length; i++)
        {
            string[] content2 = content1[i].Split(',');
            MissionTree.Add(new MissionNode(content2[0], 
                                            (MissionState)int.Parse(content2[1]), 
                                            content2[2], 
                                            content2[3], 
                                            content2[4]));
        }
    }

    private int FindMissionNode(string missionID)
    {
        for (int i = 0; i < MissionTree.Count; i++)
        {
            if (missionID == MissionTree[i].MissionID)
            {
                return i;
            }
        }
        return 0;
    }
    private int GetNextMissionNode(string missionID)
    {
        return FindMissionNode(MissionTree[FindMissionNode(missionID)].NextMissionID);
    }
}
