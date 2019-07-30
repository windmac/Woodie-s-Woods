using EventCallBacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneThrowerEventControl : MonoBehaviour
{
    private NPC_Manager nm;
    private int chatter_id;
    // Start is called before the first frame update
    void Start()
    {
        nm = this.gameObject.GetComponent<NPC_Manager>();
        chatter_id = nm.id;
        EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.DIALOG_FINISHED, firsttalk);
       // EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.DIALOG_FINISHED, secondtalk);
    }


    public void firsttalk(EventInfo ei)
    {
        NPCChatInfo nci = null;
        if (ei.eventType == EventSystem.EVENT_TYPE.DIALOG_FINISHED)
        {
            nci = (NPCChatInfo)ei;
        }

        if (nci != null)
        {
            if (nci.chatter_id == chatter_id)
            {
                Debug.Log("ST first talk");
                //WorldStateManager.instance.worldstate = 2;
                nm.TalkListID=1;
            }
        }
    }
}
