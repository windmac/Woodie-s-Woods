using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EventCallBacks
{
    public class EventSystem : MonoBehaviour
    {
        static private EventSystem _Current;
        static public EventSystem Current
        {
            get
            {
                if(_Current == null)
                {
                    _Current = GameObject.FindObjectOfType<EventSystem>();
                }

                return _Current;
            }
        }

        public delegate void EventListener(EventInfo e);
        public enum EVENT_TYPE { DIALOG_FINISHED, ENEMY_DIE, OBJECT_COLLECTED, AREA_ARRIVED,OBJECT_INTERACTION }
        Dictionary<EVENT_TYPE, List<EventListener>> eventListeners;

        
        public void RegisterListener(EVENT_TYPE eventType, EventListener listener)
        {
            if(eventListeners ==null)
            {
                eventListeners = new Dictionary<EVENT_TYPE, List<EventListener>>();
            }

            if(eventListeners.ContainsKey(eventType) == false ||  eventListeners[eventType] ==null)
            {
                eventListeners[eventType] = new List<EventListener>();
            }

            eventListeners[eventType].Add(listener);
        }

        public void UnregisterListener(EVENT_TYPE eventType, EventListener listener)
        {

        }

        public void FireEvent(EVENT_TYPE eventType,EventInfo e)
        {
            if(eventListeners == null || eventListeners[eventType] ==null)
            {
                //No one is listening, we are done.
                return;
            }

            foreach(EventListener el in eventListeners[eventType])
            {
                el(e);
            }
        }
    }


}
