using EventCallBacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverRockEventControl : MonoBehaviour
{
    private RockBreak rb;
    public NPC_Manager Grandpa;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<RockBreak>();
        EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.OBJECT_INTERACTION, rockbreak);
    }

    void rockbreak(EventInfo ei)
    {
        ObjectInteractionInfo oii = null;
        if (ei.eventType == EventSystem.EVENT_TYPE.OBJECT_INTERACTION)
        {
            
            oii = (ObjectInteractionInfo)ei;
        }

        if (oii != null)
        {
            // Debug.Log(oii.object_id+" "+bs.object_id);
            if (oii.object_id == rb.object_id)
            {
                //Debug.Log("Watering Event Triggered");
                WorldStateManager.instance.worldstate = 7;
                Grandpa.TalkListID = 4;

                //flowerie_manager.TalkListID = 2;
            }
        }


    }

}