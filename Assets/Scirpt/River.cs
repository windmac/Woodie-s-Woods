using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class River : MonoBehaviour
{
    public float StayTime = 2;
    public int Damage = 1;
    //public float RebornDistance = 2;
    public float RebornHeight = 0.5f;
    public int CountBackwards = 0;

    private float StayedTime = 0;
    //private GameObject Player;
    //private Vector3 RebornPosition = Vector3.zero;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Woodie")
        {
            Player = other.gameObject;
            Vector3 forward = Player.transform.forward;
            forward = forward.normalized;
            RebornPosition = Player.transform.position;
            RebornPosition -= forward * RebornDistance;
            RebornPosition += Vector3.up * RebornHeight;
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Woodie")
        {
            StayedTime += Time.deltaTime;
            if (StayedTime>=StayTime)
            {
                RemovePlayer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Woodie")
        {
            //Player = null;
            StayedTime = 0;
        }
    }

    private void RemovePlayer()
    {
        WoodieStat.instance.SetPlayerPositionBackwards(CountBackwards, Vector3.up * RebornHeight);
        WoodieStat.instance.takeDamage(Damage);
        StayedTime = 0;
        /*if (Player!=null)
        {
            Player.transform.position = RebornPosition;
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            WoodieStat.instance.takeDamage(Damage);
            Player = null;
            
        }*/
    }
}
