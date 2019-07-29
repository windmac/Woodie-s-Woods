using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallBacks;

public class NPCChatInfo :EventInfo
{
    public int chatter_id;
    public Vector3 chatter_position;
    public Vector3 player_position;

}

public abstract class EventInfo
{
    public string EventDescription;
    public EventSystem.EVENT_TYPE eventType;
}

public class DebugEventInfo:EventInfo
{
    public int VerbosityLevel;
}

public class ObjectInteractionInfo : EventInfo
{
    public int object_id;
    public int action;

}