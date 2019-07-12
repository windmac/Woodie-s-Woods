using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissionState
{
    Unacceptable = 0,
    Acceptable = 1,
    InProgress = 2,
    SuccessfullyFinished = 3,
    FailedMission = 4,
}

public class MissionNode
{
    public string MissionID;
    public MissionState State { get; protected set; }
    public string MissionName;
    public string MissionDescription;
    public string NextMissionID;

    public MissionNode(string missionID,MissionState state ,string missionName,string missionDescription,string nextMissionID)
    {
        MissionID = missionID;
        SetMissionState(state);
        MissionName = missionName;
        MissionDescription = missionDescription;
        NextMissionID = nextMissionID;
    }

    public void SetMissionState(MissionState state)
    {
        if ((int)state >= (int)State)     //任务不能倒着进行
        {
            State = state;
        }
        else
        {
            return;
        }
        switch (state)
        {
            case MissionState.Unacceptable:
                //WHAT TO DO
                break;
            case MissionState.Acceptable:
                break;
            case MissionState.InProgress:
                break;
            case MissionState.SuccessfullyFinished:
                break;
            case MissionState.FailedMission:
                break;
            default:
                break;
        }
    }
}
