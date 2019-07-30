using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallBacks;

public class FirstSeedWaterEvent : MonoBehaviour
{
    // Start is called before the first frame update
    private BridgeSeed bs;
    public NPC_Manager flowerie_manager;

    void Start()
    {
        bs = this.gameObject.GetComponent<BridgeSeed>();
        EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.OBJECT_INTERACTION, watered);
        Debug.Log("here");
    }

    void watered(EventInfo ei)
    {
       // Debug.Log(ei.eventType + " " + EventSystem.EVENT_TYPE.OBJECT_INTERACTION);
        ObjectInteractionInfo oii = null;
        if (ei.eventType == EventSystem.EVENT_TYPE.OBJECT_INTERACTION)
        {
           // Debug.Log("Object interacted");
            oii = (ObjectInteractionInfo)ei;
        }

       if(oii!=null)
        {
           // Debug.Log(oii.object_id+" "+bs.object_id);
            if (oii.object_id == bs.object_id)
            {
                Debug.Log("Watering Event Triggered");
                WorldStateManager.instance.worldstate = 3;
                flowerie_manager.TalkListID = 2;
            }
        }

    }
}
