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

    private GameObject PlayerWoodie;

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
            if (!ShowText&&Input.GetKeyDown(KeyCode.V))
            {
                LookAtEachOther();
                GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().SetCameraMode(1);
                InstantiateTalkContent();
                ShowText = true;
            }
            if (ShowText && TalkUIClone!=null && TalkUIClone.GetComponent<TalkUI>().TextIndex >= TalkID[TalkListID].Length)
            {
                PlayerWoodie.GetComponent<PlayerController2>().canMove = true;
                Destroy(TalkUIClone);
                GameObject.Find("Main Camera").GetComponent<TopDownCamera2>().SetCameraMode(0);
                ShowText = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Woodie")
        {
            PlayerWoodie = other.gameObject;
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
            PlayerWoodie.GetComponent<PlayerController2>().canMove = true;
            PlayerWoodie = null;
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
        PlayerWoodie.GetComponent<PlayerController2>().canMove = false;
        Vector3 direction = PlayerWoodie.transform.position - this.gameObject.transform.position;
        direction.y = 0;
        direction = direction.normalized;

        this.transform.rotation = Quaternion.LookRotation(direction);
        PlayerWoodie.transform.rotation = Quaternion.LookRotation(-direction);
    }

    /*public void SetTalkListID(int talkListID)
    {
        TalkListID = talkListID;
    }*/
}
