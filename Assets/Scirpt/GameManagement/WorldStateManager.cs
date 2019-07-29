using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    public static WorldStateManager instance;

    public int worldstate = 0;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of WoodieStat found");
            return;
        }
        instance = this;
    }

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
