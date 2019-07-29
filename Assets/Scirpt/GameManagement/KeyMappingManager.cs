using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMappingManager : MonoBehaviour
{

    public KeyCode talk_key = KeyCode.H;
    public bool talk = false;

    public KeyCode item_use_key = KeyCode.J;
    public bool item_use = false;

    public KeyCode jump_key = KeyCode.K;
    public bool jump = false;

    public KeyCode item_switch_key = KeyCode.L;
    public bool item_switch = false;

    public KeyCode seed_switch_key = KeyCode.I;
    public bool seed_switch = false;

    public static KeyMappingManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of KeyMappingManager found");
            return;
        }
        instance = this;

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(talk_key))
        {
            talk = true;
        }else
        {
            talk = false;
        }

        if (Input.GetKeyDown(item_use_key))
        {
            item_use = true;
        }
        else
        {
            item_use = false;
        }

        if (Input.GetKeyDown(jump_key))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (Input.GetKeyDown(item_switch_key))
        {
            item_switch = true;
        }
        else
        {
            item_switch = false;
        }

        if (Input.GetKeyDown(seed_switch_key))
        {
            seed_switch = true;
        }
        else
        {
            seed_switch = false;
        }

    }
}
