using EventCallBacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSeed : MonoBehaviour
{
    [SerializeField]
    GameObject bridge;
    [SerializeField]
    GameObject appearence;

    public int object_id;
    private bool triggered = false;
   /* private void OnCollisionEnter(Collision collision)
    {
        print("Bridge starts to grow");
        bridge.SetActive(true);
        StartCoroutine(bridge.GetComponent<BridgeGrow>().Grow());
    }*/

    public void growth()
    {
        if (!triggered)
        {
            triggered = true;
            ObjectInteractionInfo oii = new ObjectInteractionInfo();
            oii.EventDescription = gameObject.name + " Object interacted";
            oii.eventType = EventSystem.EVENT_TYPE.OBJECT_INTERACTION;
            oii.object_id = object_id;
            //nci.chatter_id = id;

            EventSystem.Current.FireEvent(EventSystem.EVENT_TYPE.OBJECT_INTERACTION, oii);

            bridge.SetActive(true);
            StartCoroutine(bridge.GetComponent<BridgeGrow>().Grow());
            Destroy(appearence.gameObject);
            // Destroy(this.gameObject);
        }
    }
}
