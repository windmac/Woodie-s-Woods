using EventCallBacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : Destroyable
{
    public GameObject river;
    public int object_id;

    public override void DestoryObject()
    {
        Debug.Log("Break");

        ObjectInteractionInfo oii = new ObjectInteractionInfo();
        oii.EventDescription = gameObject.name + " Object interacted";
        oii.eventType = EventSystem.EVENT_TYPE.OBJECT_INTERACTION;
        oii.object_id = object_id;
        //nci.chatter_id = id;

        EventSystem.Current.FireEvent(EventSystem.EVENT_TYPE.OBJECT_INTERACTION, oii);

        if (river!=null)
        {
            river.transform.localScale = new Vector3(50, 30, 100);
        }
        
        Destroy(this.gameObject);
    }
}
