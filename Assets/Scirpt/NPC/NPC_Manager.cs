using EventCallBacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class NPC_Manager : MonoBehaviour
{
    public string TextPath;
    public int TalkListID;
    public GameObject TalkUIParent;
    public GameObject TalkUIPrefab;

    public Vector3 talking_offest_adjestment;
    private GameObject TalkUIClone;
    public bool destoryable = false;
    public int id;
    //private GameObject PlayerWoodie;
   // public KeyCode talk_key = KeyCode.H;

    

    private bool Talking = false;
    private bool ShowText = false;

    public string[] TextID;
    private string[][] TalkID;

    private void Awake()
    {
        

        TalkID = new string[TextID.Length][];
        for (int i = 0; i < TextID.Length; i++)
        {
            string[] IDlist = TextID[i].Split(',');
            TalkID[i] = new string[IDlist.Length];
            for (int j = 0; j < IDlist.Length; j++)
            {
                TalkID[i][j] = IDlist[j];
            }
        }
    }

    private void Update()
    {
        if (Talking)
        {
            if (!ShowText&& KeyMappingManager.instance.talk)
            {
                if(!destoryable)
                {
                    LookAtEachOther();
                }
                
                GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().SetCameraMode(1);
                InstantiateTalkContent();
                ShowText = true;


            }
            if (ShowText && TalkUIClone!=null && TalkUIClone.GetComponent<TalkUI>().TextIndex >= TalkID[TalkListID].Length)
            {
                PlayerManager.instance.player.GetComponent<PlayerController2>().canMove = true;
                Destroy(TalkUIClone);
                GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().SetCameraMode(0);
                ShowText = false;

                //Fake scrolling text
                /*   if(TalkListID< TextID.Length-1)
                     {
                         TalkListID++;
                     }
                     Debug.Log("Talk list id " +TalkListID);
                    */
                NPCChatInfo nci = new NPCChatInfo();
                nci.EventDescription = gameObject.name + " Chat finished";
                nci.chatter_id = id;
                nci.eventType = EventSystem.EVENT_TYPE.DIALOG_FINISHED;

                EventSystem.Current.FireEvent(EventSystem.EVENT_TYPE.DIALOG_FINISHED, nci);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Woodie")
        {
           // PlayerWoodie = other.gameObject;
            Talking = true;
            GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().talking_target = this.gameObject;
            GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().talk_point = other.transform;
            GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().talking_offest_adjestment = talking_offest_adjestment;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Woodie")
        {
            PlayerManager.instance.player.GetComponent<PlayerController2>().canMove = true;
           // PlayerWoodie = null;
            Destroy(TalkUIClone);
            Talking = false;
            GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().talking_target = null;
            GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().talk_point = null;
            GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().talking_offest_adjestment =new Vector3(0,0,0);

        }
    }

    private void InstantiateTalkContent()
    {
        TalkUIClone = GameObject.Instantiate(TalkUIPrefab, TalkUIParent.transform);
        TalkUIClone.GetComponent<TalkUI>().ShowText(TextPath,TalkID[TalkListID]);
    }

    private void LookAtEachOther()
    {
        PlayerManager.instance.player.GetComponent<PlayerController2>().canMove = false;
        Vector3 direction = PlayerManager.instance.player.transform.position - this.gameObject.transform.position;
        direction.y = 0;
        direction = direction.normalized;

        this.transform.parent.transform.rotation = Quaternion.LookRotation(direction);
        PlayerManager.instance.player.transform.rotation = Quaternion.LookRotation(-direction);
    }

    /*public void SetTalkListID(int talkListID)
    {
        TalkListID = talkListID;
    }*/
}
