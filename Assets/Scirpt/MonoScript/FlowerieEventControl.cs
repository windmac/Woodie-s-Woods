using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallBacks;

public class FlowerieEventControl : MonoBehaviour
{
    private NPC_Manager nm;
    private int chatter_id;
    // Start is called before the first frame update
    void Start()
    {
        nm = this.gameObject.GetComponent<NPC_Manager>();
        chatter_id = nm.id;
        EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.DIALOG_FINISHED, firsttalk);
        EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.DIALOG_FINISHED, secondtalk);
    }



    public void firsttalk(EventInfo ei)
    {
        NPCChatInfo nci = null;
        if (ei.eventType == EventSystem.EVENT_TYPE.DIALOG_FINISHED)
        {
            nci = (NPCChatInfo)ei;
        }

        if(nci!=null)
        {
            if (WorldStateManager.instance.worldstate == 1 && nci.chatter_id == chatter_id)
            {
                Debug.Log("Flowerie first talk");
                WorldStateManager.instance.worldstate =2;
                nm.TalkListID++;
            }
        }
    }

    public void secondtalk(EventInfo ei)
    {
        NPCChatInfo nci = null;
        if (ei.eventType == EventSystem.EVENT_TYPE.DIALOG_FINISHED)
        {
            nci = (NPCChatInfo)ei;
        }

        if (nci != null)
        {
            if (WorldStateManager.instance.worldstate == 3 && nci.chatter_id == chatter_id)
            {
                Debug.Log("Flowerie second talk");
                WorldStateManager.instance.worldstate =4;
                nm.TalkListID++;
            }
        }
    }
}
