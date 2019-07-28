using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBox : MonoBehaviour
{
    private Transform colliders;
    void Start()
    {
        colliders = transform;

        foreach(Transform child in colliders)
        {
            if(child.GetComponent<MeshRenderer>()!=null)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }


}
