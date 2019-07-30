using EventCallBacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryadEventControl : MonoBehaviour
{
    private NPC_Manager nm;

    private int chatter_id;
    // Start is called before the first frame update

    public NPC_Manager grandpa;
    void Start()
    {
        nm = this.gameObject.GetComponent<NPC_Manager>();
        chatter_id = nm.id;

        EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.DIALOG_FINISHED, firsttalk);
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
            Debug.Log(nci.chatter_id +" "+chatter_id);
            if (WorldStateManager.instance.worldstate <= 4 && nci.chatter_id == chatter_id)
            {
                Debug.Log("Dryad first talk");
                WorldStateManager.instance.worldstate = 5;
                nm.TalkListID =1;

                grandpa.TalkListID = 2;
            }
        }

    }
}
