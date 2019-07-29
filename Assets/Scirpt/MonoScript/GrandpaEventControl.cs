using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallBacks;

public class GrandpaEventControl : MonoBehaviour
{
    private NPC_Manager nm;

    private int chatter_id;
    // Start is called before the first frame update
    void Start()
    {
        nm = this.gameObject.GetComponent<NPC_Manager>();
        chatter_id = nm.id;

        EventSystem.Current.RegisterListener(EventSystem.EVENT_TYPE.DIALOG_FINISHED, firsttalk);
    }


    
    public void firsttalk(EventInfo ei)
    {
        NPCChatInfo nci =null;
        if (ei.eventType== EventSystem.EVENT_TYPE.DIALOG_FINISHED)
        {
            nci = (NPCChatInfo)ei;
        }
         
        if(nci!=null)
        {
            if (WorldStateManager.instance.worldstate == 0 && nci.chatter_id == chatter_id)
            {
                Debug.Log("Grandpa first talk");
                WorldStateManager.instance.worldstate++;
                nm.TalkListID++;
            }
        }

    }

   /* void secondtalk(NPCChatInfo nci)
    {
        if (WorldStateManager.instance.worldstate == 1)
        {
            Debug.Log("Grandpa second talk");
            

            WorldStateManager.instance.worldstate++;
        }
    }*/
}
