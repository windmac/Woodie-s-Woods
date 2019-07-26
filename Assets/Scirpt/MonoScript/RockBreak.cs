using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : Destroyable
{
    public GameObject river;

    public override void DestoryObject()
    {
        Debug.Log("Break");

        if(river!=null)
        {
            river.transform.localScale = new Vector3(50, 30, 100);
        }
        
        Destroy(this.gameObject);
    }
}
