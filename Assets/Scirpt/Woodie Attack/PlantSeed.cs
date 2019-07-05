using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seed;
    public float range = 0.8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 plant_posision = new Vector3(transform.position.x, 0, transform.position.z) + transform.forward * range;



        if (Input.GetKeyDown(KeyCode.C) )
        {


            GameObject clone;
            clone = Instantiate(seed, plant_posision, transform.rotation) as GameObject;

        }
    }
}
