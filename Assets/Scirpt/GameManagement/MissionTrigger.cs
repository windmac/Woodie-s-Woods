using UnityEngine;
using System.Collections;

public class MissionTrigger : MonoBehaviour
{
    public int TargetMissionList;
    public string TargetMissionID;

    private MissionManager MMissionManager;

    private void Awake()
    {
        MMissionManager = GameObject.Find("MissionManager").GetComponent<MissionManager>();
    }

    public void OnMissionTriggerActived(MissionState targetState)
    {
        MMissionManager.OnMissionTriggerActived(TargetMissionList, TargetMissionID, targetState);
    }
}
